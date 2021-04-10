using Chatyx.Infrastructure.Commands.Base;
using Chatyx.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Chatyx.ViewModels
{
    class ShowImageWindowViewModel : ViewModel
    {
        #region Command : CloseWindowCommand
        public Action CloseAction { get; set; }

        private AppCommand _CloseWindowCommand;
        public AppCommand CloseWindowCommand
        {
            get => _CloseWindowCommand ?? new ActionCommand
                (
                    param => ExecuteCloseWindowCommand((MouseEventArgs)param)
                );
            set => _CloseWindowCommand = value;
        }
        private void ExecuteCloseWindowCommand(MouseEventArgs e) => CloseAction.Invoke();

        #endregion Command : CloseWindowCommand
        #region Command : MoveWindowCommand
        public Action MoveAction { get; set; }

        private AppCommand _MoveWindowCommand;
        public AppCommand MoveWindowCommand
        {
            get => _MoveWindowCommand ?? new ActionCommand
                (
                    param => ExecuteMoveWindowCommand((MouseEventArgs)param)
                );
            set => _MoveWindowCommand = value;
        }
        private void ExecuteMoveWindowCommand(MouseEventArgs e) => MoveAction.Invoke();

        #endregion Command : MoveWindowCommand

        #region byte[] : CurrentImageParam

        private byte[] _CurrentImageParam;
        public byte[] CurrentImageParam
        {
            get => _CurrentImageParam;
            set => Set(ref _CurrentImageParam, value);
        }

        #endregion byte[] : CurrentImageParam
        #region List<byte[]> : ImageCollections

        private List<byte[]> _ImageCollection;
        public List<byte[]> ImageCollection
        {
            get => _ImageCollection;
            set => Set(ref _ImageCollection, value);
        }

        #endregion List<byte[]> : ImageCollections

        #region Command : ChangeImageCommand

        private AppCommand _ChangeImageCommand;
        public AppCommand ChangeImageCommand
        {
            get => _ChangeImageCommand ?? new ActionCommand
                (
                    param => ExecuteChangeImageCommand((MouseWheelEventArgs)param),
                    param => CanExecuteChangeImageCommand((MouseWheelEventArgs)param)
                );
            set => _ChangeImageCommand = value;
        }
        private void ExecuteChangeImageCommand(MouseWheelEventArgs e)
        {
            int pos = ImageCollection.IndexOf(CurrentImageParam);
            if (e.Delta < 0)
            {
                if (pos < ImageCollection.Count - 1) CurrentImageParam = ImageCollection[pos + 1];
            }
            else
            {
                if (pos > 0) CurrentImageParam = ImageCollection[pos - 1];
            }
        }
        private bool CanExecuteChangeImageCommand(MouseWheelEventArgs e) => ImageCollection.Count > 1;

        #endregion Command : ChangeImageCommand
    }
}
