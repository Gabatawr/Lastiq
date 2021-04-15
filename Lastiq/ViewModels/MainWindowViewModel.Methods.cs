using Lastiq.Models;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using SticksyClient;
using SticksyProtocol;


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
                        if (c is TextContent tc) text = tc.text;
                        else if (c is CheckboxContent cbc) text = cbc.text;
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
            if (OfflineMode)
            {
                var stick = new StickViewModel();
                    stick.Stick.Title = "Title";
                    stick.Stick.Contents.Add(new TextContentFrontend("Sample text"));
                StickCollection.Add(stick);
            }
            else
                Client.Sender.CreateSticker();
        }

        private void ProcessCreateStickResult(AnswerId answer)
        {
            var stick = new StickViewModel();
            stick.FromStick(Client.Listener.СreatingStickerForHander(answer));
            StickCollection.Add(stick);
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
                MessageBox.Show("Restricted symbols in username");
                return;
            }

            if (PasswordText.Length < 8)
            {
                //Show "Password min length is 8"
                MessageBox.Show("Password min length is 8");
                return;
            }
            
            //Sing in
            if(!OfflineMode)
                Client.Sender.SignIn(UserName, PasswordText);
        }

        private void ProcessSingInResult(AnswerUser answer)
        {
            if (Client.Listener.SignInForHandler(answer))
            {
                MessageBox.Show("Login successful");
            }
            else
            {
                MessageBox.Show("Failed to login");
            }
        }

        #endregion SingIn
        //---------------------------------------------------------------------
        //TO DO:
        #region SingUp

        private void SingUp(object e)
        {
            var regexItem = new Regex("^[a-zA-Z0-9_.]*$");
            
            //TO DO:

            //// if (!regexItem.IsMatch( *Login* ))
            //{
            //    //Show "Restricted symbols in username"
            //    MessageBox.Show("Restricted symbols in username");
            //    return;
            //}

            ////if (*Password* .Length < 8)
            //{
            //    //Show "Password min length is 8"
            //    MessageBox.Show("Password min length is 8");
            //    return;
            //}

            ////Sing in
            //if (!OfflineMode)
            //    Client.Sender.SignUp(UserName, PasswordText);
        }

        private void ProcessSingUpResult(AnswerId id)
        {
            //TO DO:
            ////if (Client.Listener.SignUpForHandler(id, *Login* , *Password* ))
            //{
            //    MessageBox.Show("SingUp successful");
            //}
            //else
            //{
            //    MessageBox.Show("Failed to SingUp");
            //}
        }

        #endregion SingIn
        //---------------------------------------------------------------------
        #region RemoveSticker

        public void RemoveSticker(StickViewModel sticker)
        {
            if(!OfflineMode)
                Client.Sender.DeleteSticker(Client.User.sticks.IndexOf(sticker.ToStick()));
            StickCollection.Remove(sticker);
        }

        #endregion RemoveSticker
        //---------------------------------------------------------------------
        #region StickerEdited

        public void StickerEdited(StickViewModel sticker)
        {
            if(!OfflineMode)
                Client.Sender.SaveSticker(sticker.ToStick(), GetIndexOfSticker(sticker));
        }

        #endregion StickerEdited
        //---------------------------------------------------------------------
        #region TagsChanged
        
        public void TagsChanged(StickViewModel sticker)
        {
            if(!OfflineMode)
                Client.Sender.EditTags(GetIndexOfSticker(sticker), sticker.Stick.Tags);
        }

        #endregion
        //---------------------------------------------------------------------
        //TO DO:
        #region ReceiveUsers

        //Send request for users list to server
        public void RequestUsers()
        {
            Client.Sender.GetUsers();
        }

        //Receiving users list from server
        public void ReceiveUsers(AnswerListUser userList)
        {
            //TO DO:
        }

        #endregion
        //---------------------------------------------------------------------
        public int GetIndexOfSticker(StickViewModel sticker)
        {
            return Client.User.sticks.IndexOf(Client.User.sticks.Find((stick => stick.id == sticker.Stick.Id)));
        }
    }
}
