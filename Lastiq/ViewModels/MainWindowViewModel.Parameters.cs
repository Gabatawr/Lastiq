using Lastiq.Model;
using System.Collections.ObjectModel;

namespace Lastiq.ViewModels
{
    partial class MainWindowViewModel
    {
        //---------------------------------------------------------------------
        #region ObservableCollection<TagModel> : TagItemsCollection

        // if async
        //public object MessageItemsBlock = new object();
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
