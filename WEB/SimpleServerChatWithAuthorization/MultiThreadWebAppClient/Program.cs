using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

//Модофицировать приложение. Добавить функцию входа по регистрации (Логин Пароль)

namespace ConsoleClient
{
    class Program
    {
        const int port = 8888;
        const string address = "127.0.0.1";
        static void Main(string[] args)
        {
            TcpClient client = null;
            try
            {
                client = new TcpClient(address, port);
                NetworkStream stream = client.GetStream();
                string message;
                string userLogin = "";
                bool isAuthorization = false;

                while (true)
                {
                    if (!isAuthorization)
                    { 
                        char mod;
                        Menu.SignInMod(out mod);

                        message = Menu.GetData(mod, out userLogin);
                        // преобразуем сообщение в массив байтов
                        byte[] sendData = Encoding.Unicode.GetBytes(message);
                        // отправка сообщения
                        stream.Write(sendData, 0, sendData.Length);

                        byte[] answear = new byte[64]; // буфер для получаемых данных
                        StringBuilder sb = new StringBuilder();
                        int b = 0;
                        do
                        {
                            b = stream.Read(answear, 0, answear.Length);
                            sb.Append(Encoding.Unicode.GetString(answear, 0, b));
                        }
                        while (stream.DataAvailable);

                        message = sb.ToString();
                        string[] strs = message.Split();
                        isAuthorization = strs[0] == "1";
                        Console.WriteLine($"Сервер: {message}");

                    }
                    else
                    {
                        Console.Write(userLogin + ": ");
                        // ввод сообщения
                        message = Console.ReadLine();
                        message = $"{userLogin}: {message}";
                        // преобразуем сообщение в массив байтов
                        byte[] data = Encoding.Unicode.GetBytes(message);
                        // отправка сообщения
                        stream.Write(data, 0, data.Length);

                        // получаем ответ
                        data = new byte[64]; // буфер для получаемых данных
                        StringBuilder builder = new StringBuilder();
                        int bytes = 0;
                        do
                        {
                            bytes = stream.Read(data, 0, data.Length);
                            builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                        }
                        while (stream.DataAvailable);

                        message = builder.ToString();
                        Console.WriteLine($"Сервер: {message}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}