using Lastiq.Models;
using Lastiq.ViewModels.Base;
using System.ComponentModel;
using System.Windows.Media;

namespace Lastiq.ViewModels
{
    public class StickViewModel : ViewModel
    {
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
    }
}
