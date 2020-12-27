using System;
using System.Collections.Generic;
using System.Text;

namespace Autoreg
{
    public static class Constants
    {
        public static string APIKEY = "api_key=e04bA4bb0384fc41c6dbAA114d864e18";
        public static string APIURL = "https://sms-activate.ru/stubs/handler_api.php?";
        public static string ACTIONGETNUMBERSTATUS = "action=getNumbersStatus";
        public static string ACTIONGETBALANCE = "action=getBalance";
        public static string ACTIONGETNUMBER = "action=getNumber";
        public static string ACTIONSETSTATUS = "action=setStatus";
        public static string ACTIONGETSTATUS = "action=getStatus";
        public static string STATUSREADY = "status=1";
        public static string STATUSREFRESH = "status=3";
        public static string STATUSFINISH = "status=6";
        public static string STATUSCANCEL = "status=8";
        public static string SERVICEGOOGLE = "service=go";
        public static string COUNTRYRUSSIA = "country=0";
    }
}
