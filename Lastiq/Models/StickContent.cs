using System;
using System.Net.Mime;
using SticksyProtocol;

namespace Lastiq.Models
{
    public interface IStickContentFrontend { }

    [Serializable]
    public class CheckboxContentFrontend : IStickContentFrontend
    {
        public string Text { get; set; } = string.Empty;
        public bool IsChecked { get; set; }
        public CheckboxContentFrontend(string text) => Text = text;

        public CheckboxContentFrontend(CheckboxContent content)
        {
            Text = content.text;
            IsChecked = content.isChecked;
        }

        public CheckboxContent ToSticksyCheckBoxContent()
        {
            return new CheckboxContent(Text) {isChecked = IsChecked};
        }
    }

    [Serializable]
    public class TextContentFrontend : IStickContentFrontend
    {
        public string Text { get; set; } = string.Empty;
        public TextContentFrontend(string text) => Text = text;
        
        public TextContentFrontend(TextContent content) => Text = content.text;

        public TextContent ToSticksyTextContent()
        {
            return new TextContent(Text);
        }
    }
}
