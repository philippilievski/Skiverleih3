using System.Windows;

namespace Skiverleih3
{
    /// <summary>
    /// Interaction logic for StartupScreen.xaml
    /// </summary>
    public partial class StartupScreen : Window
    {
        public StartupScreen()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            DataWindow dataWindow = new DataWindow();
            this.Hide();
            dataWindow.Show();
        }

        private void btnVerleih_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            add.Show();
        }
    }
}
