using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public string Outcome { get; set; }
        public string Sport { get; set; }
        public string Match1 { get; set; }
        public string Match2 { get; set; }
        public string Match3 { get; set; }
        public string Match4 { get; set; }
        public string Match5 { get; set; }

        public JArray EventIdsResult { get; set; }
        public string eventId { get; set; }
        public string marketTypeId { get; set; }
        public string selectionType { get; set; }
        public string marketAttributeId { get; set; }   


    }
}
