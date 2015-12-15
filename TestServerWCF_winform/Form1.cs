using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation; //local
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestServerWCF_winform.ServiceReference1;
//using TestServerWCF_winform.ServiceReference2; //s.lena.pw

namespace TestServerWCF_winform
{
    public partial class Form1 : Form
    {
        private const int REGISTRATION = 0;
        private const int NEW_USER = 0;
        private const int TYPEDEVICE_WebClient = 1;
        private const int EMPTY_TOKEN = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();

            string data = Registration();
            

            //http://habrahabr.ru/post/210760/
            //gethash
            string hash = Utils.GetHashString(data);
            textBox1.Text = client.GetData(data, hash);
            client.Close();
        }

        public static string GetMACAddress2()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)// only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            } return sMacAddress;
        }

        private static string GetIP()
        {
            string host = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostEntry(host);
            string ipaddress = ip.AddressList[0].ToString();
            if (String.IsNullOrEmpty(ipaddress))
            {
                return "0.0.0.0";
            }
            return ipaddress;
        }



        private string Registration()
        {
            return String.Format("0|{0}|1|{1}|2|{2}|3|{3}|4|{4}|5|{5}|6|{6}|7|{7}|8|{8}",
               REGISTRATION,//0
               NEW_USER,//1
               textBox_email.Text,//2
               Utils.GetHashString(textBox_pwd.Text),//3
               TYPEDEVICE_WebClient,//4
               EMPTY_TOKEN,//5
               GetMACAddress2(),//6
               textBox_name.Text,//7
               GetIP()//8
               );
            /*|0|-|1|-|2|-|3|-|4|-|5|-|6|-|7|-|8|-|
0 - typedata (0 - регистрация, 1 авторизация)
1 -  userID (0 - новый)
2 - email
3 - pwd - hash
4 - TypeDeviceID
5 - Token
6 - AndroidID/MacAddress
7 - Name (device)
8 - ip address login
*/
        }
    }
}
