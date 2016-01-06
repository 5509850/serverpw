/**
 *        __       __               __ 
 *   ____/ /_ ____/ /______ _ ___  / /_
 *  / __  / / ___/ __/ ___/ / __ `/ __/
 * / /_/ / (__  ) / / /  / / /_/ / / 
 * \__,_/_/____/_/ /_/  /_/\__, /_/ 
 *                           / / 
 *                           \/ 
 * http://distriqt.com
 *
 * @file   	SendNotification.aspx.cs
 * @brief  	
 * @author 	Michael Archbold (ma@distriqt.com)
 * @created	Jul 30, 2012
 * @updated	Aug 10, 2012
 */
using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using System.Drawing;

namespace GCMTestServer
{
    public partial class SendNotification : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["token"] != null)
                {
                    tbRegistrationID.Text = Request.Cookies["token"].Value;
                }                    
            }
        }


        /// <summary>
        /// Send a Google Cloud Message. Uses the GCM service and your provided api key.
        /// </summary>
        /// <param name="apiKey"></param>
        /// <param name="postData"></param>
        /// <param name="postDataContentType"></param>
        /// <returns>The response string from the google servers</returns>
        private string SendGCMNotification(string apiKey, string postData, string postDataContentType = "application/json")
        {
            // from here:
            // http://stackoverflow.com/questions/11431261/unauthorized-when-calling-google-gcm
            //
            // original:
            // http://www.codeproject.com/Articles/339162/Android-push-notification-implementation-using-ASP

            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);

            //
            //  MESSAGE CONTENT
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            //
            //  CREATE REQUEST
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
            Request.Method = "POST";
            Request.KeepAlive = false;
            Request.ContentType = postDataContentType;
            Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
            Request.ContentLength = byteArray.Length;
            
            Stream dataStream = Request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
                        
            //
            //  SEND MESSAGE
            try
            {
                WebResponse Response = Request.GetResponse();
                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                {
                    var text = "Unauthorized - need new token";

                }
                else if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    var text = "Response from web service isn't OK";
                }

                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string responseLine = Reader.ReadToEnd();
                Reader.Close();

                return responseLine;
            }
            catch (Exception e)
            {

            }
            return "error";
        }


        public static bool ValidateServerCertificate(
                                                  object sender,
                                                  X509Certificate certificate,
                                                  X509Chain chain,
                                                  SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {

        }

        protected void Button_snd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbRegistrationID.Text))
            {
                Label_result.Text = "Enter token!";
                return;
            }
            else {
                Response.Cookies["token"].Value = tbRegistrationID.Text;               
                Response.Cookies["token"].Expires = DateTime.Now.AddDays(30);
            }
            string BrowserAPIKey = "AIzaSyCx6vxh0Yu41g8WJXJNXEefp315JslHwVE";//"YOUR_BROWSER_API_KEY";

            string message = TextBox_mess.Text;
            string urlText = TextBox1.Text; // "example test GCM";
            string contentTitle = TextBox2.Text; // "content title GCM";
            string postData = "{ \"registration_ids\": [ \""
                + tbRegistrationID.Text + "\" ], \"data\": {\"urlText\":\"" +
                urlText + "\", \"contentTitle\":\"" + 
                contentTitle + "\", \"message\": \"" + 
                message + "\"}}";    
            
            string response = SendGCMNotification(BrowserAPIKey, postData);

            Label_result.Text = response;
        }

       
    }
}