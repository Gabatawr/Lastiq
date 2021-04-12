using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace Lastiq.Models
{
    [Serializable]
    public class StickModel
    {
        //---------------------------------------------------------------------
        // Main info
        static private int IDCounter = 0;
        public int Id { get; private set; }
        public int CreatorId { get; set; }
        public List<int> FriendsId { get; set; }
            = new List<int>();
        //---------------------------------------------------------------------
        // Contents
        public string Title { get; set; }
        public List<IStickContent> Contents { get; set; }
            = new List<IStickContent>();
        public List<string> Tags { get; set; }
            = new List<string>();
        public DateTime DateTime { get; set; }
            = DateTime.MaxValue;
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
