using Skiverleih3.Logic;
using Skiverleih3.Model;
using System;
using System.Windows;

namespace Skiverleih3
{
    /// <summary>
    /// Interaction logic for EditItemsWindow.xaml
    /// </summary>
    public partial class EditItemsWindow : Window
    {
        DataClass dataClass = new DataClass();
        Item item = new Item();
        public delegate void DataChangedEventHandler(object sender, EventArgs e);

        public event DataChangedEventHandler DataChanged;

        public EditItemsWindow()
        {
            InitializeComponent();
        }
        public EditItemsWindow(Item item)
        {
            InitializeComponent();
            lblItemID.Content = item.ItemID;
            txtBoxTitle.Text = item.Title;
            txtBoxPrice.Text = Convert.ToString(item.Price);
            this.item = item;
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            item.Price = Convert.ToDecimal(txtBoxPrice.Text);
            item.Title = txtBoxTitle.Text;

            dataClass.ChangeItem(item);

            DataChangedEventHandler handler = DataChanged;

            if (handler != null)
            {
                handler(this, new EventArgs());
            }
            this.Close();
        }
    }
}
