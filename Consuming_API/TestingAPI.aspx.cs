using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Consume_RestAPI
{
    public partial class TestingAPI : System.Web.UI.Page
    {
        private const string BASE_ENDPOINT = "https://api-sandbox.nationalcrimecheck.com.au/v1.0/";

        //private const string DATA = @"{""object"":
        //                                          {""name"":""Name""}
        //                              }";

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


            CreateRequest();

            string jsonparse = @"{
                ""client_ref"": ""abcde"",
                ""cost_centre"": ""Marketing"",
                ""first_name"": ""John"",
                ""middle_name"": ""Nathan"",
                ""last_name"": ""Smith"",
                ""single_name"": false,
                ""dob"": ""1976-05-04"",
                ""birth_place"": ""Adelaide"",
                ""birth_state"": ""SA"",
                ""birth_country"": ""AUS"",
                ""sex"": ""M"",
                ""email"": ""john.smith@example.com"",
                ""resid"": {
                            ""street"": ""1 Something street"",
                    ""suburb"": ""Adelaide"",
                    ""state"": ""SA"",
                    ""postcode"": ""5000"",
                    ""years"": 3,
                    ""months"": 2
                },
                ""previous"": [
                    {
                        ""street"": ""1 Another street"",
                        ""suburb"": ""Adelaide"",
                        ""state"": ""SA"",
                        ""postcode"": ""5000"",
                        ""country"": ""AUS"",
                        ""years"": 1,
                        ""months"": 1
                    },
                    {
                        ""street"": ""1 Old avenue"",
                        ""suburb"": ""Adelaide"",
                        ""state"": ""SA"",
                        ""postcode"": ""5000"",
                        ""country"": ""AUS"",
                        ""years"": 3,
                        ""months"": 1
                    }
                ],
                ""type"": ""EMPLOYMENT"",
                ""reason"": ""Computer programmer"",
                ""result_webhook"": ""http://example.com/result""
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
                int resid = Convert.ToInt32(jsonresponse.id.ToString());
                string resurl = jsonresponse.continue_url.ToString();
                Label2.Text = resid.ToString();
                HyperLink1.NavigateUrl = resurl.ToString();

                responseReader.Close();
            }
            catch (Exception ee)
            {
                Console.WriteLine("Error Message: ");
                Console.WriteLine(ee.Message);
            }



        }

        private static void CreateRequest()
        {

            //  string jsonGetText = "{\"id\":1111, \"status\":\"PREP\",\"verify_status\": \"QA\",\"continue_url\": \"http://example.com/continue/11111/AAAAAA\",\"client_ref\": \"abcde\", \"cost_centre\": \"Marketing\", \"first_name\": \"John\", \"middle_name\": \"\", \"last_name\": \"Smith\", \"single_name\": false, \"dob\": \"1976-05-04\",\"sex\": \"M\",\"email\": \"john.smith@example.com\",\"mobile\": \"1111 111 111\",\"type\": \"EMPLOYMENT\",\"reason\": \"Computer programmer\"}";

            //            string jsonPostText = "{\"client_ref\": \"abcde\",\"cost_centre\": \"Marketing\",\"first_name\": \"John\",\"middle_name\": \"Nathan\",\"last_name\": \"Smith\",\"single_name\": false,\"dob\": \"1976-05-04\",\"birth_place\": \"Adelaide\",\"birth_state\": \"SA\",\"birth_country\": \"AUS\",\"sex\": \"M\",\"email\": \"john.smith@example.com\",\"resid\":{\"street\": \"1 Something street\",\"suburb\": \"Adelaide\",\"state\": \"SA\",\"postcode\": \"5000\",\"years\": 3,\"months\": 2\"}",\"previous\": \"[\" \"{\"street\": \"1 Another street\",
            //            "suburb": "Adelaide",
            //            "state": "SA",
            //            "postcode": "5000",
            //            "country": "AUS",
            //            "years": 1,
            //            "months": 1
            //        },
            //        {
            //            "street": "1 Old avenue",
            //            "suburb": "Adelaide",
            //            "state": "SA",
            //            "postcode": "5000",
            //            "country": "AUS",
            //            "years": 3,
            //            "months": 1
            //        }
            //    ],
            //    "type": "EMPLOYMENT",
            //    "reason": "Computer programmer",
            //    "result_webhook": "http://example.com/result"
            //}";



        }

    }
}