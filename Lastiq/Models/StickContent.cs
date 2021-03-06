using System;

namespace Lastiq.Models
{
    public interface IStickContent { }

    [Serializable]
    public class CheckboxContent : IStickContent
    {
        public string Text { get; set; } = string.Empty;
        public bool IsChecked { get; set; }
        public CheckboxContent(string text) => Text = text;
    }

    [Serializable]
    public class TextContent : IStickContent
    {
        public string Text { get; set; } = string.Empty;
        public TextContent(string text) => Text = text;
    }
}
