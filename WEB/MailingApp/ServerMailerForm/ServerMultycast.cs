using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using ServerMailerForm.NewsContentModel;

namespace ServerMailerForm
{
    public class ServerMultycast
    {
        string _ipAddress = "224.5.5.5";
        public int Interval { get; private set; } = 1000;
        public void MulticastSend(INewsContent news)
        {
           
            Socket socket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);
            socket.SetSocketOption(
                SocketOptionLevel.IP,
                SocketOptionName.MulticastTimeToLive, 2);
            IPAddress dest = IPAddress.Parse(_ipAddress);
            socket.SetSocketOption(
                SocketOptionLevel.IP,
                SocketOptionName.AddMembership,
                new MulticastOption(dest));
            socket.MulticastLoopback = false;
            IPEndPoint ipep = new IPEndPoint(dest, 4567);
            socket.Connect(ipep);
            foreach (string n in news)
            {
                Thread.Sleep(Interval);
                socket.Send(Encoding.Default.GetBytes($"{n}\n"));
            }
            
            socket.Close();
        }
    }
}
