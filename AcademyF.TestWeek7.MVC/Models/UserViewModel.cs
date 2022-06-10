using AcademyF.TestWeek7.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AcademyF.TestWeek7.MVC.Models
{
    public class UserViewModel 
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = "pippo";
        [Required]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
        public Role Role { get; set; } = Role.User;
    }
}
