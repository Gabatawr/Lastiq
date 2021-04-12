using Lastiq.Models;
using Lastiq.ViewModels.Base;
using System;
using System.Windows.Data;
using System.Windows.Media;

namespace Lastiq.ViewModels
{
    public partial class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            //---------------------------------------------------------------------
            // Preseting
            StickersCollectionView = CollectionViewSource.GetDefaultView(StickCollection);
            //---------------------------------------------------------------------

            #region TagListTest

            TagItemsCollection.Add(new TagModel() { Text = "TagOne", Count = 1 });
            TagItemsCollection.Add(new TagModel() { Text = "TagTwo", Count = 22 });
            TagItemsCollection.Add(new TagModel() { Text = "TagThree", Count = 333 });

            #endregion TagListTest

            #region StickListTest

            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                var Stick = new StickModel(creatorId: 0)
                {
                    Title = $"Stick {i} Title",
                    Color = new SolidColorBrush(new Color() { A = 255, R = (byte)rand.Next(256), G = (byte)rand.Next(256), B = (byte)rand.Next(256) })
                };
                Stick.Contents.Add(new TextContent($"Teeeee eeeee eeeeeee eeeeeeeeee eeeeeee eeeeeeeeee eeeeeeeeeeee eeeeeeeeeee eeeeeeeee ee eeext {i}"));
                Stick.Contents.Add(new CheckboxContent($"Checkbox {i}"));

                for (int t = 0; t < rand.Next(5); t++)
                {
                    Stick.Tags.Add($"Tag {t}");
                }
                
                StickCollection.Add(new StickViewModel() { Stick = Stick });
            }

            #endregion StickListTest
        }
    }
}
