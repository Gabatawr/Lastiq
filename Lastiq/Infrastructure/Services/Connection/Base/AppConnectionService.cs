using Chatyx.Model;
using Chatyx.ViewModels;
using Chatyx.ViewModels.Base;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;

namespace Chatyx.Infrastructure.Services.Connection.Base
{
    public abstract class AppConnectionService
    {
        //-----------------------------------------------------
        public Socket Server { get; set; }
        //-----------------------------------------------------
        private IPAddress _ip;
        public IPAddress IP 
        {
            get => _ip;
            set
            {
                _ip = value;
                ViewModel.MainWindow.IPParam = _ip.ToString();
            }
        }

        private ushort _port;
        public ushort Port
        {
            get => _port;
            set
            {
                _port = value;
                ViewModel.MainWindow.PortParam = _port.ToString();
            }
        }
        //-----------------------------------------------------
        public abstract bool Start();
        public abstract void SendMessage(MessageModel msg);
        //-----------------------------------------------------
        protected void MessageListener(Socket connect)
        {
            var buff = new byte[256];
            try
            {
                while (true)
                {
                    BinaryFormatter bf = new();
                    MessageModel msg = null;

                    using (MemoryStream ms = new())
                    {
                        using (NetworkStream ns = new(connect))
                        {
                            int bytes = ns.Read(buff, 0, 256);
                            int lenght = BitConverter.ToInt32(buff);

                            int count = 0;
                            do
                            {
                                bytes = ns.Read(buff, 0, 256);
                                ms.Write(buff, 0, bytes);
                                count += bytes;
                            } while (count < lenght);

                            ms.Position = 0;
                        }

                        if (ms.Length > 0)
                            msg = (MessageModel)bf.Deserialize(ms);
                    }

                    if (msg != null)
                    {
                        MessageHandler(msg, connect);
                        ViewModel.MainWindow.ViewMessage(msg);
                    }
                }
            }
            catch { MessageListenerCatch(connect); }
            finally { MessageListenerFinally(connect); }
        }
        protected virtual void MessageHandler(MessageModel msg, Socket sender) { }
        protected virtual void MessageListenerCatch(Socket connect) { }
        protected virtual void MessageListenerFinally(Socket connect) => connect.Close();
        //-----------------------------------------------------
    }
}
