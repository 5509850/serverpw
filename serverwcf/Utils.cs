using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace serverwcf
{
    class Utils
    {
        static string apiKey = "AIzaSyCx6vxh0Yu41g8WJXJNXEefp315JslHwVE";//"YOUR_SERVER_API_KEY";    


        public static string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
        public static string TruncateLongString(string str, int maxLength)
        {
            if (String.IsNullOrEmpty(str))
            { return String.Empty; }
             
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }

        public static responseGCM SendGCM(string message, string urlText, string contentTitle, string token)
        {            
              string postData = "{ \"registration_ids\": [ \""
                + token + "\" ], \"data\": {\"urlText\":\"" +
                urlText + "\", \"contentTitle\":\"" +
                contentTitle + "\", \"message\": \"" +
                message + "\"}}";

            return SendGCMNotification(postData);
        }

        private static responseGCM SendGCMNotification(string postData)
        {
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);
            //  MESSAGE CONTENT
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            //  CREATE REQUEST
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
            Request.Method = "POST";
            Request.KeepAlive = false;
            Request.ContentType = "application/json";
            Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
            Request.ContentLength = byteArray.Length;
            Stream dataStream = Request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            responseGCM responce = new responseGCM();
            //  SEND MESSAGE
            try
            {
                WebResponse Response = Request.GetResponse();
                HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
                if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
                {
                    responce.Warningmess = "Unauthorized - need new token";
                }
                else if (!ResponseCode.Equals(HttpStatusCode.OK))
                {
                    responce.Warningmess = "Response from web service isn't OK";
                }
                StreamReader Reader = new StreamReader(Response.GetResponseStream());
                string responseLine = Reader.ReadToEnd();
                Reader.Close();
                responce.ResponseLine = responseLine;
                return responce;
            }
            catch (Exception e)
            {
                responce.Warningmess = e.Message;
            }
            responce.Warningmess = "error";
            return responce;
        }

        public class responseGCM
        {
            private string responseLine;
            private string warningmess;

            public string Warningmess
            {
                get { return warningmess; }
                set { warningmess = value; }
            }

            public string ResponseLine
            {
                get { return responseLine; }
                set { responseLine = value; }
            }
        }

        private static bool ValidateServerCertificate(
                                                  object sender,
                                                  X509Certificate certificate,
                                                  X509Chain chain,
                                                  SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
    }
}
