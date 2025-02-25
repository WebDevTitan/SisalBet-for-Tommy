using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SisalBet
{

    public delegate void WriteLogDelegate(string strLog);
    public delegate string RunScript(string code);
    internal class Global
    {
        public static WriteLogDelegate WrittingLog = null;
        public static bool End = false;
        public static CookieContainer cookieContainer = null;
        public static string GTM = "";
        public static RunScript RunScriptCode = null;


    }


}
