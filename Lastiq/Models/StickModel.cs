using System;
using System.Collections.Generic;
using System.Windows.Media;
using SticksyProtocol;

namespace Lastiq.Models
{
    [Serializable]
    public class StickModel
    {
        //---------------------------------------------------------------------
        // Main info
        static private int IDCounter = 0;
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public List<int> FriendsId { get; set; }
            = new List<int>();
        //---------------------------------------------------------------------
        // Contents
        public string Title { get; set; }
        public List<IStickContentFrontend> Contents { get; set; }
            = new List<IStickContentFrontend>();
        public TagList<string> Tags { get; private set; }
            = new TagList<string>();
        public DateTime DateTime { get; set; }
            = DateTime.Now;
        //---------------------------------------------------------------------
        // View
        static public SolidColorBrush DefColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE600")) { Opacity = 0.64 };
        public SolidColorBrush Color { get; set; } = DefColor;
        //---------------------------------------------------------------------
        public StickModel(int creatorId)
        {
            Id = IDCounter++;
            CreatorId = creatorId;
        }
        //---------------------------------------------------------------------
    }
}
