using Chatyx.Infrastructure.Commands.Base;

namespace Chatyx.Infrastructure.Commands
{
    class ConnectCommand : AppCommand
    {
        public override void Command(object e)
        {
            if (vm.AppConnect.Start())
                vm.AppConnected();
            else
                vm.AppDisconnected();
        }

        public override bool CanExecute(object e) => vm.AppMode != null;
    }
}
