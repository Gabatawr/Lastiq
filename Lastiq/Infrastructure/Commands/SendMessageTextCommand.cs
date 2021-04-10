using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Model;
using System.Windows;

namespace Chatyx.Infrastructure.Commands
{
    class SendMessageTextCommand : AppCommand
    {
        public override void Command(object e)
        {
            MessageModel msg = new() { Text = vm.MessageTextParam };
            vm.AppConnect.SendMessage(msg);
            vm.ViewMessage(msg, HorizontalAlignment.Right);
        }

        public override bool CanExecute(object e)
            => string.IsNullOrEmpty(vm.MessageTextParam) is false;
    }
}
