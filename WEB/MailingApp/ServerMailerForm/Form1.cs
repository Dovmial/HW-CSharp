using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerMailerForm.NewsContentModel;

namespace ServerMailerForm
{
    public partial class Form1 : Form
    {
        string server = "127.0.0.1";

       
        TcpListener listener;
        TcpClient client;
        string _messageFromClient = "";
        INewsContent? _news;
        public Form1()
        {
            InitializeComponent();
            Task.Run(() => StartListenerAsync());
        }

        async Task StartListenerAsync()
        {
            while (true)
            {
                try
                {
                    listener = new TcpListener(IPAddress.Parse(server), 8001);
                    listener.Start();
                    string? request = await Task.Run(() => ReceiveMessage());
                    richTextBox1.Invoke(new Action(() => richTextBox1.AppendText($"{request ?? ""}\n")));
                    
                    if(request is not null) 
                        await SendContentSubsribedAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    listener?.Stop();
                }
            }
        }

        private string ReceiveMessage()
        {
            try
            {
                client = listener.AcceptTcpClient();
                using (StreamReader sr = new StreamReader(client.GetStream(), Encoding.UTF8))
                {
                    _messageFromClient = sr.ReadLine();
                    _news = NewsBuilder.GetThematicNews(_messageFromClient);
                }
                return _messageFromClient;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally { client.Close(); }

        }

        public async Task SendContentSubsribedAsync()
        {
            ServerMultycast _serverMultycast = new ServerMultycast();
            await Task.Run(() => _serverMultycast.MulticastSend(_news));
        }
    }
}
