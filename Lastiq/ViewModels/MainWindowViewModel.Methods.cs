using Lastiq.Models;
using System.ComponentModel;
using System.Linq;

namespace Lastiq.ViewModels
{
    partial class MainWindowViewModel
    {
        public bool StickersFilter(object obj)
        {
            StickViewModel view = obj as StickViewModel;

            //Comparing sticker text and searcher text
            if (view.Stick.Contents.Count == 0) return false;

            return view.Stick.Contents.Any(c =>
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
