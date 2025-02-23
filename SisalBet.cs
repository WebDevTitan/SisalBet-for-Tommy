using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using AutoIt;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SisalBet.Controller;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static MasterDevs.ChromeDevTools.Protocol.Chrome.ProtocolName;

namespace SisalBet
{
    public class SisalBet
    {
        private HttpClient httpClient = null;
        private CookieContainer coockieContainer = null;
        private string domain = "www.sisal.it";
        public List<CombinationBodyarray> CombinationList= new List<CombinationBodyarray>();
        

        public SisalBet()
        {
            httpClient = initHttpClient();
            if (CDPController.Instance._browserObj == null)
                CDPController.Instance.InitializeBrowser($"https://{domain}/");
            Thread.Sleep(7000);
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

        
        public string getProxyLocation()
        {
            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage resp = httpClient.GetAsync("http://lumtest.com/myip.json").Result;
                var strContent = resp.Content.ReadAsStringAsync().Result;
                dynamic json = JObject.Parse(strContent);
                return json["geo"]["region_name"].ToString() + " - " + json["country"].ToString();

            }
            catch (Exception ex)
            {
                Global.WrittingLog($"getProxyLocation exception {ex.StackTrace} {ex.Message}");
            }
            return "UNKNOWN";
        }

        public bool login()
        {
            Thread.Sleep(7000);            
            
           //AutoItX.MouseClick("LEFT", 536, 365, 1, 0);
            Global.WrittingLog("Login started.");
            bool isloggedin = false;
            try
            {              
               
                int retryCount = 2;
                while (retryCount-- > 0)
                {
                    
                    long documentId = CDPController.Instance.GetDocumentId().Result;
                    bool isFound = CDPController.Instance.FindAndClickElement(documentId, "a[class='utils-user-logger btn btn-outline-primary btn-sm js-login analytics-element']").Result;
                    Thread.Sleep(7000);
                    isFound = CDPController.Instance.FindAndClickElement(documentId, "input[id=':r0:-form-item']", 2).Result;
                    Thread.Sleep(1000);
                    CDPMouseController.Instance.InputText(Setting.Instance.Username);
                    Thread.Sleep(1000);
                    isFound = CDPController.Instance.FindAndClickElement(documentId, "input[id='password']", 1).Result;
                    Thread.Sleep(1000);
                    CDPMouseController.Instance.InputText(Setting.Instance.Password);
                    Thread.Sleep(1000);
                    //CDPController.Instance.ExecuteScript($"document.getElementById(':r0:-form-item').value='{Setting.Instance.Username}';");
                    //Thread.Sleep(2000);
                    //CDPController.Instance.ExecuteScript($"document.getElementById('password').value='{Setting.Instance.Password}';");
                    //Thread.Sleep(3000);
                    isFound = CDPController.Instance.FindAndClickElement(documentId, "button[type='submit']").Result;
                    Thread.Sleep(7000);

                    isFound = CDPController.Instance.FindElement(documentId, "i[class='icon icon-user']").Result;
                    if (isFound)
                    {
                        isloggedin = true;
                        break;
                    }
                }


            }
            catch (Exception ex)
            {
                Global.WrittingLog("In login side error:" + ex.Message);
                isloggedin = false;
            }


            return isloggedin;
        }

