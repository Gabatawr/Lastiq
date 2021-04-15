using Lastiq.Models;
using Lastiq.ViewModels.Base;
using System;
using System.Net.Sockets;
using System.Windows.Media;
using SticksyClient;
using SticksyProtocol;

namespace Lastiq.ViewModels
{
    public partial class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            //---------------------------------------------------------------------
            // Preseting
            StickCollectionInit();
            //---------------------------------------------------------------------

            TcpClient = new TcpClient("127.0.0.1", 57650);
            Client = new Client(TcpClient);
            Client.Listener.SigningIn += ProcessSingInResult;
            Client.Listener.CreatingSticker += ProcessCreateStickResult;

            #region StickListTest

            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                var Stick = new StickModel(creatorId: 0)
                {
                    Title = $"Stick {i} Title",
                    Color = new SolidColorBrush(new Color() { A = 255, R = (byte)rand.Next(256), G = (byte)rand.Next(256), B = (byte)rand.Next(256) })
                };
                Stick.Contents.Add(new TextContent($"Teeeee eeeee eeeeeee eeeeeeeeee eeeeeee eeeeeeeeee eeeeeeeeeeee eeeeeeeeeee eeeeeeeee ee eeext {i}"));
                Stick.Contents.Add(new CheckboxContent($"Checkbox {i}"));

                Stick.Contents.Add(new TextContent($"Text two"));
                Stick.Contents.Add(new CheckboxContent($"Checkbox two"));
                Stick.Contents.Add(new CheckboxContent($"Checkbox three"));

                for (int t = 0; t < rand.Next(5); t++)
                {
                    Stick.Tags.Add($"Tag {t}");
                }

                StickCollection.Add(new StickViewModel() { Stick = Stick });
            }

            #endregion StickListTest
        }
    }
}
