using System.Windows;

namespace Skiverleih3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginScreen loginScreen = new();
            loginScreen.Show();

        }
    }
}
