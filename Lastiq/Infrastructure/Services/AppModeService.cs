using System.Windows;
using System.Windows.Media;
using Chatyx.Infrastructure.Services.Connection;
using Chatyx.ViewModels.Base;

namespace Chatyx.Infrastructure.Services
{
    public class AppModeService
    {
        //-----------------------------------------------------
        public static Color EnableColor = new Color() { A = 255, R = 119, G = 119, B = 119 };
        public static Color DisableColor = new Color() { A = 255, R = 68, G = 68, B = 68 };
        //-----------------------------------------------------
        public enum Modes { Client, Server }
        //-----------------------------------------------------
        private Modes _current = Modes.Client;
        public Modes Current 
        {
            get => _current;
            set
            {
                _current = value;

                ViewModel.MainWindow.AppConnect = _current switch
                {
                    Modes.Client => new ClientConnectionService(),
                    Modes.Server => new ServerConnectionService(),

                    _ => throw new System.NotImplementedException()
                };
            }
        }
        //-----------------------------------------------------
    }
}
