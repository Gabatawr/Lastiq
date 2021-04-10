using Chatyx.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Chatyx.Views.Windows
{
    public partial class ShowImageWindow : Window
    {
        public ShowImageWindow(List<byte[]> images)
        {
            InitializeComponent();

            var vm = DataContext as ShowImageWindowViewModel;

            vm.ImageCollection = images;
            vm.CurrentImageParam = images[0];

            vm.CloseAction = new Action(Close);
            vm.MoveAction = new Action(DragMove);
        }
    }
}