        public List<CombinationBodyarray> setAttribute()
        {
            CombinationList = new List<CombinationBodyarray>();
            try
            {
                if (Setting.Instance.Sport == "Soccer" && Setting.Instance.Outcome == "1/2")
                {
                    Setting.Instance.marketTypeId = "3";
                    Setting.Instance.marketAttributeId = "0";
                }
                else if (Setting.Instance.Sport == "Soccer" && Setting.Instance.Outcome == "Even/Odd")
                {
                    Setting.Instance.marketTypeId = "19";
                    Setting.Instance.marketAttributeId = "0";
                }
                else if (Setting.Instance.Sport == "Soccer" && Setting.Instance.Outcome.Contains("Under/Over/"))
                {
                    Setting.Instance.marketTypeId = "7989";
                    Setting.Instance.marketAttributeId = Convert.ToString(ExtractDecimalValue(Setting.Instance.Outcome) * 100);
                }
                else if (Setting.Instance.Sport == "Basketball" && Setting.Instance.Outcome == "1/2")
                {
                    Setting.Instance.marketTypeId = "110";
                    Setting.Instance.marketAttributeId = "0";
                }
                else if (Setting.Instance.Sport == "Basketball" && Setting.Instance.Outcome == "Even/Odd")
                {
                    Setting.Instance.marketTypeId = "191";
                    Setting.Instance.marketAttributeId = "0";
                }
                else if (Setting.Instance.Sport == "Basketball" && Setting.Instance.Outcome.Contains("Under/Over/"))
                {
                    Setting.Instance.marketTypeId = "14863";
                    Setting.Instance.marketAttributeId = Convert.ToString(ExtractDecimalValue(Setting.Instance.Outcome) * 100);
                }
                else if (Setting.Instance.Sport == "Volleyball" && Setting.Instance.Outcome == "1/2")
                {
                    Setting.Instance.marketTypeId = "2";
                    Setting.Instance.marketAttributeId = "0";
                }
                else if (Setting.Instance.Sport == "Volleyball" && Setting.Instance.Outcome == "Even/Odd")
                {
                    Setting.Instance.marketTypeId = "17732";
                    Setting.Instance.marketAttributeId = "1";
                }
                else if (Setting.Instance.Sport == "Volleyball" && Setting.Instance.Outcome.Contains("Under/Over/"))
                {
                    Setting.Instance.marketTypeId = "8344";
                    Setting.Instance.marketAttributeId = Convert.ToString(ExtractDecimalValue(Setting.Instance.Outcome) * 100);
                }
                else if (Setting.Instance.Sport == "PingPong" && Setting.Instance.Outcome == "1/2")
                {
                    Setting.Instance.marketTypeId = "2";
                    Setting.Instance.marketAttributeId = "0";
                }
                string M1 = Setting.Instance.Match1;
                string M2 = Setting.Instance.Match2;
                string M3 = Setting.Instance.Match3;
                string M4 = Setting.Instance.Match4;
                string M5 = Setting.Instance.Match5;
                string eventID1 = GetEventIdByTitle(Setting.Instance.EventIdsResult.ToString(), M1).ToString();
                string eventID2 = GetEventIdByTitle(Setting.Instance.EventIdsResult.ToString(), M2).ToString();
                string eventID3 = GetEventIdByTitle(Setting.Instance.EventIdsResult.ToString(), M3).ToString();
                string eventID4 = GetEventIdByTitle(Setting.Instance.EventIdsResult.ToString(), M4).ToString();
                string eventID5 = GetEventIdByTitle(Setting.Instance.EventIdsResult.ToString(), M5).ToString();
                if (eventID1 == "-1" || eventID2 == "-1" || eventID3 == "-1" || eventID4 == "-1" || eventID5 == "-1")
                {
                    if (eventID1 == "-1")
                    {
                        Global.WrittingLog("EventID1 is not found. Please input matchName1 correctly.");
                    }
                    else
                    if (eventID2 == "-1")
                    {
                        Global.WrittingLog("EventID2 is not found. Please input matchName2 correctly.");
                    }
                    else
                    if (eventID3 == "-1")
                    {
                        Global.WrittingLog("EventID3 is not found. Please input matchName3 correctly.");
                    }
                    else if (eventID4 == "-1")
                    {
                        Global.WrittingLog("EventID4 is not found. Please input matchName4 correctly.");
                    }
                    else if (eventID5 == "-1")
                    {
                        Global.WrittingLog("EventID5 is not found. Please input matchName5 correctly.");
                    }
                    return null;
                }
                if (Setting.Instance.Sport == "Soccer" && Setting.Instance.Outcome == "1/2") { 
                
                    int[] elements = { 1, 3 }; // Available numbers
                    int length = 5; // Length of each combination

                    List<int[]> results = new List<int[]>();
                    GenerateCombinations(elements, new int[length], 0, results);

                    // Print the results
                    foreach (var combination in results)
                    {
                        string combinationString = string.Join(",", combination);
                        string[] parts = combinationString.Split(',');

                        // Assign the values to five separate variables
                        string var1 = parts[0];
                        string var2 = parts[1];
                        string var3 = parts[2];
                        string var4 = parts[3];
                        string var5 = parts[4];
                        string bodyArray = $"[[{{\"eventId\":{eventID1},\"marketTypeId\":{Setting.Instance.marketTypeId},\"selectionType\":{var1},\"marketAttributeId\":{Setting.Instance.marketAttributeId}}}," +
                    $"{{\"eventId\":{eventID2},\"marketTypeId\":{Setting.Instance.marketTypeId},\"selectionType\":{var2},\"marketAttributeId\":{Setting.Instance.marketAttributeId}}}," +
                    $"{{\"eventId\":{eventID3},\"marketTypeId\":{Setting.Instance.marketTypeId},\"selectionType\":{var3},\"marketAttributeId\":{Setting.Instance.marketAttributeId}}}," +
                    $"{{\"eventId\":{eventID4},\"marketTypeId\":{Setting.Instance.marketTypeId},\"selectionType\":{var4},\"marketAttributeId\":{Setting.Instance.marketAttributeId}}}," +
                    $"{{\"eventId\":{eventID5},\"marketTypeId\":{Setting.Instance.marketTypeId},\"selectionType\":{var5},\"marketAttributeId\":{Setting.Instance.marketAttributeId}}}]]";
                        CombinationBodyarray combinationBodyarray = new CombinationBodyarray();
                        combinationBodyarray.BodyArray = bodyArray;
                        CombinationList.Add(combinationBodyarray);
                    }

                } 
                else 
                {
                    int[] elements = { 1, 2 }; // Available numbers
                    int length = 5; // Length of each combination

                    List<int[]> results = new List<int[]>();
                    GenerateCombinations(elements, new int[length], 0, results);

                    // Print the results
                    foreach (var combination in results)
                    {
                        string combinationString = string.Join(",", combination);
                        string[] parts = combinationString.Split(',');

                        // Assign the values to five separate variables
                        string var1 = parts[0];
                        string var2 = parts[1];
                        string var3 = parts[2];
                        string var4 = parts[3];
                        string var5 = parts[4];
                        string bodyArray = $"[[{{\"eventId\":{eventID1},\"marketTypeId\":{Setting.Instance.marketTypeId},\"selectionType\":{var1},\"marketAttributeId\":{Setting.Instance.marketAttributeId}}}," +
                    $"{{\"eventId\":{eventID2},\"marketTypeId\":{Setting.Instance.marketTypeId},\"selectionType\":{var2},\"marketAttributeId\":{Setting.Instance.marketAttributeId}}}," +
                    $"{{\"eventId\":{eventID3},\"marketTypeId\":{Setting.Instance.marketTypeId},\"selectionType\":{var3},\"marketAttributeId\":{Setting.Instance.marketAttributeId}}}," +
                    $"{{\"eventId\":{eventID4},\"marketTypeId\":{Setting.Instance.marketTypeId},\"selectionType\":{var4},\"marketAttributeId\":{Setting.Instance.marketAttributeId}}}," +
                    $"{{\"eventId\":{eventID5},\"marketTypeId\":{Setting.Instance.marketTypeId},\"selectionType\":{var5},\"marketAttributeId\":{Setting.Instance.marketAttributeId}}}]]";
                        CombinationBodyarray combinationBodyarray = new CombinationBodyarray();
                        combinationBodyarray.BodyArray = bodyArray;
                        CombinationList.Add(combinationBodyarray);
                    }
                }
                Global.WrittingLog(CombinationList.Count.ToString() + "Combinations is lodead.");
                if (CombinationList.Count != 32)
                {
                    Global.WrittingLog("CombinationList is less than 32");
                } else if(CombinationList.Count == 0)
                {
                    Global.WrittingLog("CombinationList is empty");
                    return null;
                }
            }
            catch(Exception ex)
            {
                Global.WrittingLog("In setAttribute side error:" + ex.Message);
                return null;
            }
            return CombinationList;
        }

