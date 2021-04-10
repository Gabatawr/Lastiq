using System.Net;
using System.Windows.Data;
using Chatyx.Infrastructure.Services;
using Chatyx.Infrastructure.Services.Connection.Base;
using Chatyx.ViewModels.Base;

namespace Chatyx.ViewModels
{
    public partial class MainWindowViewModel : ViewModel
    {
        public AppModeService AppMode { get; set; }
        public AppConnectionService AppConnect { get; set; }
        public MainWindowViewModel()
        {
            BindingOperations.EnableCollectionSynchronization(MessageItems, MessageItemsBlock);

            ShowConnectPanelParam = true;
            ShowLoginPanelParam = false;
            ShowChatBoxPanelParam = false;

            LoginParam = "Admin";
            PasswordParam = "admin";
        }
    }
}
