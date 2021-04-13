using Lastiq.Infrastructure.Commands.Base;
using Lastiq.Models;
using Lastiq.ViewModels.Base;
using System.Windows;
using System.Windows.Media;
using Lastiq.Infrastructure.Commands.Base;

namespace Lastiq.ViewModels
{
    public class StickViewModel : ViewModel
    {
        //---------------------------------------------------------------------
        private static MainWindowViewModel MainViewModel
            => (MainWindowViewModel) Application.Current.MainWindow.DataContext;
        //---------------------------------------------------------------------
        public StickModel Stick { get; set; } = new StickModel(creatorId: 0);
        //---------------------------------------------------------------------
        private SolidColorBrush _color = StickModel.DefColor;
        public SolidColorBrush Color
        { 
            get => Stick.Color;
            set
            {
                if (Set(ref _color, value))
                    Stick.Color = _color;
            }
        }
        //---------------------------------------------------------------------
        #region Command : DeleteStickCommand

        private AppCommand _DeleteStickCommand;
        public AppCommand DeleteStickCommand
        {
            get => _DeleteStickCommand ?? (_DeleteStickCommand = new ActionCommand(DeleteStick));
            set => _DeleteStickCommand = value;
        }

        private void DeleteStick(object obj) => MainViewModel.StickCollection.Remove(this);

        #endregion Command : DeleteStickCommand
        //---------------------------------------------------------------------
        #region Command : EditStickCommand

        private AppCommand _EditStickCommand;
        public AppCommand EditStickCommand
        {
            get => _EditStickCommand ?? (_EditStickCommand = new ActionCommand(EditStick));
            set => _EditStickCommand = value;
        }

        private void EditStick(object obj)
        {
            ReadOnly = !ReadOnly;
        }

        #endregion Command : EditStickCommand
        //---------------------------------------------------------------------
        #region bool : StickReadOnly

        private bool _ReadOnly = true;
        public bool ReadOnly
        {
            get => _ReadOnly;
            set => Set(ref _ReadOnly, value);
        }

        #endregion bool : StickReadOnly
        //---------------------------------------------------------------------
    }
}
