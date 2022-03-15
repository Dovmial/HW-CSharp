using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace ClientFormTest
{
    internal class ClientBack
    {
        private int _port = 8005;
        private string _address = "127.0.0.1";
        public string Send(string message)
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(_address), _port);
                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);

                byte[] data = Encoding.Unicode.GetBytes(message);
                socket.Send(data);

                data = new byte[256];
                StringBuilder sb = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    sb.Append(Encoding.Unicode.GetString(data, 0, bytes));
                } while (socket.Available > 0);
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                return sb.ToString();
            }

            catch (Exception ex)
            {
                return  $"Error: {ex.Message}";
            }
        }

    }
}
