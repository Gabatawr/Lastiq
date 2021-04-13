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
        #region Command : AddStickCommand

        private AppCommand _AddStickCommand;
        public AppCommand AddStickCommand
        {
            get
            {
                if (_AddStickCommand == null)
                    _AddStickCommand = new ActionCommand(CreateStick);

                return _AddStickCommand;
            }
            set => _AddStickCommand = value;
        }

        #endregion Command : AddStickCommand
        //---------------------------------------------------------------------
        #region Command : SignInCommand

        private AppCommand _SignInCommand;
        public AppCommand SignInCommand
        {
            get
            {
                if (_SignInCommand == null)
                    _SignInCommand = new ActionCommand(SingIn);
                
                return _SignInCommand;
            } 
            set => _AddStickCommand = value;
        }

        #endregion Command : SignInCommand
        //---------------------------------------------------------------------
        #region Command : SearchCommand

        private AppCommand _SearchCommand;
        public AppCommand SearchCommand
        {
            get
            {
                if (_SearchCommand == null)
                {
                    _SearchCommand = new ActionCommand
                    (
                        param => ExecuteSearchCommand((KeyEventArgs)param),
                        param => CanExecuteSearchCommand((KeyEventArgs)param)
                    );
                }
                return _SearchCommand;
            }
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

        private DelegateCommand<object> _TagSelectedCommand;
        public DelegateCommand<object> TagSelectedCommand
        { 
            get
            {
                if (_TagSelectedCommand == null)
                {
                    _TagSelectedCommand = new DelegateCommand<object>(param =>
                    {
                        // use param as TagModel or TagSelected prop
                        // Code command
                    });
                }

                return _TagSelectedCommand;
            }
        } 

        #endregion Command : TagSelectedCommand
        //---------------------------------------------------------------------
    }
}