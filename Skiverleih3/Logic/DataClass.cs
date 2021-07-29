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

        public IEnumerable<object> GetItemsAndCustomers()
        {
            var customerItems = (from item in skiverleihContext.Items
                         join customer in skiverleihContext.Customers on item.CustomerID equals customer.CustomerID
                         join state in skiverleihContext.States on item.StateID equals state.StateID
                         select new { customer.CustomerID, customer.FirstName, customer.LastName, item.ItemID, item.Title, item.State}).ToList();

            return customerItems;
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
