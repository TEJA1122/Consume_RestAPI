using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consuming_API
{
    public partial class WebhookCalls : System.Web.UI.Page
    {
        private const string BASE_ENDPOINT = "https://api-sandbox.nationalcrimecheck.com.au/v1.0/";


        public class RootObject
        {
            public int id { get; set; }
            public string continue_url { get; set; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            string jsonparse = @"{
                ""id"": ""11111""
                ""client_ref"": ""abcde"",
                ""result_url"": ""http:\/\/www.example.com\/result\/11111""
            }";

            string DATA = jsonparse;

            //string Key = "y8TnfNQGrj4VQZymZf9J0IlsLijo6Kgu";
            //string Secret = "IcqHhocypOFJ5ZuWiNbmubyr6nMz6CPE";

            string keyText = "y8TnfNQGrj4VQZymZf9J0IlsLijo6Kgu:IcqHhocypOFJ5ZuWiNbmubyr6nMz6CPE";

            var keyTextBytes = System.Text.Encoding.UTF8.GetBytes(keyText);
            string base64Encode = System.Convert.ToBase64String(keyTextBytes);

            string base64keyText = base64Encode;

            string authorizationKey = "Basic " + base64keyText;  // End of Key converstion 
            string create_baseUrl = BASE_ENDPOINT + "checks/create";
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(create_baseUrl);

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
                Console.WriteLine(response);

                RootObject jsonresponse = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<RootObject>(response);
                //int resid = Convert.ToInt32(jsonresponse.id.ToString());
                //string resurl = jsonresponse.continue_url.ToString();
                //Label2.Text = resid.ToString();
                //HyperLink1.NavigateUrl = resurl.ToString();

                responseReader.Close();
            }
            catch (Exception ee)
            {
                Console.WriteLine("Error Message: ");
                Console.WriteLine(ee.Message);
            }



        }
    }
}