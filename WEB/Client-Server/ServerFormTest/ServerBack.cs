using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerFormTest
{

    internal class ServerBack
    {
        int port = 8005;
        public async void StartAsync(RichTextBox rtbServerMessages)
        {
            await Task.Run(() =>
                   {
                       IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
                       Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                       try
                       {
                           listenSocket.Bind(ipPoint);
                           listenSocket.Listen(10);

                           while (true)
                           {
                               Socket handler = listenSocket.Accept();
                               IPEndPoint clientPoint = handler.RemoteEndPoint as IPEndPoint;
                               ClientUser user = new ClientUser(clientPoint.Address, DateTime.Now);

                               StringBuilder sb = new StringBuilder();
                               int bytes = 0;
                               byte[] data = new byte[256];
                               do
                               {
                                   bytes = handler.Receive(data);
                                   sb.Append(Encoding.Unicode.GetString(data, 0, bytes));
                               } while (handler.Available > 0);

                               user.message = sb.ToString();
                               rtbServerMessages.Invoke(new Action(() => 
                                rtbServerMessages.AppendText($"{DateTime.Now.ToLocalTime()}: [{clientPoint.Address}] {sb}\n")));

                               // отправляем ответ
                               string message;//
                               switch (sb.ToString().ToLower())
                               {
                                   case "время":
                                       message = $"{DateTime.Now.ToShortTimeString()}";
                                       break;
                                   case "дата":
                                       message = $"{DateTime.Now.ToShortDateString()}";
                                       break;
                                   /*case "stop":
                                       message = "сервер остановлен";
                                       isStop = true;
                                       break;*/
                                   default:
                                       message = "сообщение доставлено, но не может быть обработано";
                                       break;
                               }

                               data = Encoding.Unicode.GetBytes($"{message} \n");
                               handler.Send(data);
                               // закрываем сокет
                               handler.Shutdown(SocketShutdown.Both);
                               handler.Close();
                               user.DateEnd = DateTime.Now;
                               Logger.Write(user);
                           }

                       }
                       catch (Exception ex)
                       {
                           rtbServerMessages.Invoke(new Action(() => rtbServerMessages.AppendText(ex.Message)));
                       }
                   });
        }
    }
}
