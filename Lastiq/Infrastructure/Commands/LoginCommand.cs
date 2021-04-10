using Chatyx.Infrastructure.Commands.Base;

namespace Chatyx.Infrastructure.Commands
{
    class LoginCommand : AppCommand
    {
        public override void Command(object e)
        {
            // TODO: LoginService
            if (vm.LoginParam == "Admin" && vm.PasswordParam == "admin")
                vm.AppLoginON();
            else vm.AppLoginOFF();
        }

        public override bool CanExecute(object e) => true;
    }
}
