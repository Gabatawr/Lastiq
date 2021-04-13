using System;
using System.Collections.Generic;


namespace Lastiq.Models
{
    [Serializable]
    public class TagList<T> : List<T>
    {
        public delegate void TagListEventHandler(T item);

        public event TagListEventHandler OnAdd;
        public new void Add(T item)
        {
            if (Contains(item) is false)
            {
                OnAdd?.Invoke(item);
                base.Add(item);
            }
        }

        public event TagListEventHandler OnRemove;
        public new void Remove(T item)
        {
            OnRemove?.Invoke(item);
            base.Remove(item);
        }
    }
}
