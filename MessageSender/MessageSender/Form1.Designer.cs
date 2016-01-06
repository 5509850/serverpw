namespace MessageSender
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_send = new System.Windows.Forms.Button();
            this.tb_msg = new System.Windows.Forms.TextBox();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.rb_token = new System.Windows.Forms.RadioButton();
            this.rb_topic = new System.Windows.Forms.RadioButton();
            this.tb_topic = new System.Windows.Forms.TextBox();
            this.tb_token = new System.Windows.Forms.TextBox();
            this.textBox_senderid = new System.Windows.Forms.TextBox();
            this.textBox_serverAPIkey = new System.Windows.Forms.TextBox();
            this.button_paste = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox_title = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_copy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_send.Location = new System.Drawing.Point(12, 202);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(1144, 23);
            this.btn_send.TabIndex = 0;
            this.btn_send.Text = "Send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // tb_msg
            // 
            this.tb_msg.Location = new System.Drawing.Point(12, 143);
            this.tb_msg.Multiline = true;
            this.tb_msg.Name = "tb_msg";
            this.tb_msg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_msg.Size = new System.Drawing.Size(1144, 53);
            this.tb_msg.TabIndex = 1;
            this.tb_msg.Text = "Message Text";
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(12, 231);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ReadOnly = true;
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(1144, 144);
            this.tb_log.TabIndex = 2;
            // 
            // rb_token
            // 
            this.rb_token.AutoSize = true;
            this.rb_token.Checked = true;
            this.rb_token.Location = new System.Drawing.Point(16, 3);
            this.rb_token.Name = "rb_token";
            this.rb_token.Size = new System.Drawing.Size(56, 17);
            this.rb_token.TabIndex = 3;
            this.rb_token.TabStop = true;
            this.rb_token.Text = "Token";
            this.rb_token.UseVisualStyleBackColor = true;
            // 
            // rb_topic
            // 
            this.rb_topic.AutoSize = true;
            this.rb_topic.Location = new System.Drawing.Point(16, 36);
            this.rb_topic.Name = "rb_topic";
            this.rb_topic.Size = new System.Drawing.Size(52, 17);
            this.rb_topic.TabIndex = 4;
            this.rb_topic.Text = "Topic";
            this.rb_topic.UseVisualStyleBackColor = true;
            // 
            // tb_topic
            // 
            this.tb_topic.Location = new System.Drawing.Point(94, 36);
            this.tb_topic.Name = "tb_topic";
            this.tb_topic.Size = new System.Drawing.Size(213, 20);
            this.tb_topic.TabIndex = 5;
            this.tb_topic.Text = "global";
            // 
            // tb_token
            // 
            this.tb_token.Location = new System.Drawing.Point(76, 3);
            this.tb_token.Name = "tb_token";
            this.tb_token.Size = new System.Drawing.Size(1021, 20);
            this.tb_token.TabIndex = 6;
            // 
            // textBox_senderid
            // 
            this.textBox_senderid.Location = new System.Drawing.Point(12, 69);
            this.textBox_senderid.Name = "textBox_senderid";
            this.textBox_senderid.Size = new System.Drawing.Size(276, 20);
            this.textBox_senderid.TabIndex = 7;
            this.textBox_senderid.Enter += new System.EventHandler(this.textBox_senderid_Enter);
            this.textBox_senderid.MouseHover += new System.EventHandler(this.textBox_senderid_MouseHover);
            // 
            // textBox_serverAPIkey
            // 
            this.textBox_serverAPIkey.Location = new System.Drawing.Point(294, 69);
            this.textBox_serverAPIkey.Name = "textBox_serverAPIkey";
            this.textBox_serverAPIkey.Size = new System.Drawing.Size(862, 20);
            this.textBox_serverAPIkey.TabIndex = 8;
            this.textBox_serverAPIkey.Enter += new System.EventHandler(this.textBox_serverIPkey_Enter);
            this.textBox_serverAPIkey.MouseHover += new System.EventHandler(this.textBox_serverIPkey_MouseHover);
            // 
            // button_paste
            // 
            this.button_paste.Location = new System.Drawing.Point(1103, 1);
            this.button_paste.Name = "button_paste";
            this.button_paste.Size = new System.Drawing.Size(53, 23);
            this.button_paste.TabIndex = 9;
            this.button_paste.Text = "Paste";
            this.button_paste.UseVisualStyleBackColor = true;
            this.button_paste.Click += new System.EventHandler(this.button_paste_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 231);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1140, 23);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Value = 99;
            this.progressBar1.Visible = false;
            // 
            // textBox_title
            // 
            this.textBox_title.Location = new System.Drawing.Point(60, 110);
            this.textBox_title.Name = "textBox_title";
            this.textBox_title.Size = new System.Drawing.Size(100, 20);
            this.textBox_title.TabIndex = 11;
            this.textBox_title.Text = "from GCM";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Title";
            // 
            // button_copy
            // 
            this.button_copy.Location = new System.Drawing.Point(1103, 30);
            this.button_copy.Name = "button_copy";
            this.button_copy.Size = new System.Drawing.Size(53, 23);
            this.button_copy.TabIndex = 13;
            this.button_copy.Text = "copy";
            this.button_copy.UseVisualStyleBackColor = true;
            this.button_copy.Click += new System.EventHandler(this.button_copy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 387);
            this.Controls.Add(this.button_copy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_title);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_paste);
            this.Controls.Add(this.textBox_serverAPIkey);
            this.Controls.Add(this.textBox_senderid);
            this.Controls.Add(this.tb_token);
            this.Controls.Add(this.tb_topic);
            this.Controls.Add(this.rb_topic);
            this.Controls.Add(this.rb_token);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.tb_msg);
            this.Controls.Add(this.btn_send);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageSender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox tb_msg;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.RadioButton rb_token;
        private System.Windows.Forms.RadioButton rb_topic;
        private System.Windows.Forms.TextBox tb_topic;
        private System.Windows.Forms.TextBox tb_token;
        private System.Windows.Forms.TextBox textBox_senderid;
        private System.Windows.Forms.TextBox textBox_serverAPIkey;
        private System.Windows.Forms.Button button_paste;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox_title;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_copy;
    }
}

