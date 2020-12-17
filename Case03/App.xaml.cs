using System.Windows;
using Case03.ViewModels;

namespace Case03
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var w = new MainWindow();
            var vm = new MainViewModel();
            w.DataContext = vm;
            w.Show();
        }
    }
}
