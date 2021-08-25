using Skiverleih3.Logic;
using Skiverleih3.Model;
using System;
using System.Windows;

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
