using Chatyx.Infrastructure.Commands;
using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Model;
using System.Windows;
using System.Windows.Media;

namespace Chatyx.ViewModels
{
    public class MessageVievModel
    {
        //-----------------------------------------------------
        public HorizontalAlignment Alignment { get; init; } = HorizontalAlignment.Left;
        public SolidColorBrush Background { get; init; } = Brushes.Black;
        public SolidColorBrush Foreground { get; init; } = Brushes.White;
        //-----------------------------------------------------
        public MessageModel Message { get; private set; }
        //-----------------------------------------------------
        public MessageVievModel(MessageModel message) => Message = message;
        //-----------------------------------------------------
        #region Command : OpenImagesCommand

        private AppCommand _OpenImagesCommand;
        public AppCommand OpenImagesCommand
        {
            get => _OpenImagesCommand ??= new OpenImagesCommand();
            set => _OpenImagesCommand = value;
        }

        #endregion Command : OpenImagesCommand
        //-----------------------------------------------------
    }
}
