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
        public int Id { get; set; }
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
        public SolidColorBrush Color { get; set; }
            = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE600")) { Opacity = 0.64 };
        //---------------------------------------------------------------------
        public StickModel(int id, int creatorId)
        {
            Id = id;
            CreatorId = creatorId;
        }
        //---------------------------------------------------------------------
    }
}
