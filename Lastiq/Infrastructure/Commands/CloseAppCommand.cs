using System.Windows;
using Chatyx.Infrastructure.Commands.Base;

namespace Chatyx.Infrastructure.Commands
{
    class CloseAppCommand : AppCommand
    {
        public override void Command(object e) => Application.Current.Shutdown();
        public override bool CanExecute(object e) => true;
    }
}
