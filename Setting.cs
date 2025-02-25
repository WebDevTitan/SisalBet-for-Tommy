using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterDevs.ChromeDevTools.Protocol.Chrome.Security;
using Newtonsoft.Json.Linq;

namespace SisalBet
{
    public class Setting
    {
        private static Setting _instance = null;
        public static Setting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Setting();
                return _instance;
            }
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Stake { get; set; }
        public string Outcome1 { get; set; }
        public string Outcome2 { get; set; }
        public string Outcome3 { get; set; }
        public string Outcome4 { get; set; }
        public string Outcome5 { get; set; }

        public string Sport1 { get; set; }
        public string Sport2 { get; set; }
        public string Sport3 { get; set; }
        public string Sport4 { get; set; }
        public string Sport5 { get; set; }

        public string Match1 { get; set; }
        public string Match2 { get; set; }
        public string Match3 { get; set; }
        public string Match4 { get; set; }
        public string Match5 { get; set; }

        public JArray EventIdsResult { get; set; }
        public string eventId { get; set; }
        public string marketTypeId1 { get; set; }
        
        public string marketAttributeId1 { get; set; }
        public string marketTypeId2 { get; set; }

        public string marketAttributeId2 { get; set; }
        public string marketTypeId3 { get; set; }

        public string marketAttributeId3 { get; set; }
        public string marketTypeId4 { get; set; }

        public string marketAttributeId4 { get; set; }
        public string marketTypeId5 { get; set; }

        public string marketAttributeId5 { get; set; }

        public string selectionType { get; set; }

        public string authrizationID { get; set; }

        public string accoutCode { get; set; }

        public string token { get; set; }
        public string JWTtoken { get; set; }


    }
}
