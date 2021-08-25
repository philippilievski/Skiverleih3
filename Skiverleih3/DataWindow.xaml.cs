using Skiverleih3.Logic;
using Skiverleih3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Skiverleih3
{
    /// <summary>
    /// Interaction logic for DataWindow.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        DataClass dataClass = new DataClass();
        public DataWindow()
        {
            InitializeComponent();
            dgCustomers.ItemsSource = dataClass.GetCustomers();
            dgItems.ItemsSource = dataClass.GetItems();
        }
        
        public void dataChanged(object sender, EventArgs e)
        {
            dgCustomers.ItemsSource = dataClass.GetCustomers();
            dgItems.ItemsSource = dataClass.GetItems();
        }

        private void btnToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }

        private void btnCustomerEdit_Click(object sender, RoutedEventArgs e)
        {
            EditCustomersWindow editCustomer = new EditCustomersWindow((Customer)dgCustomers.SelectedItem);
            editCustomer.DataChanged += dataChanged;
            editCustomer.Show();
        }

        private void btnItemEdit_Click(object sender, RoutedEventArgs e)
        {
            EditItemsWindow editItemsWindow = new EditItemsWindow((Item)dgItems.SelectedItem);
            editItemsWindow.DataChanged += dataChanged;
            editItemsWindow.Show();
        }
    }
}
