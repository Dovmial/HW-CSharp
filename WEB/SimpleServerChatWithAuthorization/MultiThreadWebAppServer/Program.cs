using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ConsoleServer
{
    public class ClientObject
    {
        private User _user;
        private Authorizator _authorizator = new Authorizator();
        public TcpClient client;
        
        public ClientObject(TcpClient tcpClient)
        {
            client = tcpClient;
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();
                byte[] data = new byte[64]; // буфер для получаемых данных

                bool isAuthorization = false;

                while (true)
                {
                    // получаем сообщение
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();

                    if (!isAuthorization)
                    { 
                        string[] userLogon = message.Split('%');
                        
                        if (userLogon.Length != 3)
                            message = "0 Ошибка авторизации";
                        else
                        {
                            _user = new User(userLogon[1], userLogon[2]);
                            switch (userLogon[0])
                            {
                                case "a":
                                    if (!_authorizator.CheckAuthorization(_user))
                                    {
                                        message = "0 Ошибка авторизации";
                                        break;
                                    }
                                    message = "1 Авторизация успешна";
                                    //запрет одинаковых пользователей в сеансах
                                    isAuthorization = _user.IsConnect = true;
                                    _authorizator.SetUserConnectStatus(_user);
                                    break;
                                case "r":
                                    if(!_authorizator.Registration(_user))
                                    {
                                        message = "0 Ошибка регистрации";
                                        break;
                                    }
                                    message = "1 Регистрация успешна";
                                    isAuthorization = _user.IsConnect = true;
                                    _authorizator.SetUserConnectStatus(_user);
                                    break;
                                default:
                                    message = "0 Ошибка авторизации";
                                    break;
                            }
                        }
                    }

                    Console.WriteLine(message);
                    // отправляем обратно сообщение в верхнем регистре
                    message = message.Substring(message.IndexOf(':') + 1).Trim().ToUpper();
                    data = Encoding.Unicode.GetBytes(message);
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _user.IsConnect = false;
                _authorizator.SetUserConnectStatus(_user);
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
    }

    class Program
    {
        const int port = 8888;
        static TcpListener listener;
        static void Main(string[] args)
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);
                listener.Start();
                Console.WriteLine("Ожидание подключений...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ClientObject clientObject = new ClientObject(client);

                    // создаем новый поток для обслуживания нового клиента
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (listener != null)
                    listener.Stop();
            }
        }
    }
}