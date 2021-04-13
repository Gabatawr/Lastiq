using Lastiq.Infrastructure.Commands.Base;
using Lastiq.Models;
using Lastiq.ViewModels.Base;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using Lastiq.Infrastructure.Commands.Base;

namespace Lastiq.ViewModels
{
    public class StickViewModel : ViewModel
    {
        //---------------------------------------------------------------------
        private bool _readOnly = true;
        public bool ReadOnly
        {
            get => _readOnly;
            set
            {
                _readOnly = value;
                OnPropertyChanged();
            }
        }
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
        public void StickViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Stick))
            {
                var svm = sender as StickViewModel;

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
    }
}
