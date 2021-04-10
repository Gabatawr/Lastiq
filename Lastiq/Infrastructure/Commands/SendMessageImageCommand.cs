using Chatyx.Infrastructure.Commands.Base;
using Chatyx.Model;
using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;

namespace Chatyx.Infrastructure.Commands
{
    class SendMessageImageCommand : AppCommand
    {
        public override void Command(object e)
        {
            OpenFileDialog ofd = new() 
            {
                Title = "Open image",
                Filter = "PNG (*.png)|*.png",
                Multiselect = true
            };

            if (ofd.ShowDialog() == true)
            {
                MessageModel msg = new() { Images = new() };
                foreach (var fileName in ofd.FileNames)
                {
                    using (MemoryStream ms = new())
                    {
                        var b = new Bitmap(fileName);
                        b.Save(ms, ImageFormat.Png);

                        msg.Images.Add(ms.ToArray());
                    }
                }
                vm.AppConnect.SendMessage(msg);
                vm.ViewMessage(msg, HorizontalAlignment.Right);
            }
        }

        public override bool CanExecute(object e) => true;
    }
}
