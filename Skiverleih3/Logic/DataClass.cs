using Skiverleih3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace Skiverleih3.Logic
{
    class DataClass
    {
        SkiverleihContext skiverleihContext = new();
        private static readonly Regex _regex = new Regex("[^0-9.-]+");

        /// <summary>
        /// Function joins two tables Items and Customers and writes queried data into a table
        /// </summary>
        /// <returns>List of Customers></returns>
        public List<CustomerItems> GetItemsAndCustomers()
        {
            List<CustomerItems> customerItems = (from item in skiverleihContext.Items
                                                 join customer in skiverleihContext.Customers on item.CustomerID equals customer.CustomerID
                                                 join state in skiverleihContext.States on item.StateID equals state.StateID
                                                 select new CustomerItems
                                                 {
                                                     CustomerID = customer.CustomerID,
                                                     FirstName = customer.FirstName,
                                                     LastName = customer.LastName,
                                                     ItemID = item.ItemID,
                                                     Title = item.Title,
                                                     State = item.State
                                                 }).ToList();

            return customerItems;
        }

        /// <summary>
        /// Joins and returns a list of the History, Customer and Items Table 
        /// </summary>
        /// <returns>IEnumerable</returns>
        public IEnumerable<object> GetHistoryCustomerItems()
        {
            var historycustomeritem = (from history in skiverleihContext.Histories
                                       join customer in skiverleihContext.Customers on history.CustomerID equals customer.CustomerID
                                       join item in skiverleihContext.Items on history.ItemID equals item.ItemID
                                       select new { history.HistoryID, customer.FirstName, customer.LastName, item.Title, history.LoanedOn, history.ReturnedOn }).ToList();

            return historycustomeritem;
        }

        public List<Item> GetItems()
        {
            var items = skiverleihContext.Items
                .ToList();

            return items;
        }

        public List<Customer> GetCustomers()
        {
            var customers = skiverleihContext.Customers
                .ToList();

            return customers;
        }
        public List<Category> GetCategories()
        {
            var categories = skiverleihContext.Categories
                .ToList();
            return categories;
        }
        public List<State> GetStates()
        {
            var states = skiverleihContext.States
                .ToList();
            return states;
        }

        /// <summary>
        /// Updates the Customer
        /// </summary>
        /// <param name="customer">Customer</param>
        public void ChangeCustomer(Customer customer)
        {
            skiverleihContext.Update(customer);
            skiverleihContext.SaveChanges();
        }

        /// <summary>
        /// Updates an Item
        /// </summary>
        /// <param name="item">Item</param>
        public void ChangeItem(Item item)
        {
            skiverleihContext.Update(item);
            skiverleihContext.SaveChanges();
        }

        public void AddCustomer(Customer customer)
        {
            skiverleihContext.Add(customer);
            skiverleihContext.SaveChanges();
        }
        public void AddAdress(Adress adress)
        {
            skiverleihContext.Add(adress);
            skiverleihContext.SaveChanges();
        }

        public void AddItem(Item item)
        {
            skiverleihContext.Add(item);
            skiverleihContext.SaveChanges();
        }


        public void AddHistoryEntry(Customer customer, Item item)
        {
            var HiEnt = new History()
            {
                CustomerID = customer.CustomerID,
                ItemID = item.ItemID,
                LoanedOn = DateTime.Now
            };
            skiverleihContext.Histories.Add(HiEnt);
            skiverleihContext.SaveChanges();
        }

        /// <summary>
        /// Updates the return field of the History table
        /// </summary>
        /// <param name="customer">Customer</param>
        /// <param name="item">Item</param>
        /// <returns></returns>
        public bool AddReturnDateOnHistory(Customer customer, Item item)
        {
            bool itemReturned = false;
            try
            {
                var hist = skiverleihContext.Histories
                .Where(i => i.ItemID == item.ItemID)
                .Where(c => c.CustomerID == customer.CustomerID)
                .Where(y => y.ReturnedOn == DateTime.MinValue)
                .First();

                if (hist != null)
                {
                    hist.ReturnedOn = DateTime.Now;
                    skiverleihContext.Update(hist);
                    skiverleihContext.SaveChanges();
                }
                itemReturned = true;
            }
            catch (Exception e)
            {
                itemReturned = false;
                MessageBox.Show(e.Message);
            }
            return itemReturned;
        }


        /// <summary>
        /// Assigns Item to Customer
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="item"></param>
        /// <returns>Returns true if Item can be assigned. Returns false if item can not be assigned.</returns>
        public bool LendItemToCustomer(Customer customer, Item item)
        {
            bool isNull;
            if (item.CustomerID == null)
            {
                item.CustomerID = customer.CustomerID;

                skiverleihContext.Update(item);
                skiverleihContext.SaveChanges();
                isNull = false;
            }
            else
            {
                isNull = true;
            }
            return isNull;
        }

        /// <summary>
        /// Dismisses item from Customer
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Returns true if item can be dismissed. Returns false if item can not be dismissed.</returns>
        public bool ReturnItem(Item item)
        {
            bool isNull;
            if (item.CustomerID == null)
            {
                isNull = true;
            }
            else
            {
                item.CustomerID = null;
                skiverleihContext.Update(item);
                skiverleihContext.SaveChanges();
                isNull = false;
            }
            return isNull;
        }
    }
}
