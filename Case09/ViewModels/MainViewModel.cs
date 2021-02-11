using Case09.Common;
using Case09.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Case09.ViewModels
{

    internal class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaiseProeprtyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name == value)
                {
                    return;
                }

                _name = value;
                RaiseProeprtyChanged(nameof(Name));
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        private Gender _gender;
        public Gender Gender
        {
            get => _gender;
            set
            {
                if (_gender == value)
                {
                    return;
                }

                _gender = value;
                RaiseProeprtyChanged(nameof(Gender));
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        private int _testScore;
        public int TestScore
        {
            get => _testScore;
            set
            {
                if (_testScore == value)
                {
                    return;
                }

                _testScore = value;
                RaiseProeprtyChanged(nameof(TestScore));
                AddCommand.RaiseCanExecuteChanged();
            }
        }

        private DelegateCommand _addCommand;
        public DelegateCommand AddCommand
        {
            get => _addCommand ??= new DelegateCommand(_ => !string.IsNullOrEmpty(Name), _ =>
            {
                Students.Add(new Student(Name, Gender, TestScore));
            });
        }

        private DelegateCommand _deleteCommand;
        public DelegateCommand DeleteCommand
        {
            get => _deleteCommand ??= new DelegateCommand(_ =>SelectedStudent != default(Student), _ =>
           {
               Students.Remove(SelectedStudent);
           });
        }

        private ObservableCollection<Student> _students;
        public ObservableCollection<Student> Students
        {
            get => _students ??= new ObservableCollection<Student>();
        }

        private Student _selectedStudent;
        public Student SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                if (_selectedStudent == value)
                {
                    return;
                }

                _selectedStudent = value;
                RaiseProeprtyChanged(nameof(TestScore));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }
    }
}