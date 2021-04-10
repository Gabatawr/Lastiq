using Chatyx.Model;
using System.Windows;
using System.Windows.Media;

namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel
    {
        //---------------------------------------------------------------------
        #region AppConnected
        public void AppConnected()
        {
            ShowConnectPanelParam = false;
            ShowLoginPanelParam = true;

            ConnectColorParam.Color = new Color { A = 255, R = 0, G = 125, B = 255 };
        }
        #endregion AppConnected
        #region AppDisconnected
        public void AppDisconnected()
        {
            ShowConnectPanelParam = true;
            ShowLoginPanelParam = false;

            ConnectColorParam.Color = new Color { A = 255, R = 255, G = 69, B = 0 };
        }
        #endregion AppDisconnected
        //---------------------------------------------------------------------
        #region AppLoginON
        public void AppLoginON()
        {
            ShowLoginPanelParam = false;
            ShowChatBoxPanelParam = true;
        }
        #endregion AppLoginON
        #region AppLoginOFF
        public void AppLoginOFF()
        {
            ShowLoginPanelParam = true;
            ShowChatBoxPanelParam = false;
        }
        #endregion AppLoginOFF
        //---------------------------------------------------------------------
        #region ViewMessage

        public void ViewMessage(MessageModel msg, HorizontalAlignment alignment = HorizontalAlignment.Left)
        {
            lock (MessageItemsBlock)
                MessageItems.Add(new MessageVievModel(msg) { Alignment = alignment });

            MessageTextParam = string.Empty;
        }

        #endregion ViewMessage
        //---------------------------------------------------------------------
    }
}
