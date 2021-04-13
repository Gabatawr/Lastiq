using Lastiq.Models;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace Lastiq.ViewModels
{
    partial class MainWindowViewModel
    {
        //---------------------------------------------------------------------
        #region StickCollectionFilter

        public bool StickCollectionFilter(object obj)
        {
            StickViewModel view = obj as StickViewModel;
            //-------------------------------------------------
            bool searchBoxNotEmpty = string.IsNullOrEmpty(SearchText) is false;
            bool tagListHasSelect = TagSelected != null;

            if (searchBoxNotEmpty is false && tagListHasSelect is false)
                return true;
            //-------------------------------------------------
            bool inTitle, inContent, inTag;
            inTitle = inContent = inTag = false;
            //-------------------------------------------------
            if (searchBoxNotEmpty)
            {
                inTitle = view.Stick.Title.ToLower().Contains(SearchText.ToLower());
                inContent = view.Stick.Contents.Count != 0
                    &&
                    view.Stick.Contents.Any(c =>
                    {
                        string text;
                        if (c is TextContent tc) text = tc.Text;
                        else if (c is CheckboxContent cbc) text = cbc.Text;
                        else return false;
                        
                        return text.ToLower().Contains(SearchText.ToLower());
                    });
            }
            //-------------------------------------------------
            inTag = tagListHasSelect
                && view.Stick.Tags.Contains(TagSelected.Text);
            //-------------------------------------------------
            return inTitle || inContent || inTag;
        }

        #endregion StickCollectionFilter
        //---------------------------------------------------------------------
        #region TagAddRemoveEvents
        private void TagAdded(string tag)
        {
            foreach (var item in TagCollection)
            {
                if (item.Text == tag)
                {
                    item.Count++;
                    return;
                }
            }
            TagCollection.Add(new TagModel(tag));
        }

        private void TagRemoved(string tag)
        {
            foreach (var item in TagCollection)
            {
                if (item.Text == tag)
                {
                    item.Count--;
                    if (item.Count < 1)
                        TagCollection.Remove(item);
                    return;
                }
            }
        }

        #endregion TagEvents
        //---------------------------------------------------------------------
        #region CreateStick

        private void CreateStick(object e)
        {
            var rand = new Random();
            var Stick = new StickModel(creatorId: 0)
            {
                Title = $"New stick",
                Color = new SolidColorBrush(new Color() { A = 255, R = (byte)rand.Next(256), G = (byte)rand.Next(256), B = (byte)rand.Next(256) })
            };
            Stick.Contents.Add(new TextContent($"Text"));
            StickCollection.Add(new StickViewModel() { Stick = Stick });
        }

        #endregion CreateStick
        //---------------------------------------------------------------------
        #region SingIn

        private void SingIn(object e)
        {
            var regexItem = new Regex("^[a-zA-Z0-9_.]*$");

            if (!regexItem.IsMatch(UserName))
            {
                //Show "Restricted symbols in username"
                //Temp
                MessageBox.Show("Restricted symbols in username");
                return;
            }

            if (PasswordText.Length < 8)
            {
                //Show "Password min length is 8"
                //Temp
                MessageBox.Show("Password min length is 8");
                return;
            }
            //TO DO: Call SingIn in model
            bool successfully = true; // bool successfully = SignIn(UserName, PasswordText);

            if (successfully)
            {
                //Do smth
            }
            else
            {
                //Show "Failed to login"
            }
        }

        #endregion SingIn
        //---------------------------------------------------------------------

    }
}
