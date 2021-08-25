using Skiverleih3.Logic;
using Skiverleih3.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Skiverleih3
{
    /// <summary>
    /// Interaction logic for EditCustomersWindow.xaml
    /// </summary>
    public partial class EditCustomersWindow : Window
    {
        public delegate void DataChangedEventHandler(object sender, EventArgs e);

        public event DataChangedEventHandler DataChanged;

        DataClass dataClass = new DataClass();
        Customer customer = new Customer();
        public EditCustomersWindow()
        {
            InitializeComponent();
        }
        public EditCustomersWindow(Customer customer)
        {
            InitializeComponent();
            Trace.WriteLine(customer.FirstName);
            lblCustomerID.Content = customer.CustomerID;
            txtBoxFirstname.Text = customer.FirstName;
            txtBoxLastname.Text = customer.LastName;
            txtBoxPhonenumber.Text = Convert.ToString(customer.Telephonenumber);
            this.customer = customer;
        }

        public void btnChange_Click(object sender, RoutedEventArgs e)
        {
            customer.FirstName = txtBoxFirstname.Text;
            customer.LastName = txtBoxLastname.Text;
            customer.Telephonenumber = Convert.ToInt32(txtBoxPhonenumber.Text);

            dataClass.ChangeCustomer(customer);

            DataChangedEventHandler handler = DataChanged;

            if (handler != null)
            {
                handler(this, new EventArgs());
            }

            this.Close();
        }
    }
}
