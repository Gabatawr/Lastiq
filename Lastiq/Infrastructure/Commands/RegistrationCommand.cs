using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels;

namespace Chatyx.Infrastructure.Commands
{
    class RegistrationCommand : AppCommand
    {
        public override void Command(object e)
        {
            
        }

        public override bool CanExecute(object e) => true;
    }
}
