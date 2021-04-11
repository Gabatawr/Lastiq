using Lastiq.Model;
using Lastiq.ViewModels.Base;

namespace Lastiq.ViewModels
{
    public partial class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            #region TagListTest

            TagItemsCollection.Add(new TagModel() { Text = "TagOne", Count = 1 });
            TagItemsCollection.Add(new TagModel() { Text = "TagTwo", Count = 22 });
            TagItemsCollection.Add(new TagModel() { Text = "TagThree", Count = 333 });

            #endregion TagListTest
        }
    }
}
