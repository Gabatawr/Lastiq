using Lastiq.Models;
using System.ComponentModel;
using System.Linq;

namespace Lastiq.ViewModels
{
    partial class MainWindowViewModel
    {
        public void OnPropertyChanged(object obj, PropertyChangedEventArgs args)
        {
            switch (args.PropertyName)
            {
                case nameof(SearchText):
                    StickersCollectionView.Refresh();
                    break;

                default:
                    break;
            }
        }

        public bool StickersFilter(object obj)
        {
            StickViewModel stick = obj as StickViewModel;

            //Comparing sticker text and searcher text
            return stick.Stick.Contents.Any(c =>
            {
                string text;
                if (c is TextContent tc) text = tc.Text;
                else if (c is CheckboxContent cbc) text = cbc.Text;
                else return false;

                return text.ToLower().Contains(SearchText.ToLower());
            });

            //TO DO:
            //Compare tags
        }
    }
}
