using System.Windows;
using Lastiq.Infrastructure.Commands.Base;

namespace Lastiq.Infrastructure.Commands
{
    class MinimizeAppCommand : AppCommand
    {
        public override void Command(object p)
            => Application.Current.MainWindow.WindowState = WindowState.Minimized;
        public override bool CanExecute(object p) => true;
    }
}
