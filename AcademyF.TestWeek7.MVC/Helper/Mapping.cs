using AcademyF.TestWeek7.Core.Entities;
using AcademyF.TestWeek7.MVC.Models;

namespace AcademyF.TestWeek7.MVC.Helper
{
    public static class Mapping
    {
        public static UserViewModel ToUserViewModel(this User u)
        {
            return new UserViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Username = u.Username,
                Password = u.Password,
                Role = u.Role
            };
        }
        public static User ToUser(this UserViewModel u)
        {
            return new User
            {
                Id = u.Id,
                Name = u.Name,
                Username = u.Username,
                Password = u.Password,
                Role = u.Role
            };
        }
        public static MenuViewModel ToMenuViewModel(this Menu m)
        {
            List<DishViewModel> list = new List<DishViewModel>();
            foreach (var item in m.Dishes)
            {
                list.Add(item?.ToDishViewModel());
            }
            return new MenuViewModel
            {
                Id=m.Id,
                Name=m.Name,
                Dishes=list
            };
        }
        public static Menu ToMenu(this MenuViewModel m)
        {
            List<Dish> dishes = new List<Dish>();
            foreach (var item in m.Dishes)
            {
                dishes.Add(item?.ToDish());
            }
            return new Menu
            {
                Id = m.Id,
                Name = m.Name,
                Dishes = dishes
            };
        }
        public static DishViewModel ToDishViewModel(this Dish d)
        {
            return new DishViewModel
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                Type = d.Type,
                Price = d.Price,
                MenuId = d.MenuId
            };
        }
        public static Dish ToDish(this DishViewModel d)
        {
            return new Dish
            {
                Id =d.Id,
                Name = d.Name,
                Description = d.Description,
                Type = d.Type,
                Price = d.Price,
                MenuId=d.MenuId
            };
        }
    }
}
