using AcademyF.TestWeek7.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AcademyF.TestWeek7.MVC.Models
{
    public class DishViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public EnumDishType Type { get; set; }
        public decimal Price { get; set; }

        //FK -> Menu
        public int MenuId { get; set; }
        //A dish is in only one Menu
        public MenuViewModel Menu { get; set; }
    }
}
