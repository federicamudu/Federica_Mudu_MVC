using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.TestWeek7.Core.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public decimal Total { get { return Price(); } }

        //menu has n dishes
        public List<Dish> Dishes { get; set; } = new List<Dish>();
        //public decimal Price()
        //{
        //    decimal totPrezzo;
        //    foreach (var item in Dishes)
        //    {
        //        totPrezzo += item.Price;
        //    }
        //    return totPrezzo;
        //}
    }
}
