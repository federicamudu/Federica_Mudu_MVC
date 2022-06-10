using AcademyF.TestWeek7.Core.Entities;
using AcademyF.TestWeek7.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.TestWeek7.Core.BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IRepositoryMenu menuRepo;
        private readonly IRepositoryDish dishRepo;
        private readonly IRepositoryUser userRepo;

        public BusinessLayer(IRepositoryMenu menu, IRepositoryDish dish, IRepositoryUser user)
        {
            menuRepo = menu;
            dishRepo = dish;
            userRepo = user;
        }

        #region Dish
        public bool AddNewDish(Dish dish)
        {
            var menuExisting = menuRepo.GetById(dish.MenuId);            
            if (menuExisting == null)
            {
                return false;
            }
            dishRepo.Add(dish);
            return true;

        }
        public bool DeleteDish(int dishId)
        {
            var exisistingDish = dishRepo.GetById(dishId);
            if (exisistingDish == null)
            {
                return false;
            }
            return dishRepo.Delete(exisistingDish);
        }
        public bool EditDish(int idDish, decimal price)
        {
            var old = dishRepo.GetById(idDish);
            if (old == null)
            {
                return false;
            }
            old.Price = price;
            dishRepo.Update(old);
            return true;
        }
        public List<Dish> GetDishes()
        {
            return dishRepo.Fetch();
        }
        #endregion
        #region Menu
        public bool AddNewMenu(Menu menu)
        {
            var existingMenu = menuRepo.GetById(menu.Id);
            if (existingMenu == null)
            {
                menuRepo.Add(menu);
                return true;
            }
            return false;
        }
        public bool EditMenu(Menu menu)
        {
            var existingMenu = menuRepo.GetById(menu.Id);
            if (existingMenu == null)
            {
                return false;
            }
            menuRepo.Update(existingMenu);
            return true;
        }
        //public void PriceMenu(int id, int price)
        //{
        //    var existingMenu = menuRepo.GetById(id);
        //    decimal somma;
        //    foreach (var item in existingMenu.Dishes)
        //    {
        //        existingMenu.Total += item.Price;
        //    }
        //}
        public List<Menu> GetMenus()
        {
            return menuRepo.Fetch();
        }
        #endregion
        #region User
        public User GetAccount(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return null;
            }
            return userRepo.GetByUsername(username);
        }


        #endregion
    }
}
