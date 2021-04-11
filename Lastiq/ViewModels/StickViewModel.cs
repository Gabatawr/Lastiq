using Lastiq.Models;
using Lastiq.ViewModels.Base;
using System.Windows.Media;

namespace Lastiq.ViewModels
{
    public class StickViewModel : ViewModel
    {
        public StickModel Stick { get; set; } = new StickModel();
        
        private SolidColorBrush _color = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE600")) { Opacity = 0.64 };
        public SolidColorBrush Color
        { 
            get => _color;
            set => Set(ref _color, value);
        }
    }
}
