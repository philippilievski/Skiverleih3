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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Skiverleih3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClass dataClass = new DataClass();
        SkiverleihContext skiverleihContext = new SkiverleihContext();
        public MainWindow()
        {
            InitializeComponent();
            dgItemLentToCustomer.ItemsSource = dataClass.GetItemsAndCustomers();
            dgItems.ItemsSource = dataClass.GetItems();
            cmbBoxItem.ItemsSource = dataClass.GetItems();
            cmbBoxCustomer.ItemsSource = dataClass.GetCustomers();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool skiAlreadyLent = dataClass.LendItemToCustomer((Customer)cmbBoxCustomer.SelectedItem, (Item)cmbBoxItem.SelectedItem);
            if(skiAlreadyLent)
            {
                MessageBox.Show("Dieser Ski wurde bereits ausgeliehen! Warten Sie bis der Besitzer ihn zurückgibt.");
            }
            dgItemLentToCustomer.ItemsSource = dataClass.GetItemsAndCustomers();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            bool itemIsLent;
            if (dgItems.SelectedItem == null)
            {
                MessageBox.Show("Bitte wählen sie in der Tabelle ein Ski aus!");
            }
            else
            {
                itemIsLent = dataClass.ReturnItem((Item)dgItems.SelectedItem);
                if(itemIsLent)
                {
                    MessageBox.Show("Dieser Ski kann nicht zurückgegeben werden da er gar nicht ausgeliehen wurde.");
                }
            }
            dgItemLentToCustomer.ItemsSource = dataClass.GetItemsAndCustomers();
        }

        private void txtBoxSearchForCustomer_TextChanged(object sender, TextChangedEventArgs e)
        {
            var items = dataClass.GetItems();
            var filter = items.Where(items => items.Title.StartsWith(txtBoxSearchForCustomer.Text, StringComparison.CurrentCultureIgnoreCase));
            dgItems.ItemsSource = filter;
        }
    }
}
