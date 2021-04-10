using System;

namespace Chatyx.Infrastructure.Commands.Base
{
    class ActionCommand : AppCommand
    {
        private readonly Action<object> _Command;
        private readonly Func<object, bool> _CanExecute;

        public ActionCommand(Action<object> command, Func<object, bool> canExecute = null)
        {
            _Command = command ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = canExecute;
        }

        public override bool CanExecute(object p) => _CanExecute?.Invoke(p) ?? true;
        public override void Command(object p) => _Command(p); 
    }
}
