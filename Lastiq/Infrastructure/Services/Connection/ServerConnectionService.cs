using Chatyx.Infrastructure.Services.Connection.Base;
using Chatyx.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace Chatyx.Infrastructure.Services.Connection
{
    public class ServerConnectionService : AppConnectionService
    {
        //-----------------------------------------------------
        public ServerConnectionService()
        {
            Port = 8180;
            IP = IPAddress.Loopback;
        }
        private List<Socket> Clients = new();
        //-----------------------------------------------------
        public override bool Start()
        {
            try
            {
                Server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                Server.Bind(new IPEndPoint(IP, Port));
                Server.Listen(10);
            }
            catch
            {
                Server.Close();
                return false;
            }

            Task.Run(ServerConnectWaitHandler);
            return true;
        }
        private void ServerConnectWaitHandler()
        {
            try
            {
                while (true)
                {
                    Socket client = Server.Accept();
                    Clients.Add(client);
                    Task.Run(() => MessageListener(client));
                }
            }
            catch { }
            finally { Server.Close(); }
        }
        //-----------------------------------------------------
        protected override void MessageHandler(MessageModel msg, Socket sender)
            => ForwardMessage(msg, sender);
        protected override void MessageListenerCatch(Socket connect)
            => Clients.Remove(connect);
        //-----------------------------------------------------
        protected virtual void ForwardMessage(MessageModel msg, Socket sender)
        {
            foreach (var client in Clients)
            {
                if (client != sender)
                {
                    SendMessage(msg);
                }
            }
        }
        public override void SendMessage(MessageModel msg)
        {
            BinaryFormatter bf = new();
            foreach (var client in Clients)
            {
                using (MemoryStream ms = new())
                {
                    bf.Serialize(ms, msg);
                    using (NetworkStream ns = new(client))
                    {
                        ns.Write(BitConverter.GetBytes(ms.Length));
                        ns.Write(ms.ToArray());
                    }
                }
            }
        }
    }
}
