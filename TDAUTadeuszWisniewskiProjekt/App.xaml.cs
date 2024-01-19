using System.Configuration;
using System.Data;
using System.Windows;
using TDAUTadeuszWisniewskiProjekt.ViewModels;

namespace TDAUTadeuszWisniewskiProjekt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //laczymy viewModel z View
            MainWindow window = new MainWindow();
            var ViewModel = new MainWindowViewModel();
            window.DataContext = ViewModel;
            window.Show();
        }
    }

}
