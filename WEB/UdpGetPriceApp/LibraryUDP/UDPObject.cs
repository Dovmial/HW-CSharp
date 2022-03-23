using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUDP
{
    public class UDPObject
    {
        public string remoteAddress = "127.0.0.1";
        public int RemotePort { get; set; }
        public int LocalPort { get; set; }
        public UDPObject(int remotePort, int localPort)
        {
            RemotePort = remotePort;
            LocalPort = localPort;
        }
        public void SendMessage(string message)
        {
            UdpClient sender = new UdpClient(); // создаем UdpClient для отправки сообщений
            try
            {
                byte[] data = Encoding.Unicode.GetBytes(message);
                sender.Send(data, data.Length, remoteAddress, RemotePort); // отправка
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sender.Close();
            }
        }

        public async Task<string> ReceiveMessageAsync()
        {
            UdpClient receiver = new UdpClient(LocalPort); // UdpClient для получения данных
            try
            {
                var message = await receiver.ReceiveAsync(); // получаем данные

                return Encoding.Unicode.GetString(message.Buffer);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            finally
            {
                receiver.Close();
            }
        }
    }
}
