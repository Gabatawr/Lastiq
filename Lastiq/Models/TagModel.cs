namespace Lastiq.Models
{
    public class TagModel
    {
        private string _text;
        public string Text
        {
            get => "#" + _text;
            set => _text = value.Trim('#');
        }
        public int Count { get; set; }
    }
}
