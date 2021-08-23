using Skiverleih3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Collections;

namespace Skiverleih3.Logic
{
    class DataClass
    {
        SkiverleihContext skiverleihContext = new SkiverleihContext();

        /// <summary>
        /// Function joins two tables Items and Customers and writes queried data into a table
        /// </summary>
        /// <returns>IEnumberable</returns>
        public IEnumerable<object> GetItemsAndCustomers()
        {
            var customerItems = (from item in skiverleihContext.Items
                         join customer in skiverleihContext.Customers on item.CustomerID equals customer.CustomerID
                         join state in skiverleihContext.States on item.StateID equals state.StateID
                         select new { customer.CustomerID, customer.FirstName, customer.LastName, item.ItemID, item.Title, item.State}).ToList();

            return customerItems;
        }

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

        public void AddReturnDateOnHistory(Item item)
        {
            var hist = skiverleihContext.Histories
                .Where(i => i.ItemID == item.ItemID)
                .First();

            hist.ReturnedOn = DateTime.Now;
            skiverleihContext.Update(hist);
            skiverleihContext.SaveChanges();
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
            if(item.CustomerID == null)
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
            if(item.CustomerID == null)
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
