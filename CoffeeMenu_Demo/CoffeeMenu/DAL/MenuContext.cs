using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using CoffeeMenu.Models;

namespace CoffeeMenu.DAL
{
    public class MenuContext : DbContext
    {

        public MenuContext() : base("CoffeeMenu")
        {
        }

        public DbSet<Drink> Drinks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}