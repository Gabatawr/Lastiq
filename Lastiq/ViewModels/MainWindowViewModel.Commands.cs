using Lastiq.Infrastructure.Commands;
using Lastiq.Infrastructure.Commands.Base;
using Prism.Commands;
using System.Collections.Generic;
using System.Windows.Input;

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
        #region Command : TestAddCommand

        private AppCommand _TestAddCommand;
        public AppCommand TestAddCommand
        {
            get => _TestAddCommand ?? new ActionCommand(CreateStick);
            set => _TestAddCommand = value;
        }

        #endregion Command : TestAddCommand
        //---------------------------------------------------------------------
        #region Command : SignInCommand

        private AppCommand _signInCommand;
        public AppCommand SignInCommand
        {
            get => _signInCommand ?? new ActionCommand(SingIn);
            set => _TestAddCommand = value;
        }

        #endregion Command : SignInCommand
        //---------------------------------------------------------------------
        #region Command : SearchCommand

        private AppCommand _SearchCommand;
        public AppCommand SearchCommand
        {
            get => _SearchCommand ?? new ActionCommand
                (
                    param => ExecuteSearchCommand((KeyEventArgs)param),
                    param => CanExecuteSearchCommand((KeyEventArgs)param)
                );
            set => _SearchCommand = value;
        }
        private void ExecuteSearchCommand(KeyEventArgs e)
        {
            // use SearchText prop;
            // Code command
        }
        private bool CanExecuteSearchCommand(KeyEventArgs e)
            => e.Key == Key.Enter;

        #endregion Command : SearchCommand
        //---------------------------------------------------------------------
        #region Command : TagSelectedCommand

        public DelegateCommand<object> TagSelectedCommand
        { 
            get => new DelegateCommand<object>(param =>
            {
                // use param as TagModel or TagSelected prop
                // Code command
            });
        } 

        #endregion Command : TagSelectedCommand
        //---------------------------------------------------------------------
    }
}