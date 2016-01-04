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
//using TestServerWCF_winform.ServiceReference1; //local PC
//using TestServerWCF_winform.ServiceReference2; //s.lena.pw
using TestServerWCF_winform.ServiceReference3; // local note

namespace TestServerWCF_winform
{
    public partial class Form1 : Form
    {
        private const int REGISTRATION = 0;
        private const int AUTORIZATION = 1;
        private const int GETCODEA = 2;
        private const int GETCODEB = 3;
        private const int CHECKCODEAB = 4;
        private const int NEW_USER = 0;
        private const int TYPEDEVICE_WebClient = 1;
        private const int TYPEDEVICE_AndroidHost = 5;
        private const int EMPTY_TOKEN = 0;
        private const int EMPTY = 0;

        private const string AUTORISATION_OK = "5";
        private const int DEVICE_ID_idx  = 1;
        private const int CODE_idx = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        //Sign UP
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
//9 - GUID
*/
        }

        private string Login()
        {
            return String.Format("0|{0}|1|{1}|2|{2}|3|{3}|4|{4}|5|{5}|6|{6}|7|{7}|8|{8}",
               AUTORIZATION,//0
               EMPTY,//1
               textBox_email.Text,//2
               Utils.GetHashString(textBox_pwd.Text),//3
               TYPEDEVICE_WebClient,//4
               EMPTY_TOKEN,//5
               GetMACAddress2(),//6
               EMPTY,//7
               GetIP()//8
               );          
        }

        //Sign IN!!!!!!!!!!!!!!!!!!!!!!!!!
        private void button2_Click(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();

            string data = Login();
            string hash = Utils.GetHashString(data);
            /*            {0}|{1}|{2}|{3}  
             * 0 код = 
            1 - не существует логин
            2 - не верный пароль
            3 - заблокирован пользователь
            4 - пользователь удален
            5 - авторизация успешна
             * 
            1=deviceID
            2 = DeviceName
            3=PGP_key (open)
             */

            textBox1.Text = client.GetData(data, hash);
            client.Close();
        }

        private long SignInGetDeviceId()
        {
            Service1Client client = new Service1Client();

            string data = Login();
            string hash = Utils.GetHashString(data);
            /*            {0}|{1}|{2}|{3}  
            
            1=deviceID
            2 = DeviceName
            3=PGP_key (open)
             */

            string Result = textBox1.Text = client.GetData(data, hash);
            client.Close();


            string[] datadic = Result.Split('|');
            if (datadic == null || datadic.Length == 0)
            {
                return 0;
            }

            long deviceID = 0;

            if (datadic.Length > 2 && datadic[CODE_idx].Equals(AUTORISATION_OK))
            {
                Int64.TryParse(datadic[DEVICE_ID_idx], out deviceID);                
            }
            return deviceID;
        }

        //Add Host - get CodeA
        private void button_addhost_Click(object sender, EventArgs e)
        {
            long deviceID = SignInGetDeviceId();
            if (deviceID < 1)
            {
                return;
            }

            Service1Client client = new Service1Client();
            //TODO: !!!!!!!!!!!!!!! textBox_hostname добавить имя хоста!!! textBox_hostname.Text
            string data = String.Format("0|{0}|1|{1}|2|{2}|3|{3}|4|{4}|5|{5}|6|{6}|7|{7}|8|{8}|9|{9}",
               GETCODEA,//0
               EMPTY,//1
               EMPTY,//2
               EMPTY,//3
               EMPTY,//4
               EMPTY,//5
               EMPTY,//6
               EMPTY,//7
               GetIP(),//8
               deviceID//9
               );          

            string hash = Utils.GetHashString(data);
            /*            {0}|{1}|{2}|{3}  
            0 кодA = 
            1 - 0 OK или код ошибки           
             * 
             */

            textBox_codeA.Text = client.GetData(data, hash);
            client.Close();                  

        }

        //HOST - send codeA and get codeB
        private void button_host_ok_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_Ahost.Text) || textBox_Ahost.Text.Length != 6)
            {
                textBox_Ahost.Focus();
                MessageBox.Show("not corrent code A!");
                return;
            }
            try
            {
                Service1Client client = new Service1Client();

                string data = String.Format("0|{0}|1|{1}|2|{2}|3|{3}|4|{4}|5|{5}|6|{6}|7|{7}|8|{8}|9|{9}|10|{10}",
                   GETCODEB,//0
                   EMPTY,//1
                   EMPTY,//2
                   EMPTY,//3
                   TYPEDEVICE_AndroidHost,//4
                   GetToken(),//5
                   GetAndroidID(),//6
                   "AndroidHost 1",//7
                   GetIP(),//8
                   EMPTY,//9
                   textBox_Ahost.Text//10 codeA
                   );

                string hash = Utils.GetHashString(data);

                /*>1 = codeB
                 * -1 = not valid codeA
                 * -2 error
                 * */
                textBox_Bhost.Text =
                    textBox1.Text = client.GetData(data, hash);
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //for test only!!!!
        private string GetAndroidID()
        {
            return "AndroidIDGHRTUYHRTretgy34";
        }

        //for test only!!!!
        private string GetToken()
        {
           return "dfgertgrf%$H$#YHG";
        }

        //check codeA and codeB - if OK - add new deviceID(send push for host deviceID)
        private void button_master_ok_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_codeB.Text) || textBox_codeB.Text.Length != 6)
            {
                MessageBox.Show("not correct code B!");
                textBox_codeB.Focus();
                return;
            }
             try
            {
                Service1Client client = new Service1Client();

                string data = String.Format("0|{0}|1|{1}|2|{2}|3|{3}|4|{4}|5|{5}|6|{6}|7|{7}|8|{8}|9|{9}|10|{10}|11|{11}",
                   CHECKCODEAB,//0
                   EMPTY,//1
                   EMPTY,//2
                   EMPTY,//3
                   EMPTY,//4
                   EMPTY,//5
                   EMPTY,//6
                   EMPTY,//7
                   GetIP(),//8
                   SignInGetDeviceId(),//9 deviceID
                   textBox_codeA.Text,//10 codeA
                   textBox_codeB.Text//11 codeB
                   );

                string hash = Utils.GetHashString(data);

                /*            {0}|{1}  
            0  0 = OK; -1 not valid codeA(not exit) -2 not valid codeB -3 not valid master DeviceID 
            1  Host DeviceID
             * 
             */             
                textBox1.Text = client.GetData(data, hash);
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void textBox_host_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }
    }
}
