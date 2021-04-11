using Lastiq.Model;
using System.Collections.ObjectModel;

namespace Lastiq.ViewModels
{
    partial class MainWindowViewModel
    {
        //---------------------------------------------------------------------
        #region bool : ShowLoginPanel

        private bool _ShowLoginPanel = true;
        public bool ShowLoginPanel
        {
            get => _ShowLoginPanel;
            set => Set(ref _ShowLoginPanel, value);
        }

        #endregion bool : ShowLoginPanel

        #region bool : ShowUserPanel

        private bool _ShowUserPanel = false;
        public bool ShowUserPanel
        {
            get => _ShowUserPanel;
            set => Set(ref _ShowUserPanel, value);
        }

        #endregion bool : ShowUserPanel
        //---------------------------------------------------------------------
        #region string : PasswordText

        private string _PasswordText = string.Empty;
        public string PasswordText
        {
            get => _PasswordText;
            set => Set(ref _PasswordText, value);
        }

        #endregion string : PasswordText
        //---------------------------------------------------------------------
        #region ObservableCollection<TagModel> : TagItemsCollection

        private ObservableCollection<TagModel> _TagItemsCollection = new ObservableCollection<TagModel>();
        public ObservableCollection<TagModel> TagItemsCollection
        {
            get => _TagItemsCollection;
            set => Set(ref _TagItemsCollection, value);
        }

        #endregion ObservableCollection<TagModel> : TagItemsCollection
        //---------------------------------------------------------------------
    }
}
