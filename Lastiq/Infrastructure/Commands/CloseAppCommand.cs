using System.Windows;
using Lastiq.Infrastructure.Commands.Base;

namespace Lastiq.Infrastructure.Commands
{
    class CloseAppCommand : AppCommand
    {
        public override void Command(object e) => Application.Current.Shutdown();
        public override bool CanExecute(object e) => true;
    }
}
