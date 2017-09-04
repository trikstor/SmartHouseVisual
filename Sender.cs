using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Collections.Specialized;


namespace SmartHouseVisual
{
    /*
    private class Sender
    {
        protected bool SendTo(string URL, object data)
        {
            using (var webClient = new WebClient())
            {
                var pars = new NameValueCollection();
                pars.Add("fname", data);
                var response = webClient.UploadValues(URL, pars);
                string str = System.Text.Encoding.UTF8.GetString(response);
            }
            return true;
        }
    }

    public class ClimatControl : Sender
    {
        public ClimatControl(string URL, int data, string name)
        {
            string request = "Climat[" + name + "]:" + data;
            SendTo(URL, request);
        }

    }

    public class LightingControl : Sender
    {
        public LightingControl(string URL, bool data, string name)
        {
            string request = "Lighting[" + name + "]:" + data;
            SendTo(URL, request);
        }

    }
     */
}
