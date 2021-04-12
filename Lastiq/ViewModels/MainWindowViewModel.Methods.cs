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
            
            bool search = 
                view.Stick.Title.ToLower().Contains(SearchText.ToLower())
                    //Title contains searched text
                ||  //OR
                    //Content contains searched text
                view.Stick.Contents.Any(c =>                    
                {
                    string text;
                    if (c is TextContent tc) text = tc.Text;
                    else if (c is CheckboxContent cbc) text = cbc.Text;
                    else return false;

                    return text.ToLower().Contains(SearchText.ToLower());
                });

            //Comparing selected tag with sticker tag
            bool tag = true;
            if (TagSelected != null) tag = view.Stick.Tags.Contains(TagSelected.Text);
            
            return search && tag;
        }
    }
}
