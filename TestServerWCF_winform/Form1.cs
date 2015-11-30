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

            int vol = 0;
            Int32.TryParse(textBox3.Text, out vol);
            textBox1.Text = client.GetData(vol);
            client.Close();
        }
    }
}
