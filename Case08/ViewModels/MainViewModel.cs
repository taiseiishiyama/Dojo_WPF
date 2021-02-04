using Case08.ViewModels.Commands;
using Case08.Views.Behaviors;
using System.ComponentModel;

namespace Case08.ViewModels
{

    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseProeprtyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private double _dividend;
        public double Dividend
        {
            get => _dividend;
            set
            {
                if (_dividend == value)
                {
                    return;
                }

                _dividend = value;
                RaiseProeprtyChanged(nameof(Dividend));
                CalclateCommand.RaiseCanExecuteChanged();
            }
        }

        private double _divisor;
        public double Divisor
        {
            get => _divisor;
            set
            {
                if (_divisor == value)
                {
                    return;
                }

                _divisor = value;
                RaiseProeprtyChanged(nameof(Divisor));
                CalclateCommand.RaiseCanExecuteChanged();
            }
        }

        private double _result;
        public double Result
        {
            get => _result;
            private set
            {
                if (_result == value)
                {
                    return;
                }

                _result = value;
                RaiseProeprtyChanged(nameof(Result));
            }
        }

        private IMessageDialogParameter _messageDialogParameter;
        public IMessageDialogParameter MessageDialogParameter
        {
            get => _messageDialogParameter;
            private set
            {
                if (_messageDialogParameter == value)
                {
                    return;
                }

                _messageDialogParameter = value;
                RaiseProeprtyChanged(nameof(MessageDialogParameter));
            }
        }

        private DelegateCommand _calclateCommand;
        public DelegateCommand CalclateCommand
        {
            get => _calclateCommand ??= new DelegateCommand(_ => true, _ =>
            {
                var result = Dividend / Divisor;
                if (double.IsNaN(result))
                {
                    MessageDialogParameter = new MessageDialogParameterImpl("計算に失敗しました。");
                    return;
                }

                Result = result;
            });
        }

        private class MessageDialogParameterImpl : IMessageDialogParameter
        {
            public MessageDialogParameterImpl(string message)
            {
                Message = message;
            }

            public string Message { get; }
        }
    }
}
