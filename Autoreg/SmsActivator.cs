using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Autoreg
{
    public class SmsActivator
    {
        

        public string GetPhoneNumber()
        {
            WebRequest request = WebRequest.Create(Constants.APIURL  + Constants.APIKEY + "&" + Constants.ACTIONGETNUMBERSTATUS);
            request.Method = "POST";
            WebResponse response = request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return content;
        }

        public double GetBalance()
        {            
            string response = RequestAPI(Constants.ACTIONGETBALANCE);
            string[] balance = response.Split(':');
            return Convert.ToDouble(balance[1]);
        }

        public string RequestAPI(string action)
        {
            WebRequest request = WebRequest.Create(Constants.APIURL + Constants.APIKEY + "&" + action);
            request.Method = "POST";
            WebResponse response = request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();            
            return content;
        }
    }
}
