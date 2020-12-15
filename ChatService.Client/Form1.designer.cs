
namespace ChatService.Client
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ledger = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.users = new System.Windows.Forms.ComboBox();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.callerName = new System.Windows.Forms.TextBox();
            this.text_Button = new System.Windows.Forms.Button();
            this.call_Button = new System.Windows.Forms.Button();
            this.stop_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.port = new System.Windows.Forms.TextBox();
            this.serverName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.start_button = new System.Windows.Forms.Button();
            this.user_button = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ledger);
            this.panel1.Location = new System.Drawing.Point(2, 190);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(382, 333);
            this.panel1.TabIndex = 0;
            // 
            // ladger
            // 
            this.ledger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ledger.Location = new System.Drawing.Point(2, 2);
            this.ledger.Multiline = true;
            this.ledger.Name = "ladger";
            this.ledger.Size = new System.Drawing.Size(378, 329);
            this.ledger.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.user_button);
            this.panel2.Controls.Add(this.users);
            this.panel2.Controls.Add(this.textMessage);
            this.panel2.Controls.Add(this.callerName);
            this.panel2.Controls.Add(this.text_Button);
            this.panel2.Controls.Add(this.call_Button);
            this.panel2.Controls.Add(this.stop_Button);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.userName);
            this.panel2.Controls.Add(this.port);
            this.panel2.Controls.Add(this.serverName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.start_button);
            this.panel2.Location = new System.Drawing.Point(2, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(382, 181);
            this.panel2.TabIndex = 9;
            // 
            // users
            // 
            this.users.FormattingEnabled = true;
            this.users.Location = new System.Drawing.Point(5, 101);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(247, 21);
            this.users.TabIndex = 16;
            this.users.Text = "Выбрать";
            // 
            // textMessage
            // 
            this.textMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textMessage.Location = new System.Drawing.Point(5, 128);
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(248, 20);
            this.textMessage.TabIndex = 15;
            this.textMessage.Text = "Отправить сообщение";
            // 
            // callerName
            // 
            this.callerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.callerName.Enabled = false;
            this.callerName.Location = new System.Drawing.Point(5, 154);
            this.callerName.Name = "callerName";
            this.callerName.Size = new System.Drawing.Size(248, 20);
            this.callerName.TabIndex = 13;
            this.callerName.Text = "Имя вызывающего";
            // 
            // text_Button
            // 
            this.text_Button.Location = new System.Drawing.Point(273, 127);
            this.text_Button.Name = "text_Button";
            this.text_Button.Size = new System.Drawing.Size(103, 23);
            this.text_Button.TabIndex = 14;
            this.text_Button.Text = "Сообщение";
            this.text_Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.text_Button.UseVisualStyleBackColor = true;
            this.text_Button.Click += new System.EventHandler(this.text_Button_Click);
            // 
            // call_Button
            // 
            this.call_Button.Enabled = false;
            this.call_Button.Location = new System.Drawing.Point(273, 153);
            this.call_Button.Name = "call_Button";
            this.call_Button.Size = new System.Drawing.Size(103, 23);
            this.call_Button.TabIndex = 12;
            this.call_Button.Text = "Принять звонок";
            this.call_Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.call_Button.UseVisualStyleBackColor = true;
            // 
            // stop_Button
            // 
            this.stop_Button.Location = new System.Drawing.Point(273, 52);
            this.stop_Button.Name = "stop_Button";
            this.stop_Button.Size = new System.Drawing.Size(103, 23);
            this.stop_Button.TabIndex = 11;
            this.stop_Button.Text = "Отключиться";
            this.stop_Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.stop_Button.UseVisualStyleBackColor = true;
            this.stop_Button.Click += new System.EventHandler(this.stop_Button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Имя пользователя";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // userName
            // 
            this.userName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userName.Location = new System.Drawing.Point(5, 22);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(151, 20);
            this.userName.TabIndex = 9;
            this.userName.Text = "Пользователь";
            // 
            // port
            // 
            this.port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.port.Location = new System.Drawing.Point(162, 61);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(51, 20);
            this.port.TabIndex = 8;
            this.port.Text = "5000";
            // 
            // serverName
            // 
            this.serverName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverName.Location = new System.Drawing.Point(6, 61);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(151, 20);
            this.serverName.TabIndex = 8;
            this.serverName.Text = "127.0.0.1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Адрес сервера";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Порт";
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(273, 23);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(103, 23);
            this.start_button.TabIndex = 6;
            this.start_button.Text = "Подключиться";
            this.start_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // user_button
            // 
            this.user_button.Location = new System.Drawing.Point(273, 98);
            this.user_button.Name = "user_button";
            this.user_button.Size = new System.Drawing.Size(103, 23);
            this.user_button.TabIndex = 18;
            this.user_button.Text = "Пользователи";
            this.user_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.user_button.UseVisualStyleBackColor = true;
            this.user_button.Click += new System.EventHandler(this.user_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 524);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиент чат сервера";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Button stop_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox userName;
        private System.Windows.Forms.TextBox ledger;
        private System.Windows.Forms.TextBox callerName;
        private System.Windows.Forms.Button call_Button;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.Button text_Button;
        private System.Windows.Forms.ComboBox users;
        private System.Windows.Forms.Button user_button;
    }
}

