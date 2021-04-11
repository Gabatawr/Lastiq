using Lastiq.Infrastructure.Commands;
using Lastiq.Infrastructure.Commands.Base;
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
            get => _TestAddCommand ?? new ActionCommand
                (
                    param => ExecuteTestAddCommand(param)
                );
            set => _TestAddCommand = value;
        }
        private void ExecuteTestAddCommand(object e)
        {
            StickCollection.Add(new StickViewModel());
        }

        #endregion Command : TestAddCommand
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
            // Code command
        }
        private bool CanExecuteSearchCommand(KeyEventArgs e)
            => e.Key == Key.Enter;

        #endregion Command : SearchCommand
        //---------------------------------------------------------------------
    }
}