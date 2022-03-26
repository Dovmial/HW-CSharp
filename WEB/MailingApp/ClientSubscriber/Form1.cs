using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ClientSubscriber
{
    public partial class Form1 : Form
    {
        delegate void AppendText(string text);
        TcpClient clientTCP;
        void AppendTextProc(string text)
        {
            richTextBox1.AppendText($"{text}\n");
        }

        void Listner()
        {
            UdpClient receiver = null;
            try
            {
                receiver = new UdpClient(4567);
                receiver.JoinMulticastGroup(IPAddress.Parse("224.5.5.5"), 20);
                while (true)
                {
                    Thread.Sleep(1000);
                    IPEndPoint ipEndPoint = null;
                    //reading
                    byte[] buffer = receiver.Receive(ref ipEndPoint);
                    Invoke(new AppendText(AppendTextProc), $"{Encoding.UTF8.GetString(buffer)}\n");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                receiver?.Close();
            }
        }
        public Form1()
        {
            InitializeComponent();
            Thread listen = new Thread(new ThreadStart(Listner));
            listen.IsBackground = true;
            listen.Start();
        }

        
        async Task SendMessageAsync(string message)
        {
            try
            {
                clientTCP = new TcpClient("localhost", 8001);
                using (var stream = clientTCP.GetStream())
                {
                    byte[] buffer = Encoding.UTF8.GetBytes(message);
                    await stream.WriteAsync(buffer, 0, buffer.Length);
                }
            }

            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message);
            }

            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                clientTCP?.Close();
            }
        }

        private async void btnSubsribe_Click(object sender, EventArgs e)
        {
            string message = "";
            if (rbSport.Checked) message = "sport";
            else if (rbEconomics.Checked) message = "economics";
            else if (rbPolit.Checked) message = "politic";

            await SendMessageAsync(message);
        }
    }
}
