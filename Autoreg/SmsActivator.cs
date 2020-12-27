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
        

        public int GetAmountGMailPhoneNumber()
        {
            string response = RequestAPI(new string[] { Constants.ACTIONGETNUMBERSTATUS });
            JObject jObject = JObject.Parse(response);
            return Convert.ToInt32(jObject["go_0"].ToString());
        }

        public double GetBalance()
        {            
            string response = RequestAPI(new string[] { Constants.ACTIONGETBALANCE });
            string[] balance = response.Split(':');
            return Convert.ToDouble(balance[1]);
        }

        public string GetGMailPhoneNumber()
        {
            string response = RequestAPI(new string[] { Constants.ACTIONGETBALANCE });
            string[] phoneNumber = response.Split(':');
            return phoneNumber[2];
        }

        public string RequestAPI(string[] parameters)
        {
            string requestString = Constants.APIURL + Constants.APIKEY;
            for (int i = 0; i < parameters.Length; i++)
            {
                requestString = requestString + parameters[i];
            }
            WebRequest request = WebRequest.Create(requestString);
            request.Method = "POST";
            WebResponse response = request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();            
            return content;
        }
    }
}
