using ChatService.Client.Client;
using ChatService.Shared.Messages;
using ChatService.Shared.Models;
using ChatService.Shared.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChatService.Client
{
    public partial class Form1 : Form
    {

        readonly ChatClient _client;

        public Form1()
        {
            InitializeComponent();

             _client = new ChatClient(new DisplayMessageService(DisplayMessage));
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
             
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            if (_client.IsActive) return;

            _client.Start(new ConnectionInfo(userName.Text, serverName.Text, int.Parse(port.Text)));
        }


        private void DisplayMessage(MessageInfo message)
        {

            string msg = $"{DateTime.Now:G} ";

            if (message.Type == MessageType.Connect)
                msg += $"Соединение установлено {message.Info}\r\n";

            if (message.Type == MessageType.Disconnect)
                msg += $"Соединение прервано {message.Info}\r\n";

            if (message.Type == MessageType.Text || message.Type == MessageType.Feedback)
                msg += $"{message.Info}\r\n";

            if (message.Type == MessageType.List)
            {
                Invoke(new Action<MessageInfo>((MessageInfo info) => 
                {
                    users.DataSource = new List<string>(info.Info.Split(';'));

                }), message);

                return;
            }
            //marshal message to UI thread
            if (message.Type == MessageType.Error)
            {
                Invoke(new Action<string>(DisplayError), message.Info);
            }
            else
            {
                Invoke(new Action<string>(ledger.AppendText), msg);
            }

        }

        private void DisplayError(string error)
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK);
        }

        private void stop_Button_Click(object sender, EventArgs e)
        {
            _client.Stop();
        }

        private void text_Button_Click(object sender, EventArgs e)
        {
            if(users.Items.Count == 0)
            {
                return;
            }

            _client.SendMessage(users.SelectedItem as string,  textMessage.Text);
        }

        private void user_button_Click(object sender, EventArgs e)
        {
            _client.GetRegisteredUsers();
        }
    }
}
