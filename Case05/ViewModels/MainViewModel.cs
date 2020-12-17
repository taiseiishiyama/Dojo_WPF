using Case05.ViewModels.Commands;
using System.ComponentModel;

namespace Case05.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseProeprtyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _inputString;
        public string InputString
        {
            get => _inputString;
            private set
            {
                if (_inputString == value)
                {
                    return;
                }

                _inputString = value;
                RaiseProeprtyChanged(nameof(InputString));
                
                ClearCommand.RaiseCanExecuteChanged();
                UpperString = value.ToUpper();
            }
        }

        private string _upperString;
        public string UpperString
        {
            get => _upperString;
            private set
            {
                if (_upperString == value)
                {
                    return;
                }

                _upperString = value;
                RaiseProeprtyChanged(nameof(UpperString));
            }
        }

        private DelegateCommand _clearCommand;
        public DelegateCommand ClearCommand
        {
            get => _clearCommand ??= new DelegateCommand(_ => string.IsNullOrEmpty(InputString), _ => InputString = string.Empty);
        }
    }

}
