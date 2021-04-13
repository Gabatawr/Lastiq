namespace Lastiq.Models
{
    public class TagModel
    {
        public string Text { get; set; }
        public int Count { get; set; } = 1;

        public TagModel(string tag) => Text = tag;
    }
}