        static int GetEventIdByTitle(string json, string title)
        {
            JArray events = JArray.Parse(json);
            var match = events.FirstOrDefault(e => e["eventTitle"]?.ToString() == title);
            return match != null ? (int)match["eventId"] : -1; // Return -1 if not found
        }

        static double ExtractDecimalValue(string input)
        {
            Match match = Regex.Match(input, @"[+-]?\d+(\.\d+)?");
            return match.Success ? double.Parse(match.Value) : 0.0;
        }

        static void GenerateCombinations(int[] elements, int[] current, int index, List<int[]> results)
        {
            if (index == current.Length)
            {
                results.Add((int[])current.Clone()); // Store a copy of the array
                return;
            }

            foreach (int num in elements)
            {
                current[index] = num;
                GenerateCombinations(elements, current, index + 1, results);
            }
        }
        public void Prediction(List<CombinationBodyarray> list)
        {
            try
            {
                CDPController.Instance.NavigateInvoke($"https://{domain}/scommesse-matchpoint");
                Thread.Sleep(5000);
                foreach (var item in list)
                {                   
                    
                    Global.WrittingLog("Addbetslip is starting...");
                    string addBetslipURP = "https://betting.sisal.it/api/lettura-palinsesto-sport/palinsesto/common/predictions";
                    string responseData_addBet = "";
                    string bodyArray = item.BodyArray;
                    string cleanedJson = bodyArray.TrimStart('[').TrimEnd(']').TrimEnd('"');
                    cleanedJson = "[" + cleanedJson + "]";
                    JObject addbetJOB = new JObject
                    {
                        ["headers"] = new JObject
                        {
                            ["accept"] = "*/*",
                            ["accept-language"] = "en-US,en;q=0.9",
                            ["content-type"] = "application/json",
                            ["sec-ch-ua"] = "\"Not(A:Brand\";v=\"99\", \"Google Chrome\";v=\"133\", \"Chromium\";v=\"133\"",
                            ["sec-ch-ua-mobile"] = "?0",
                            ["sec-ch-ua-platform"] = "\"Windows\"",
                            ["sec-fetch-dest"] = "empty",
                            ["sec-fetch-mode"] = "cors",
                            ["sec-fetch-site"] = "same-site",
                            ["user_data"] = "{\"accountId\":null,\"token\":null,\"tokenJWT\":null,\"locale\":\"it_IT\",\"loggedIn\":false,\"channel\":62,\"brandId\":175,\"offerId\":0}"
                        },
                        ["referrer"] = $"https://{domain}/",
                        ["referrerPolicy"] = "strict-origin-when-cross-origin",
                        ["body"] = cleanedJson,                        
                        ["method"] = "POST",
                        ["mode"] = "cors",
                        ["credentials"] = "include"
                    };

                    string functionString_addBet = $"var link = ''; fetch(\"{addBetslipURP}\", {addbetJOB}).then(res=>res.json()).then(json=>{{link = json}});";
                    CDPController.Instance.ExecuteScript(functionString_addBet);
                    int count2 = 0;
                    while (count2 < 60)
                    {
                        responseData_addBet = CDPController.Instance.ExecuteScript("JSON.stringify(link)", true, true);
                        if (responseData_addBet.Contains("sportId"))
                            break;
                        Thread.Sleep(100);
                        count2++;
                    }

                    if (string.IsNullOrEmpty(responseData_addBet))
                    {
                        Global.WrittingLog("placebetStep1 no response");
                        continue;

                    }
                    dynamic jsonAddbet = JsonConvert.DeserializeObject<dynamic>(responseData_addBet);
                    JObject Cookie = SaveDocumentCookie();
                    string jwtToken = Cookie["JWT_ar"].ToString();
                    string token_accountCode = Cookie["login_ar"].ToString();
                    string decodedString = Uri.UnescapeDataString(token_accountCode);
                    var extractedValues = new Dictionary<string, string>();
                    var keyValuePairs = decodedString.Split(';');

                    foreach (var pair in keyValuePairs)
                    {
                        var keyValue = pair.Split('=');
                        if (keyValue.Length == 2)
                        {
                            extractedValues[keyValue[0]] = keyValue[1];
                        }
                    }
                    // Extract specific values based on keys
                    string accontCode = extractedValues.ContainsKey("codiceConto") ? extractedValues["codiceConto"] : string.Empty;
                    string token = extractedValues.ContainsKey("token") ? extractedValues["token"] : string.Empty;
                    bool resultPlacebet = placeBet(jsonAddbet, jwtToken, accontCode, token);
                    if (resultPlacebet)
                    {
                        Global.WrittingLog("One Placebet is successed.");
                    }
                    else
                    {
                        Global.WrittingLog("One Placebet is failed.");

                    }



                }


            }
            catch (Exception ex)
            {

            }
        }


