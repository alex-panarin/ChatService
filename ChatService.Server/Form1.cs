using ChatService.Server.Server;
using ChatService.Shared;
using ChatService.Shared.Messages;
using ChatService.Shared.Models;
using ChatService.Shared.UI;
using System;
using System.Net;
using System.Windows.Forms;

namespace ChatService.Server
{
    public partial class Form1 : Form
    {
        ChatServer _server;
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            _server = new ChatServer();

            base.OnLoad(e);

            interfaces.DataSource = ChatServer.Interfaces;
            interfaces.DisplayMember = "Description";
        }

        private void DisplayMessage(MessageInfo message)
        {

            string msg = $"{DateTime.Now:G} ";

            if (message.Type == MessageType.Connect)
                msg += $"Соединение установлено {message.Info}\r\n";

            if (message.Type == MessageType.Disconnect)
                msg += $"Соединение прервано {message.Info}\r\n";

            if (message.Type == MessageType.Text)
                msg += $"{message.Info}\r\n";

            //marshal message to UI thread
            if (message.Type == MessageType.Error)
            {
                Invoke(new Action<string>(DisplayError), msg);
            }
            else
            {
                Invoke(new Action<string>(textBoxMessages.AppendText), msg);
            }
            
        }

        private void DisplayError(string error)
        {
            MessageBox.Show(error);
        }
        private void start_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (interfaces.Items.Count == 0)
                    throw new ApplicationException("Не найден сетевой интерфейс.");

                var serverConnection = new ConnectionInfo(
                    serverName.Text, 
                    ((NetworkInterfaceInfo)interfaces.SelectedItem).Address.ToString(),
                    int.Parse(port.Text));
                
                
                _server.Start(serverConnection, new DisplayMessageService(DisplayMessage));
            }
            catch(Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }


        private void stop_button_Click(object sender, EventArgs e)
        {
            _server.Stop();
        }
    }
}
