using System.ComponentModel;

namespace Lastiq.ViewModels
{
    partial class MainWindowViewModel
    {
        public void OnPropertyChanged(object obj, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case nameof(SearchText): StickersCollectionView.Refresh();
                    break;
                default:
                    break;
            }
        }

        public bool StickersFilter(object obj)
        {
            StickViewModel stick = obj as StickViewModel;
            
            //Comparing sticker text and searcher text
            return stick.Stick.Text.ToLower().Contains(SearchText.ToLower());

            //TO DO:
            //Compare tags
        }
    }
}
