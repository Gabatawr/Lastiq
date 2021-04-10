using Lastiq.Infrastructure.Commands;
using Lastiq.Infrastructure.Commands.Base;
using System.Collections.Generic;

namespace Lastiq.ViewModels
{
    partial class MainWindowViewModel
    {
        //---------------------------------------------------------------------
        #region Commands : AppCommands

        private Dictionary<string, AppCommand> _AppCommands = new Dictionary<string, AppCommand>()
        {
            { nameof(MoveAppCommand), new MoveAppCommand() },
            { nameof(MinimizeAppCommand), new MinimizeAppCommand() },
            { nameof(CloseAppCommand), new CloseAppCommand() }
        };
        public Dictionary<string, AppCommand> AppCommands => _AppCommands;

        #endregion Commands : AppCommands
        //---------------------------------------------------------------------
    }
}