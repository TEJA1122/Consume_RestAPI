using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consuming_API
{
    public partial class DownloadResult : System.Web.UI.Page
    {
        private const string BASE_ENDPOINT = "https://api-sandbox.nationalcrimecheck.com.au/v1.0/";

        public class RootObject
        {
            public int id { get; set; }
            public string continue_url { get; set; }
            public string status { get; set; }
            public string verify_status { get; set; }
            public string type { get; set; }

        }

        public class JsonErrorObject
        {
            public string error { get; set; }
            public string message { get; set; }


        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //string Key = "y8TnfNQGrj4VQZymZf9J0IlsLijo6Kgu";
            //string Secret = "IcqHhocypOFJ5ZuWiNbmubyr6nMz6CPE";

            string keyText = "y8TnfNQGrj4VQZymZf9J0IlsLijo6Kgu:IcqHhocypOFJ5ZuWiNbmubyr6nMz6CPE";

            var keyTextBytes = System.Text.Encoding.UTF8.GetBytes(keyText);
            string base64Encode = System.Convert.ToBase64String(keyTextBytes);

            string base64keyText = base64Encode;

            string authorizationKey = "Basic " + base64keyText;  // End of Key converstion 
            string create_baseUrl = BASE_ENDPOINT + "checks/" + TextBox1.Text + "/result";
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(create_baseUrl);

            request.Headers.Add("Authorization", authorizationKey);
            request.Method = "GET";

            request.ContentType = "application/json";



            try
            {
                WebResponse webResponse = request.GetResponse();
                using (Stream webStream = webResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            string response = responseReader.ReadToEnd();
                            byte[] byteResponse = Encoding.UTF8.GetBytes(response);
                            Response.Clear();
                            Response.Buffer = true;
                            Response.ContentType = "application/pdf";
                            Response.AddHeader("content-disposition", "attachment;filename=test.pdf"); // Save file         
                            Response.AddHeader("Content-Length", byteResponse.Length.ToString());
                            Response.Charset = "";
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.BinaryWrite(byteResponse);
                            Response.End();
                        }
                    }
                }
            }
            catch (Exception ee)
            {
               
                Label1.Text = "Error Message @C2: " + ee.Message.ToString();
            }
        }
    }
}