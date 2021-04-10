using Chatyx.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Chatyx.Model
{
    [Serializable]
    public class MessageModel
    {
        //-----------------------------------------------------
        public string Time { get; init; } = " " + DateTime.Now.ToString("t");
        //-----------------------------------------------------
        public string SenderName { get; } = ((MainWindowViewModel)Application.Current.MainWindow.DataContext).LoginParam;
        //-----------------------------------------------------
        public string? Text { get; init; }
        public List<byte[]> Images { get; init; }
        //-----------------------------------------------------
    }
}