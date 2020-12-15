
namespace ChatService.Server
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
            this.textBoxMessages = new System.Windows.Forms.TextBox();
            this.interfaces = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.start_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.stop_server_button = new System.Windows.Forms.Button();
            this.serverName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxMessages);
            this.panel1.Location = new System.Drawing.Point(1, 139);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(351, 306);
            this.panel1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBoxMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMessages.Location = new System.Drawing.Point(2, 2);
            this.textBoxMessages.Multiline = true;
            this.textBoxMessages.Name = "textBox1";
            this.textBoxMessages.Size = new System.Drawing.Size(347, 302);
            this.textBoxMessages.TabIndex = 0;
            // 
            // interfaces
            // 
            this.interfaces.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.interfaces.FormattingEnabled = true;
            this.interfaces.Location = new System.Drawing.Point(8, 29);
            this.interfaces.Name = "interfaces";
            this.interfaces.Size = new System.Drawing.Size(273, 21);
            this.interfaces.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Сетевой интерфейс";
            // 
            // port
            // 
            this.port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.port.Location = new System.Drawing.Point(287, 30);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(51, 20);
            this.port.TabIndex = 3;
            this.port.Text = "5000";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Порт";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Журнал";
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(166, 61);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(80, 23);
            this.start_button.TabIndex = 6;
            this.start_button.Text = "Start server";
            this.start_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.stop_server_button);
            this.panel2.Controls.Add(this.serverName);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.start_button);
            this.panel2.Location = new System.Drawing.Point(4, 6);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(346, 109);
            this.panel2.TabIndex = 7;
            // 
            // stop_server_button
            // 
            this.stop_server_button.Location = new System.Drawing.Point(252, 61);
            this.stop_server_button.Name = "stop_server_button";
            this.stop_server_button.Size = new System.Drawing.Size(80, 23);
            this.stop_server_button.TabIndex = 9;
            this.stop_server_button.Text = "Stop server";
            this.stop_server_button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.stop_server_button.UseVisualStyleBackColor = true;
            this.stop_server_button.Click += new System.EventHandler(this.stop_button_Click);
            // 
            // serverName
            // 
            this.serverName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverName.Location = new System.Drawing.Point(3, 64);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(151, 20);
            this.serverName.TabIndex = 8;
            this.serverName.Text = "Сервер 1";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Имя сервера";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 446);
            this.Controls.Add(this.port);
            this.Controls.Add(this.interfaces);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чат сервер";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxMessages;
        private System.Windows.Forms.ComboBox interfaces;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button stop_server_button;
    }
}

