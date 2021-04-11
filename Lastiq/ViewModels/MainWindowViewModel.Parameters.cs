using Lastiq.Infrastructure.Commands.Base;
using Lastiq.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;

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
        #region string : UserName

        private string _UserName = string.Empty;
        public string UserName
        {
            get => _UserName;
            set => Set(ref _UserName, value);
        }

        #endregion string : UserName
        //---------------------------------------------------------------------
        #region string : SearchText

        private string _SearchText = string.Empty;
        public string SearchText
        {
            get => _SearchText;
            set => Set(ref _SearchText, value);
        }

        #endregion string : SearchText
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
        #region ObservableCollection<StickViewModel> : StickCollection

        private ObservableCollection<StickViewModel> _StickCollection = new ObservableCollection<StickViewModel>();
        public ObservableCollection<StickViewModel> StickCollection
        {
            get => _StickCollection;
            set => Set(ref _StickCollection, value);
        }

        #endregion ObservableCollection<StickViewModel> : StickCollection
        //---------------------------------------------------------------------
        #region TagModel : TagSelected

        private TagModel _TagSelected;
        public TagModel TagSelected
        {
            get => _TagSelected;
            set => Set(ref _TagSelected, value);
        }

        #endregion TagModel : TagSelected
        //---------------------------------------------------------------------

    }
}