        public JObject SaveDocumentCookie()
        {
            try
            {
                var localStorageItems = CDPController.Instance.ExecuteScript("JSON.stringify(document.cookie);", true, true);
                if (!string.IsNullOrEmpty(localStorageItems))
                {
                    var splitCookie = localStorageItems.Split(new[] { "; " }, StringSplitOptions.None);
                    Dictionary<string, string> dictionary = new Dictionary<string, string>();

                    foreach (string item in splitCookie)
                    {
                        string[] splitItem = item.Split('=');
                        if (splitItem.Length > 1)
                        {
                            string value = string.Join("=", splitItem.Skip(1));
                            dictionary[splitItem[0]] = value;
                        }
                    }
                    JObject jsonObject = JObject.FromObject(dictionary);
                    Global.WrittingLog("Loading cookiedata successed.");
                    return jsonObject;

                }
                else
                {
                    Global.WrittingLog("No local storage items found.");
                }
            }
            catch (Exception ex)
            {
                Global.WrittingLog($"SaveLocalStorageToJson exception: {ex.StackTrace} {ex.Message}");
            }
            return null;
        }
        public bool placeBet(JArray jsonAddbet, string jwtToken, string accontCode, string token)
        {
            try
            {
                List<Dictionary<string, object>> jsonData = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonAddbet.ToString());
                long result = jsonData
            .Where(item => item.ContainsKey("odd")) // Ensure "odd" key exists
            .Select(item => Convert.ToInt64(item["odd"])) // Convert to long
            .Aggregate(1L, (x, y) => x * y);
                double payoutAmount_double = Math.Round(result / 10000000000.0 * 1.04 * Convert.ToDouble(Setting.Instance.Stake), 2);
                int payOutAmount = Convert.ToInt32(payoutAmount_double * 100);


                JObject bodyJson = new JObject
                {
                    ["credentials"] = new JObject
                    {
                        ["channelId"] = 62,
                        ["channelType"] = "ONLINE",
                        ["token"] = $"{token}",
                        ["accountCode"] = $"{accontCode}"
                    },
                    ["sportBetSlip"] = new JObject
                    {
                        ["enableNewBindabilityLogic"] = true,
                        ["tradingSegment"] = new JObject
                        {
                            ["offerId"] = 0,
                            ["brandId"] = 175
                        },
                        ["bonusSet"] = new JObject
                        {
                            ["betType"] = "ACCUMULATOR",
                            ["bonus"] = new JArray
                {
                    new JObject
                    {
                        ["bonusType"] = "INCREMENTAL_BONUS",
                        ["bonusParameterList"] = new JArray
                        {
                            new JObject { ["name"] = "MIN_SHARE", ["type"] = "DECIMAL", ["value"] = "1.24" },
                            new JObject { ["name"] = "BONUS_PERCENTAGE", ["type"] = "DECIMAL", ["value"] = "1.04" },
                            new JObject { ["name"] = "DAY_NUM", ["type"] = "INTEGER", ["value"] = "7" },
                            new JObject { ["name"] = "MIN_NUM_EVENT", ["type"] = "INTEGER", ["value"] = "5" }
                        }
                    }
                }
                        },
                        ["stakeAmount"] = Convert.ToInt32(Setting.Instance.Stake) * 100,
                        ["payoutAmount"] = payOutAmount,
                        ["oddsChangeSetting"] = 0,
                        ["variableStakeAmount"] = 0,
                        ["legList"] = jsonAddbet
                    },
                    ["ticketType"] = "ACCUMULATOR"
                };
                string jsonString = JsonConvert.SerializeObject(bodyJson);
                string responseData_PLaceBet = "";
                string PlacebetURL = "https://betting.sisal.it/api/biglietto-common/sell/sellSportBet";
                JObject PlacebetJOB = new JObject
                {
                    ["headers"] = new JObject
                    {
                        ["accept"] = "*/*",
                        ["accept-language"] = "en-US,en;q=0.9",
                        ["content-type"] = "application/json",
                        ["sec-ch-ua"] = "\"Not(A:Brand\";v=\"99\", \"Google Chrome\";v=\"133\", \"Chromium\";v=\"133\"",
                        ["sec-ch-ua-mobile"] = "?0",
                        ["sec-ch-ua-platform"] = "\"Windows\"",
                        ["sec-fetch-dest"] = "empty",
                        ["sec-fetch-mode"] = "cors",
                        ["sec-fetch-site"] = "same-site",
                        ["user_data"] = $"{{\"accountId\":\"{accontCode}\",\"token\":\"{token}\",\"tokenJWT\":\"{jwtToken}\",\"locale\":\"it_IT\",\"loggedIn\":true,\"channel\":62,\"brandId\":175,\"offerId\":0}}"
                    },
                    ["referrer"] = $"https://{domain}/",
                    ["referrerPolicy"] = "strict-origin-when-cross-origin",
                    ["body"] = jsonString,
                    ["method"] = "POST",
                    ["mode"] = "cors",
                    ["credentials"] = "include"
                };
                string functionString_addBet = $"var link = ''; fetch(\"{PlacebetURL}\", {PlacebetJOB}).then(res=>res.json()).then(json=>{{link = json}});";
                CDPController.Instance.ExecuteScript(functionString_addBet);
                int count2 = 0;
                while (count2 < 150)
                {
                    responseData_PLaceBet = CDPController.Instance.ExecuteScript("JSON.stringify(link)", true, true);
                    if (responseData_PLaceBet.Contains("code"))
                        break;
                    Thread.Sleep(100);
                    count2++;
                }

                if (string.IsNullOrEmpty(responseData_PLaceBet))
                {
                    Global.WrittingLog("placebetStep1 no response");                   

                }
                dynamic jsonPlacebet = JsonConvert.DeserializeObject<dynamic>(responseData_PLaceBet);
                if (jsonPlacebet["code"] == 0 && jsonPlacebet["success"] == true)
                {                    
                    return true;
                }
            }
            catch(Exception ex)
            {
                Global.WrittingLog("In placeBet side error:" + ex.Message);
            }
            return false;
        }

        
    }
}
