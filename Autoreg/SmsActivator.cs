using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Autoreg
{
    public class SmsActivator
    {
        private string _apiKey = "e04bA4bb0384fc41c6dbAA114d864e18";
        private string _api = "https://sms-activate.ru/stubs/handler_api.php?";
        private string _action = "getNumbersStatus";

        public string GetPhoneNumber()
        {
            WebRequest request = WebRequest.Create(_api + "api_key=" + _apiKey + "&action=" + _action);
            request.Method = "POST";
            WebResponse response = request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return content;
        }
    }
}
