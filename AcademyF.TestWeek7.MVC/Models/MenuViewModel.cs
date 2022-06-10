using AcademyF.TestWeek7.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AcademyF.TestWeek7.MVC.Models
{
    public class MenuViewModel 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Total { get; set; }

        //menu has n dishes
        public List<DishViewModel> Dishes { get; set; } = new List<DishViewModel>();
    }
}
