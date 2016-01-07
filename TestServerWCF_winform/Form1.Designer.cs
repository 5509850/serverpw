namespace TestServerWCF_winform
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_Result = new System.Windows.Forms.TextBox();
            this.textBox_email = new System.Windows.Forms.TextBox();
            this.textBox_pwd = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_hostname = new System.Windows.Forms.TextBox();
            this.button_master_ok = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_codeB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_codeA = new System.Windows.Forms.TextBox();
            this.button_addhost = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button_paste = new System.Windows.Forms.Button();
            this.textBox_token = new System.Windows.Forms.TextBox();
            this.button_host_ok = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Bhost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Ahost = new System.Windows.Forms.TextBox();
            this.button_confirmation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(836, 88);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(135, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "Sign UP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_Result
            // 
            this.textBox_Result.Location = new System.Drawing.Point(12, 269);
            this.textBox_Result.Multiline = true;
            this.textBox_Result.Name = "textBox_Result";
            this.textBox_Result.Size = new System.Drawing.Size(836, 39);
            this.textBox_Result.TabIndex = 2;
            // 
            // textBox_email
            // 
            this.textBox_email.Location = new System.Drawing.Point(6, 19);
            this.textBox_email.Name = "textBox_email";
            this.textBox_email.Size = new System.Drawing.Size(100, 20);
            this.textBox_email.TabIndex = 5;
            this.textBox_email.Tag = "email";
            this.textBox_email.Text = "mail@tut.by";
            // 
            // textBox_pwd
            // 
            this.textBox_pwd.Location = new System.Drawing.Point(6, 45);
            this.textBox_pwd.Name = "textBox_pwd";
            this.textBox_pwd.Size = new System.Drawing.Size(100, 20);
            this.textBox_pwd.TabIndex = 6;
            this.textBox_pwd.Tag = "pass";
            this.textBox_pwd.Text = "pass";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(135, 19);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(100, 20);
            this.textBox_name.TabIndex = 7;
            this.textBox_name.Text = "WebClient1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 8;
            this.button2.Text = "Sign IN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_email);
            this.groupBox1.Controls.Add(this.textBox_name);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.textBox_pwd);
            this.groupBox1.Location = new System.Drawing.Point(12, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 113);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sing In/Up";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox_hostname);
            this.groupBox2.Controls.Add(this.button_master_ok);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_codeB);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox_codeA);
            this.groupBox2.Controls.Add(this.button_addhost);
            this.groupBox2.Location = new System.Drawing.Point(283, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(252, 112);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "MASTER";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(88, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "имя хоста";
            // 
            // textBox_hostname
            // 
            this.textBox_hostname.Location = new System.Drawing.Point(152, 17);
            this.textBox_hostname.Name = "textBox_hostname";
            this.textBox_hostname.Size = new System.Drawing.Size(76, 20);
            this.textBox_hostname.TabIndex = 7;
            this.textBox_hostname.Text = "host 1";
            // 
            // button_master_ok
            // 
            this.button_master_ok.Enabled = false;
            this.button_master_ok.Location = new System.Drawing.Point(201, 83);
            this.button_master_ok.Name = "button_master_ok";
            this.button_master_ok.Size = new System.Drawing.Size(45, 23);
            this.button_master_ok.TabIndex = 6;
            this.button_master_ok.Text = "3 OK";
            this.button_master_ok.UseVisualStyleBackColor = true;
            this.button_master_ok.Click += new System.EventHandler(this.button_master_ok_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "code B";
            // 
            // textBox_codeB
            // 
            this.textBox_codeB.Location = new System.Drawing.Point(52, 84);
            this.textBox_codeB.Name = "textBox_codeB";
            this.textBox_codeB.Size = new System.Drawing.Size(142, 20);
            this.textBox_codeB.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(50, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Enter it code A on HOST ->";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "code A";
            // 
            // textBox_codeA
            // 
            this.textBox_codeA.Location = new System.Drawing.Point(52, 41);
            this.textBox_codeA.Name = "textBox_codeA";
            this.textBox_codeA.ReadOnly = true;
            this.textBox_codeA.Size = new System.Drawing.Size(176, 20);
            this.textBox_codeA.TabIndex = 1;
            // 
            // button_addhost
            // 
            this.button_addhost.Location = new System.Drawing.Point(6, 15);
            this.button_addhost.Name = "button_addhost";
            this.button_addhost.Size = new System.Drawing.Size(75, 23);
            this.button_addhost.TabIndex = 0;
            this.button_addhost.Text = "1 Add Host";
            this.button_addhost.UseVisualStyleBackColor = true;
            this.button_addhost.Click += new System.EventHandler(this.button_addhost_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_confirmation);
            this.groupBox3.Controls.Add(this.button_paste);
            this.groupBox3.Controls.Add(this.textBox_token);
            this.groupBox3.Controls.Add(this.button_host_ok);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox_Bhost);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox_Ahost);
            this.groupBox3.Location = new System.Drawing.Point(543, 109);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 154);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "HOST";
            // 
            // button_paste
            // 
            this.button_paste.Location = new System.Drawing.Point(28, 129);
            this.button_paste.Name = "button_paste";
            this.button_paste.Size = new System.Drawing.Size(75, 23);
            this.button_paste.TabIndex = 7;
            this.button_paste.Text = "paste token";
            this.button_paste.UseVisualStyleBackColor = true;
            this.button_paste.Click += new System.EventHandler(this.button_paste_Click);
            // 
            // textBox_token
            // 
            this.textBox_token.Location = new System.Drawing.Point(28, 102);
            this.textBox_token.Name = "textBox_token";
            this.textBox_token.Size = new System.Drawing.Size(260, 20);
            this.textBox_token.TabIndex = 6;
            this.textBox_token.Text = "eajmEbsuzfE:APA91bEFnW3VYPt_nS8cvyzSs25yxPUW3YsYdqDAXF9bZxc3pm7fOfNQDnmr5W9N7zhVj" +
    "oZLR61-6KpKg0eY5ZAf6B9jHQfUvFSGfTubPdG0BRZYNZJjYFe6mpokimB8gFBrXKj4UJmt";
            // 
            // button_host_ok
            // 
            this.button_host_ok.Enabled = false;
            this.button_host_ok.Location = new System.Drawing.Point(232, 16);
            this.button_host_ok.Name = "button_host_ok";
            this.button_host_ok.Size = new System.Drawing.Size(56, 23);
            this.button_host_ok.TabIndex = 5;
            this.button_host_ok.Text = "2 OK";
            this.button_host_ok.UseVisualStyleBackColor = true;
            this.button_host_ok.Click += new System.EventHandler(this.button_host_ok_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(81, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "<- Enter it code B on Master";
            // 
            // textBox_Bhost
            // 
            this.textBox_Bhost.Location = new System.Drawing.Point(84, 48);
            this.textBox_Bhost.Name = "textBox_Bhost";
            this.textBox_Bhost.ReadOnly = true;
            this.textBox_Bhost.Size = new System.Drawing.Size(128, 20);
            this.textBox_Bhost.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "code B";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "code A";
            // 
            // textBox_Ahost
            // 
            this.textBox_Ahost.Location = new System.Drawing.Point(84, 16);
            this.textBox_Ahost.Name = "textBox_Ahost";
            this.textBox_Ahost.Size = new System.Drawing.Size(128, 20);
            this.textBox_Ahost.TabIndex = 0;
            this.textBox_Ahost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_host_KeyPress);
            // 
            // button_confirmation
            // 
            this.button_confirmation.Location = new System.Drawing.Point(156, 128);
            this.button_confirmation.Name = "button_confirmation";
            this.button_confirmation.Size = new System.Drawing.Size(132, 23);
            this.button_confirmation.TabIndex = 8;
            this.button_confirmation.Text = "4 confirmation";
            this.button_confirmation.UseVisualStyleBackColor = true;
            this.button_confirmation.Click += new System.EventHandler(this.button_confirmation_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 314);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox_Result);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox_Result;
        private System.Windows.Forms.TextBox textBox_email;
        private System.Windows.Forms.TextBox textBox_pwd;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_codeB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_codeA;
        private System.Windows.Forms.Button button_addhost;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Bhost;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Ahost;
        private System.Windows.Forms.Button button_master_ok;
        private System.Windows.Forms.Button button_host_ok;
        private System.Windows.Forms.TextBox textBox_hostname;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_token;
        private System.Windows.Forms.Button button_paste;
        private System.Windows.Forms.Button button_confirmation;
    }
}

