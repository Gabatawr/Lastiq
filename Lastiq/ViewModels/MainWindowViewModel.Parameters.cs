using Lastiq.Models;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;

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
            set
            {
                Set(ref _SearchText, value);
                StickersCollectionView.Refresh();
            }
        }

        #endregion string : SearchText
        //---------------------------------------------------------------------
        #region ObservableCollection<TagModel> : TagCollection

        private ObservableCollection<TagModel> _TagItemsCollection = new ObservableCollection<TagModel>();
        public ObservableCollection<TagModel> TagCollection
        {
            get => _TagItemsCollection;
            set => Set(ref _TagItemsCollection, value);
        }

        #endregion ObservableCollection<TagModel> : TagCollection
        //---------------------------------------------------------------------
        #region StickCollection

        private ObservableCollection<StickViewModel> _StickCollection = new ObservableCollection<StickViewModel>();
        public ObservableCollection<StickViewModel> StickCollection
        {
            get => _StickCollection;
            set => Set(ref _StickCollection, value);
        }
        public ICollectionView StickersCollectionView;

        void StickCollectionInit()
        {
            StickCollection.CollectionChanged += StickCollectionChanged;
            StickersCollectionView = CollectionViewSource.GetDefaultView(StickCollection);
            StickersCollectionView.Filter = StickCollectionFilter;
        }

        private void StickCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (StickViewModel item in e.NewItems)
                {
                    item.Stick.Tags.OnAdd += TagAdded;
                    item.Stick.Tags.OnRemove += TagRemoved;

                    foreach (var tag in item.Stick.Tags)
                        TagAdded(tag);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (StickViewModel item in e.OldItems)
                {
                    item.Stick.Tags.OnAdd -= TagAdded;
                    item.Stick.Tags.OnRemove -= TagRemoved;

                    foreach (var tag in item.Stick.Tags)
                        TagRemoved(tag);
                }
            }
        }

        #endregion StickCollection
        //---------------------------------------------------------------------
        #region TagModel : TagSelected

        private TagModel _TagSelected;
        public TagModel TagSelected
        {
            get => _TagSelected;
            set
            {
                Set(ref _TagSelected, value); 
                StickersCollectionView.Refresh();
            }

        }

        #endregion TagModel : TagSelected
        //---------------------------------------------------------------------
    }
}
