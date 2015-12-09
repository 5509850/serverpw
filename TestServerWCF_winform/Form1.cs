using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestServerWCF_winform.ServiceReference1; //local
//using TestServerWCF_winform.ServiceReference2; //s.lena.pw

namespace TestServerWCF_winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();

            String data = Registration();
            

            //http://habrahabr.ru/post/210760/
            //gethash
            string hash = Utils.GetHashString(data);
            textBox1.Text = client.GetData(data, hash);
            client.Close();
        }

        private string Registration()
        {
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
