using Skiverleih3.Logic;
using System.Windows;

namespace Skiverleih3
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        string username;
        string pwHash;
        public LoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            username = txtBoxUsername.Text;
            pwHash = Hashing.Compute256Hash(txtBoxPassword.Password);
            if (Hashing.Validation(username, pwHash))
            {
                StartupScreen startupScreen = new();
                this.Hide();
                startupScreen.Show();
            }
            else
            {
                MessageBox.Show("Password Incorrect");
            }

        }
    }
}
