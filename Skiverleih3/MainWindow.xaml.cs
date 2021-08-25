using Skiverleih3.Logic;
using Skiverleih3.Model;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Skiverleih3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClass dataClass = new();
        SkiverleihContext skiverleihContext = new();
        public MainWindow()
        {
            InitializeComponent();
            dgHistory.ItemsSource = dataClass.GetHistoryCustomerItems();
            dgItemLentToCustomer.ItemsSource = dataClass.GetItemsAndCustomers();
            cmbBoxItem.ItemsSource = dataClass.GetItems();
            cmbBoxCustomer.ItemsSource = dataClass.GetCustomers();
        }

        /// <summary>
        /// Assigns Item to Customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool skiAlreadyLent = dataClass.LendItemToCustomer((Customer)cmbBoxCustomer.SelectedItem, (Item)cmbBoxItem.SelectedItem);
            if (skiAlreadyLent)
            {
                MessageBox.Show("Dieser Ski wurde bereits ausgeliehen! Warten Sie bis der Besitzer ihn zurückgibt.");
                return;
            }
            else
            {
                dataClass.AddHistoryEntry((Customer)cmbBoxCustomer.SelectedItem, (Item)cmbBoxItem.SelectedItem);
            }
            dgItemLentToCustomer.ItemsSource = dataClass.GetItemsAndCustomers();
            dgHistory.ItemsSource = dataClass.GetHistoryCustomerItems();
        }


        /// <summary>
        /// Returns Item from Customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRet_Click(object sender, RoutedEventArgs e)
        {
            if (cmbBoxItem.SelectedItem == null || cmbBoxCustomer.SelectedItem == null)
            {
                MessageBox.Show("Bitte wählen Sie einen Kunden und einen Ski aus!");
                return;
            }

            if (dataClass.AddReturnDateOnHistory((Customer)cmbBoxCustomer.SelectedItem, (Item)cmbBoxItem.SelectedItem))
            {
                if (dataClass.ReturnItem((Item)cmbBoxItem.SelectedItem))
                {
                    MessageBox.Show("Dieser Ski kann nicht zurückgegeben werden da er gar nicht ausgeliehen wurde.");
                    return;
                }
            }
            dgItemLentToCustomer.ItemsSource = dataClass.GetItemsAndCustomers();
            dgHistory.ItemsSource = dataClass.GetHistoryCustomerItems();
        }

        private void btnBackToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            StartupScreen startupScreen = new StartupScreen();
            startupScreen.Show();
            this.Close();
        }
    }
}
