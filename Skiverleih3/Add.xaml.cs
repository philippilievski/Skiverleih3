using Skiverleih3.Logic;
using Skiverleih3.Model;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Skiverleih3
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        DataClass dataClass = new DataClass();
        public Add()
        {
            InitializeComponent();
            cmbBoxCategory.ItemsSource = dataClass.GetCategories();
            cmbBoxCustomer.ItemsSource = dataClass.GetCustomers();
            cmbBoxState.ItemsSource = dataClass.GetStates();
        }

        private void txtBoxZipCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //e.Handled = dataClass.CheckIfInputNumericOnly(e.Text);
        }

        /// <summary>
        /// Adds a Customer and its Adress to the Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = new Customer();
                Adress adress = new Adress();
                adress.City = txtBoxCity.Text;
                adress.Country = txtBoxCountry.Text;
                adress.Housenumber = Convert.ToInt32(txtBoxHousenumber.Text);
                adress.Street = txtBoxStreet.Text;
                adress.ZipCode = Convert.ToInt32(txtBoxZipCode.Text);
                dataClass.AddAdress(adress);

                customer.FirstName = txtBoxFirstName.Text;
                customer.LastName = txtBoxLastName.Text;
                customer.Telephonenumber = Convert.ToInt32(txtBoxTelephonenumber.Text);
                customer.DateOfBirth = (DateTime)datePickerDateOfBirth.SelectedDate;
                customer.Adress = adress;
                dataClass.AddCustomer(customer);
                MessageBox.Show("Successfull");
                this.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        /// <summary>
        /// Adds an Item to the Database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmitItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Item item = new Item();
                Category category = new Category();
                State state = new State();
                Customer customer = new Customer();
                category = (Category)cmbBoxCategory.SelectedItem;
                state = (State)cmbBoxState.SelectedItem;
                customer = (Customer)cmbBoxCustomer.SelectedItem;

                item.Lendcount = 0;
                item.Price = Convert.ToDecimal(txtBoxItemPrice.Text);
                item.Title = txtBoxItemTitle.Text;

                item.StateID = state.StateID;
                item.State = state;

                item.CategoryID = category.CategoryID;
                item.Category = category;

                item.CustomerID = customer.CustomerID;
                item.Customer = customer;

                dataClass.AddItem(item);

                if (customer != null)
                {
                    dataClass.AddHistoryEntry(customer, item);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }
    }
}
