using AcademyF.TestWeek7.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.TestWeek7.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        #region Menu
        List<Menu> GetMenus();
        bool AddNewMenu(Menu menu);
        bool EditMenu(Menu menu);
        //void PriceMenu(int id, int price);  
        #endregion

        #region Dish
        List<Dish> GetDishes();
        bool AddNewDish(Dish dish);
        bool EditDish(int idDish, decimal price);
        bool DeleteDish(int dishId);
        #endregion

        #region User
        User GetAccount(string username);
        #endregion
    }
}
