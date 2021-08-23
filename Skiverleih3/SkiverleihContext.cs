using Microsoft.EntityFrameworkCore;
using Skiverleih3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skiverleih3
{
    class SkiverleihContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Skiverleih2;");
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<History> Histories { get; set; }
    }
}
