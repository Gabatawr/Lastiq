using Chatyx.Infrastructure.Services.Connection.Base;
using Chatyx.Model;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Chatyx.Infrastructure.Services.Connection
{
    public class ClientConnectionService : AppConnectionService
    {
        //-----------------------------------------------------
        public ClientConnectionService()
        {
            Port = 8180;
            IP = IPAddress.Loopback;
        }
        //-----------------------------------------------------
        public override bool Start()
        {
            try
            {
                Server = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Server.Connect(new IPEndPoint(IP, Port));
            }
            catch
            { 
                Server.Close();
                return false; 
            }

            Task.Run(() => MessageListener(Server));
            return true;
        }
        //-----------------------------------------------------
        protected override void MessageHandler(MessageModel msg, Socket sender)
        {

        }
        //-----------------------------------------------------
        public override void SendMessage(MessageModel msg)
        {
            BinaryFormatter bf = new();

            using (MemoryStream ms = new())
            {
                bf.Serialize(ms, msg);
                using (NetworkStream ns = new(Server))
                {
                    ns.Write(BitConverter.GetBytes(ms.Length));
                    ns.Write(ms.ToArray());
                }
            }
        }
    }
}
