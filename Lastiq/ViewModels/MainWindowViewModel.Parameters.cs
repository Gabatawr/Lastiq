using Lastiq.Infrastructure.Commands.Base;
using Lastiq.Models;
using System;
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
        #region string : UserName

        private string _UserName = string.Empty;
        public string UserName
        {
            get => _UserName;
            set => Set(ref _UserName, value);
        }

        #endregion string : UserName
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

        #region Command : TestAddCommand

        private AppCommand _TestAddCommand;
        public AppCommand TestAddCommand
        {
            get => _TestAddCommand ?? new ActionCommand
                (
                    param => ExecuteTestAddCommand(param)
                );
            set => _TestAddCommand = value;
        }

        private static Random r = new Random();
        private void ExecuteTestAddCommand(object e)
        {
            StickCollection.Add(new StickViewModel());
        }

        #endregion Command : TestAddCommand
    }
}
