using Chatyx.Infrastructure.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Net;
using System.Windows.Media;

namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel
    {
        //--------------------------------------------------------------------
        #region string : IPParam

        private string _IPParam;
        public string IPParam
        {
            get => _IPParam;
            set
            {
                IPAddress tmp;
                if (IPAddress.TryParse(value, out tmp))
                    Set(ref _IPParam, value);
            }
        }

        #endregion string : IPParam
        #region string : PortParam

        private string _PortParam;
        public string PortParam
        {
            get => _PortParam;
            set 
            {
                ushort tmp;
                if (ushort.TryParse(value, out tmp))
                    Set(ref _PortParam, value);
            }
        }

        #endregion string : PortParam
        //--------------------------------------------------------------------
        #region string : LoginParam

        private string _LoginParam;
        public string LoginParam
        {
            get => _LoginParam;
            set => Set(ref _LoginParam, value);
        }

        #endregion string : LoginParam
        #region string : PasswordParam

        private string _PasswordParam;
        public string PasswordParam
        {
            get => _PasswordParam;
            set => Set(ref _PasswordParam, value);
        }

        #endregion string : PasswordParam
        //--------------------------------------------------------------------
        #region string : MessageTextParam

        private string _MessageTextParam;
        public string MessageTextParam
        {
            get => _MessageTextParam;
            set => Set(ref _MessageTextParam, value);
        }

        #endregion string : MessageTextParam
        //--------------------------------------------------------------------
        #region string : GoTextParam

        private string _GoTextParam = "Connect";
        public string GoTextParam
        {
            get => _GoTextParam;
            set => Set(ref _GoTextParam, value);
        }

        #endregion string : GoTextParam
        //--------------------------------------------------------------------
        #region SolidColorBrush : ConnectColorParam

        private SolidColorBrush _ConnectColorParam;
        public SolidColorBrush ConnectColorParam
        {
            get => _ConnectColorParam ??= new SolidColorBrush(Colors.White);
            set => Set(ref _ConnectColorParam, value);
        }

        #endregion SolidColorBrush : ConnectColorParam
        //--------------------------------------------------------------------
        #region SolidColorBrush : ClientModeParam

        private SolidColorBrush _ClientModeParam;
        public SolidColorBrush ClientModeParam
        {
            get => _ClientModeParam ??= new SolidColorBrush(AppModeService.DisableColor);
            set => Set(ref _ClientModeParam, value);
        }

        #endregion SolidColorBrush : ClientModeParam
        #region SolidColorBrush : ServerModeParam

        private SolidColorBrush _ServerModeParam;
        public SolidColorBrush ServerModeParam
        {
            get => _ServerModeParam ??= new SolidColorBrush(AppModeService.DisableColor);
            set => Set(ref _ServerModeParam, value);
        }

        #endregion SolidColorBrush : ServerModeParam
        //--------------------------------------------------------------------
        #region bool : IsClientModeParam

        private bool _IsClientModeParam;
        public bool IsClientModeParam
        {
            get => _IsClientModeParam;
            set => Set(ref _IsClientModeParam, value);
        }

        #endregion bool : IsClientModeParam
        //--------------------------------------------------------------------
        #region bool : ShowConnectPanelParam

        private bool _ShowConnectPanelParam;
        public bool ShowConnectPanelParam
        {
            get => _ShowConnectPanelParam;
            set => Set(ref _ShowConnectPanelParam, value);
        }

        #endregion bool : ShowConnectPanelParam
        #region bool : ShowLoginPanelParam

        private bool _ShowLoginPanelParam;
        public bool ShowLoginPanelParam
        {
            get => _ShowLoginPanelParam;
            set => Set(ref _ShowLoginPanelParam, value);
        }

        #endregion bool : ShowLoginPanelParam
        #region bool : ShowChatBoxPanelParam

        private bool _ShowChatBoxPanelParam = false;
        public bool ShowChatBoxPanelParam
        {
            get => _ShowChatBoxPanelParam;
            set => Set(ref _ShowChatBoxPanelParam, value);
        }

        #endregion bool : ShowChatBoxPanelParam
        //--------------------------------------------------------------------
        #region List<string> : MassagesListParam

        private List<string> _MassagesListParam;
        public List<string> MassagesListParam
        {
            get => _MassagesListParam ??= new();
            set => Set(ref _MassagesListParam, value);
        }

        #endregion List<string> : MassagesListParam
        //--------------------------------------------------------------------
        #region ObservableCollection<Symbol> : MessageItems

        public object MessageItemsBlock = new();
        private ObservableCollection<MessageVievModel> _MessageItems = new();
        public ObservableCollection<MessageVievModel> MessageItems
        {
            get => _MessageItems;
            set => Set(ref _MessageItems, value);
        }

        #endregion
        //--------------------------------------------------------------------
        #region ImageSource : OpenImageParam

        private ImageSource _OpenImageParam;
        public ImageSource OpenImageParam
        {
            get => _OpenImageParam;
            set => Set(ref _OpenImageParam, value);
        }

        #endregion ImageSource : OpenImageParam
        //--------------------------------------------------------------------
    }
}
