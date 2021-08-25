using Skiverleih3.Logic;
using Skiverleih3.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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

        private void txtBoxSearchForCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*
            var items = dataClass.GetItems();
            var filter = items.Where(items => items.Title.StartsWith(txtBoxSearchForCustomer.Text, StringComparison.CurrentCultureIgnoreCase));
            dgHistory.ItemsSource = filter;
            */
        }

        private void btnRet_Click(object sender, RoutedEventArgs e)
        {

            if (cmbBoxItem.SelectedItem == null || cmbBoxCustomer.SelectedItem == null)
            {
                MessageBox.Show("Bitte wählen Sie einen Kunden und einen Ski aus!");
                return;
            }

            if (dataClass.AddReturnDateOnHistory((Customer)cmbBoxCustomer.SelectedItem, (Item)cmbBoxItem.SelectedItem))
            {
                if(dataClass.ReturnItem((Item)cmbBoxItem.SelectedItem))
                {
                    MessageBox.Show("Dieser Ski kann nicht zurückgegeben werden da er gar nicht ausgeliehen wurde.");
                    return;
                }
            }
            dgItemLentToCustomer.ItemsSource = dataClass.GetItemsAndCustomers();
            dgHistory.ItemsSource = dataClass.GetHistoryCustomerItems();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            /*
            EditCustomer edit = new EditCustomer((CustomerItems)dgItemLentToCustomer.SelectedItem);
            this.Hide();
            edit.Show();
            */
        }

        private void dgItemLentToCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            object item = dgItemLentToCustomer.SelectedItem;
            string blub = (dgItemLentToCustomer.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
            Trace.WriteLine(blub);
            */
            CustomerItems customeritems = (CustomerItems)dgItemLentToCustomer.SelectedItem;
            Trace.Write(customeritems.ItemID);
            Trace.WriteLine(dgItemLentToCustomer.SelectedItem);
        }

        private void btnEditCust_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
