using Lastiq.Models;
using Lastiq.ViewModels.Base;
using System;
using System.Windows.Media;

namespace Lastiq.ViewModels
{
    public partial class MainWindowViewModel : ViewModel
    {
        public MainWindowViewModel()
        {
            //---------------------------------------------------------------------
            // Preseting
            StickCollectionInit();
            //---------------------------------------------------------------------

            #region TagListTest

            TagCollection.Add(new TagModel("TagOne"));
            TagCollection.Add(new TagModel("TagTwo"));
            TagCollection.Add(new TagModel("TagThree"));

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

                for (int t = 0; t < rand.Next(TagCollection.Count); t++)
                {
                    Stick.Tags.Add(TagCollection[t].Text);
                }

                StickCollection.Add(new StickViewModel() { Stick = Stick });
            }

            #endregion StickListTest
        }
    }
}
