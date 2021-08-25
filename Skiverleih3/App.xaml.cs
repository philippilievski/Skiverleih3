using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            /*
            DataWindow dataWindow = new DataWindow();
            dataWindow.Show();
            */
            /*
            MainWindow window = new();
            window.Show();
            */
            
            LoginScreen loginScreen = new();
            loginScreen.Show();
            
        }
    }
}
