using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json.Linq;

namespace MessageSender
{
    public partial class Form1 : Form
    {
        //StringBuilder sb = new System.Text.StringBuilder();
        String responce = String.Empty;
        public Form1()
        {
            InitializeComponent();
            textBox_senderid.Text = Properties.Settings.Default.SenderID;
            textBox_serverAPIkey.Text = Properties.Settings.Default.ServerAPIKey;  
            
        }
        

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox_serverAPIkey.Text) || String.IsNullOrEmpty(tb_token.Text))
            {
                if (rb_token.Checked)
                {
                    MessageBox.Show("enter API key or Token", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            progressBar1.Visible = true;
            var jGcmData = new JObject();
            var jData = new JObject();

            jData.Add("message", tb_msg.Text);
            jData.Add("contentTitle", textBox_title.Text);
            if (rb_topic.Checked)
            {
                jGcmData.Add("to", String.Format("/topics/{0}", tb_topic.Text));
            }
            else            
            {
                jGcmData.Add("to", tb_token.Text);
            }
           
            jGcmData.Add("data", jData);

            var url = new Uri("https://gcm-http.googleapis.com/gcm/send");
            try
            {
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    client.DefaultRequestHeaders.TryAddWithoutValidation(
                        "Authorization", "key=" + textBox_serverAPIkey.Text);

                   var result = client.PostAsync(url, new StringContent(jGcmData.ToString(), Encoding.Default, "application/json")).Result;
                   responce = result.Content.ReadAsStringAsync().Result;                                          
                }                  
                AddLog(responce);
            }
            catch (Exception ex)
            {
                AddLog("Unable to send GCM message:");
                AddLog(ex.StackTrace);
            }
            progressBar1.Visible = false;
        }

        void AddLog(string text)
        {
            string newtext = DateTime.Now.ToString("dd/MM/yy H:mm:ss");   
            newtext += @"
";
            newtext += text;
            newtext += @"
";
            newtext +=  tb_log.Text;
            tb_log.Text = newtext;
            
        }

        private void textBox_senderid_Enter(object sender, System.EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 3000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("Sender ID:", TB, 0, 0, VisibleTime);
        }

        private void textBox_serverIPkey_Enter(object sender, System.EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 3000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("Server API Key:", TB, 0, 0, VisibleTime);
        }

        private void textBox_senderid_MouseHover(object sender, System.EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 1000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("Sender ID:", TB, 0, 0, VisibleTime);
        }

        private void textBox_serverIPkey_MouseHover(object sender, System.EventArgs e)
        {
            TextBox TB = (TextBox)sender;
            int VisibleTime = 3000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.Show("Server API Key:", TB, 0, 0, VisibleTime);
        }

        private void button_paste_Click(object sender, System.EventArgs e)
        {
          tb_token.Text = Clipboard.GetText();
            
        }

        private void button_copy_Click(object sender, System.EventArgs e)
        {
            Clipboard.SetText(tb_token.Text);
        }
    }
}
