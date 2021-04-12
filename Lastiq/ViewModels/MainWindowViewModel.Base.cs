using System.Windows.Data;
using System.Windows.Media;
using Lastiq.Models;
using Lastiq.ViewModels.Base;

namespace Lastiq.ViewModels
{
    public partial class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            #region TagListTest

            TagItemsCollection.Add(new TagModel() { Text = "TagOne", Count = 1 });
            TagItemsCollection.Add(new TagModel() { Text = "TagTwo", Count = 22 });
            TagItemsCollection.Add(new TagModel() { Text = "TagThree", Count = 333 });

            #endregion TagListTest

            #region StickListTest

            StickCollection.Add(new StickViewModel() {Color = new SolidColorBrush(Colors.Yellow), Stick = {Text = "Sticker one"}});
            StickCollection.Add(new StickViewModel() { Color = new SolidColorBrush(Colors.Red), Stick = { Text = "Sticker two" } });
            StickCollection.Add(new StickViewModel() { Color = new SolidColorBrush(Colors.Green), Stick = { Text = "Sticker three" } });

            #endregion StickListTest

            PropertyChanged += OnPropertyChanged;
            
            StickersCollectionView = CollectionViewSource.GetDefaultView(StickCollection);
            StickersCollectionView.Filter = StickersFilter;
        }
    }
}
