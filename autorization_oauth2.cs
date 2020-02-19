using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Bearer
{

    public class Bearer
    {
        public string scope { get; set; }
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
        public string access_token { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string consumerKey = "260392633753-18hl37euj7tpdk4pp4c1happd80d2o9t.apps.googleusercontent.com";
            string consumerSecret = "4aQUzmnt-08DpxHP9Cqbi7gS";
            string accessToken;
            
            byte[] byte1 = Encoding.ASCII.GetBytes("grant_type=client_credentials");

            HttpWebRequest bearerReq = WebRequest.Create("AIzaSyDK48i45yKE-OfYiVrsZtdfBzXYP1YyiSI") as HttpWebRequest;
            bearerReq.Accept = "application/json";
            bearerReq.Method = "POST";
            bearerReq.ContentType = "application/x-www-form-urlencoded";
            bearerReq.ContentLength = byte1.Length;
            bearerReq.KeepAlive = false;
            bearerReq.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(consumerKey + ":" + consumerSecret)));
            Stream newStream = bearerReq.GetRequestStream();
            newStream.Write(byte1, 0, byte1.Length);

            WebResponse bearerResp = bearerReq.GetResponse();
            
            using (var reader = new StreamReader(bearerResp.GetResponseStream(), Encoding.UTF8))
            {
                var response = reader.ReadToEnd();
                Bearer bearer = JsonConvert.DeserializeObject<Bearer>(response);
                accessToken = bearer.access_token;
            }

            Console.WriteLine(accessToken);
            Console.Read();
        }
    }
}