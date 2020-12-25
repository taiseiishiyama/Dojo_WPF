using Case06.ViewModels.Commands;
using System.ComponentModel;

namespace Case06.ViewModels
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
                if(_result == value)
                {
                    return;
                }

                _result = value;
                RaiseProeprtyChanged(nameof(Result));
            }
        }

        private DelegateCommand _calclateCommand;
        public DelegateCommand CalclateCommand
        {
            get => _calclateCommand ??= new DelegateCommand(_ => true, _ => Result = Dividend / Divisor);
        }
    }

}
