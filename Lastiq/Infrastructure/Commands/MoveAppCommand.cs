using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Lastiq.Infrastructure.Commands.Base;

namespace Lastiq.Infrastructure.Commands
{
    class MoveAppCommand : AppCommand
    {
        public override void Command(object p) => Application.Current.MainWindow?.DragMove();
        public override bool CanExecute(object p)
            => ((p as MouseEventArgs).Source as FrameworkElement) is Grid;
    }
}
