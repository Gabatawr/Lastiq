using Lastiq.Models;
using Lastiq.ViewModels.Base;
using System.Windows.Data;
using System.Windows.Media;

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

            StickCollection.Add(new StickViewModel() { Color = new SolidColorBrush(Colors.Yellow) });
            StickCollection[0].Stick.Contents.Add(new TextContent("Sticker one"));

            StickCollection.Add(new StickViewModel() { Color = new SolidColorBrush(Colors.Red) });
            StickCollection[1].Stick.Contents.Add(new TextContent("Sticker two"));

            StickCollection.Add(new StickViewModel() { Color = new SolidColorBrush(Colors.Green) });
            StickCollection[2].Stick.Contents.Add(new TextContent("Sticker three"));

            #endregion StickListTest

            PropertyChanged += OnPropertyChanged;

            StickersCollectionView = CollectionViewSource.GetDefaultView(StickCollection);
            StickersCollectionView.Filter = StickersFilter;
        }
    }
}
