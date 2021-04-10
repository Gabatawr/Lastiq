using System.Windows;
using Chatyx.Infrastructure.Commands.Base;

namespace Chatyx.Infrastructure.Commands
{
    class MinimizeAppCommand : AppCommand
    {
        public override void Command(object p)
            => Application.Current.MainWindow.WindowState = WindowState.Minimized;
        public override bool CanExecute(object p) => true;
    }
}
