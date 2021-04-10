using System.Windows;
using System.Windows.Input;
using Chatyx.Infrastructure.Commands.Base;

namespace Chatyx.Infrastructure.Commands
{
    class MoveAppCommand : AppCommand
    {
        public override void Command(object p) => Application.Current.MainWindow?.DragMove();
        public override bool CanExecute(object p)
            => ((p as MouseEventArgs).Source as FrameworkElement) == Application.Current.MainWindow;
    }
}
