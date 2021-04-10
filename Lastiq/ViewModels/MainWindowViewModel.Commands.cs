using System.Collections.Generic;
using Chatyx.Infrastructure.Commands;
using Chatyx.Infrastructure.Commands.Base;

namespace Chatyx.ViewModels
{
    partial class MainWindowViewModel
    {
        //---------------------------------------------------------------------
        #region Commands : AppCommands

        private Dictionary<string, AppCommand> _AppCommands = new()
        {
            { nameof(MoveAppCommand),     new MoveAppCommand()     },
            { nameof(MinimizeAppCommand), new MinimizeAppCommand() },
            { nameof(CloseAppCommand),    new CloseAppCommand()    }
        };
        public Dictionary<string, AppCommand> AppCommands => _AppCommands;

        #endregion Commands : AppCommands
        //---------------------------------------------------------------------
        #region Commands : SendMessageCommands

        private Dictionary<string, AppCommand> _SendMessageCommands = new()
        {
            { nameof(SendMessageTextCommand), new SendMessageTextCommand() },
            { nameof(SendMessageImageCommand), new SendMessageImageCommand() }
        };
        public Dictionary<string, AppCommand> SendMessageCommands => _SendMessageCommands;

        #endregion Commands : SendMessageCommands
        //---------------------------------------------------------------------
        #region Command : ConnectCommand

        private AppCommand _ConnectCommand;
        public AppCommand ConnectCommand
        {
            get => _ConnectCommand ??= new ConnectCommand();
            set => _ConnectCommand = value;
        }

        #endregion Command : ConnectCommand
        //---------------------------------------------------------------------
        #region Command : ChangeModeCommand

        private AppCommand _ChangeModeCommand;
        public AppCommand ChangeModeCommand
        {
            get => _ChangeModeCommand ??= new ChangeModeCommand();
            set => _ChangeModeCommand = value;
        }

        #endregion Command : ChangeModeCommand
        //---------------------------------------------------------------------
        #region Command : LoginCommand

        private AppCommand _LoginCommand;
        public AppCommand LoginCommand
        {
            get => _LoginCommand ??= new LoginCommand();
            set => _LoginCommand = value;
        }

        #endregion Command : LoginCommand
        #region Command : RegistrationCommand

        private AppCommand _RegistrationCommand;
        public AppCommand RegistrationCommand
        {
            get => _RegistrationCommand ??= new RegistrationCommand();
            set => _RegistrationCommand = value;
        }

        #endregion Command : RegistrationCommand
        //---------------------------------------------------------------------
    }
}