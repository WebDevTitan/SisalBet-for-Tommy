using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MasterDevs.ChromeDevTools.Protocol.Chrome.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SisalBet.Controller;

namespace SisalBet
{
    public class Scanner
    {
        private HttpClient httpClient = null;
        private CookieContainer coockieContainer = null;
        private string domain = "www.sisal.it";
        public Scanner()
        {
            httpClient = initHttpClient();           
        }

        public HttpClient initHttpClient(bool bUseNewCookie = true)
        {
            HttpClientHandler handler = new HttpClientHandler();

            coockieContainer = new CookieContainer();
            handler.CookieContainer = coockieContainer;
            httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept", "*/*");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Language", "en-US,en;q=0.9");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("content-type", "application/json");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("sec-ch-ua", "\"Not(A:Brand\";v=\"99\", \"Google Chrome\";v=\"133\", \"Chromium\";v=\"133\"");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("sec-ch-ua-mobile", "?0");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("sec-ch-ua-platform", "\"Windows\"");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Sec-Fetch-Dest", "empty");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Sec-Fetch-Mode", "cors");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Sec-Fetch-Site", "same-site");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Referer", $"https://{domain}/");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("referrerPolicy", "strict-origin-when-cross-origin");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("method", "GET");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("mode", "cors");
            httpClient.DefaultRequestHeaders.ExpectContinue = false;
            return httpClient;
        }

        public string getleagueIDs()
        {
            string jsonOutput = "";
            try
            {
                HttpResponseMessage resultBetting = httpClient.GetAsync("https://betting.sisal.it/api/lettura-palinsesto-sport/palinsesto/prematch/alberaturaPrematch").Result;
                resultBetting.EnsureSuccessStatusCode();
                string resultstring = resultBetting.Content.ReadAsStringAsync().Result;
                dynamic jsonIds = JsonConvert.DeserializeObject<dynamic>(resultstring);
                string Idsstring = jsonIds["manifestazioneListByDisciplinaTutti"].ToString();
                var allData = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(Idsstring);
                string[] keysToKeep = { "1", "2", "5", "60" };
                var filteredData = new Dictionary<string, List<string>>();
                foreach (var key in keysToKeep)
                {
                    if (allData.ContainsKey(key))
                    {
                        filteredData[key] = allData[key];
                    }
                }
                jsonOutput = JsonConvert.SerializeObject(filteredData, Formatting.Indented);               

            }
            catch (Exception ex)
            {
                Global.WrittingLog($"getleagueIDs exception {ex.StackTrace} {ex.Message}");
            }

            return jsonOutput;
        }

        public bool ScanFunction()
        {
            try
            {
                string LeagueIds = getleagueIDs();
                JObject jsonObject = JObject.Parse(LeagueIds);                
                var flatList = new List<string>();                
                foreach (var property in jsonObject.Properties())
                {
                    if (property.Value is JArray array)
                    {
                        foreach (var item in array)
                        {
                            flatList.Add(item.ToString());
                        }
                    }
                }


                JArray flatArray = new JArray(flatList);
                string jsonOutput = JsonConvert.SerializeObject(flatList, Formatting.Indented);

                JObject TotalEvents = Geteventids(flatArray);

            }
            catch(Exception ex)
            {
                Global.WrittingLog($"ScanFunction error : {ex.Message}");
                return false;
            }
            return true;
        }

        private JObject Geteventids(JArray flatArray)
        {
            try
            {
                var extractedList = new JArray();
                JArray Fids = flatArray;
                foreach (var i in Fids)
                {
                    HttpResponseMessage resultEventDetails = httpClient.GetAsync($"https://betting.sisal.it/api/lettura-palinsesto-sport/palinsesto/prematch/schedaManifestazione/0/{i}").Result;
                    resultEventDetails.EnsureSuccessStatusCode();
                    string resultstring = resultEventDetails.Content.ReadAsStringAsync().Result;
                    dynamic jsonEventDetails = JsonConvert.DeserializeObject<dynamic>(resultstring);
                    JArray avvenimentoFeList = (JArray)jsonEventDetails["avvenimentoFeList"];

                    // Create a HashSet to store unique eventId and descrizioneAvvenimento pairs
                    var uniqueEvents = new HashSet<string>();                   

                    foreach (var avvenimento in avvenimentoFeList)
                    {
                        // Extract 'scommessaKeyDataList' array
                        JArray scommessaKeyDataList = (JArray)avvenimento["scommessaKeyDataList"];

                        foreach (var scommessa in scommessaKeyDataList)
                        {
                            // Extract eventId and descrizioneAvvenimento
                            int eventId = scommessa["eventId"].Value<int>();
                            string descrizioneAvvenimento = scommessa["descrizioneAvvenimento"].Value<string>();

                            // Use HashSet to prevent duplicate entries
                            string uniqueKey = $"{eventId}-{descrizioneAvvenimento}";
                            if (!uniqueEvents.Contains(uniqueKey))
                            {
                                uniqueEvents.Add(uniqueKey);

                                // Create a new JObject with required fields
                                var newEvent = new JObject
                                {
                                    { "eventId", eventId },
                                    { "eventTitle", descrizioneAvvenimento }
                                };

                                extractedList.Add(newEvent);
                            }
                        }


                    }
                    Global.WrittingLog(extractedList.Count.ToString() + "counts of events are scanned.");

                }
                Setting.Instance.EventIdsResult = extractedList;
                Global.WrittingLog("total" + extractedList.Count.ToString() + "scanned");
                string jsonOutput = JsonConvert.SerializeObject(extractedList, Formatting.Indented);
                File.WriteAllText("output.txt", jsonOutput);

            }
            catch(Exception ex)
            {
                Global.WrittingLog($"Geteventids error : {ex.Message}");
            }
            return null;
        }
    }
}
