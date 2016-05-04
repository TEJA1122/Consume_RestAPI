using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consume_RestAPI
{
    public partial class TestingAPI : System.Web.UI.Page
    {
        private const string BASE_ENDPOINT = "https://api-sandbox.nationalcrimecheck.com.au/v1.0/";
        private const string Key = "y8TnfNQGrj4VQZymZf9J0IlsLijo6Kgu";
        private const string Secret = "IcqHhocypOFJ5ZuWiNbmubyr6nMz6CPE";

        private const string keyText = "y8TnfNQGrj4VQZymZf9J0IlsLijo6Kgu:IcqHhocypOFJ5ZuWiNbmubyr6nMz6CPE";
        public static string Base64Encode(string keyText)
        {
            
            var keyTextBytes = System.Text.Encoding.UTF8.GetBytes(keyText);
            return System.Convert.ToBase64String(keyTextBytes);
        }

        public string base64keyText = Base64Encode("y8TnfNQGrj4VQZymZf9J0IlsLijo6Kgu:IcqHhocypOFJ5ZuWiNbmubyr6nMz6CPE");

        private const string authorizationKey = "Basic " + base64keyText;  // End of Key converstion 

        private const string DATA = @"{""object"":
                                                  {""name"":""Name""}
                                      }";


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TestingAPI.CreateRequest();
            //           Key
            //y8TnfNQGrj4VQZymZf9J0IlsLijo6Kgu 

            //Secret
            //IcqHhocypOFJ5ZuWiNbmubyr6nMz6CPE

        }

        private static void CreateRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(BASE_ENDPOINT);
            request.Headers.Add("Authorization", authorizationKey);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = DATA.Length;
            StreamWriter requestWriter = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            requestWriter.Write(DATA);
            requestWriter.Close();

            try
            {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
                Console.Out.WriteLine(response);
                responseReader.Close();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("-----------------");
                Console.Out.WriteLine(e.Message);
            }

        }

    }
}