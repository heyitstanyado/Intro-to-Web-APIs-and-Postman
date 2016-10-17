using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoffeeMenu.Models
{
    public class Drink
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        //public string Category { get; set;)
        public bool IsSeasonal { get; set; }
    }
}