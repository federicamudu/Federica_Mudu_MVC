using AcademyF.TestWeek7.Core.Entities;
using AcademyF.TestWeek7.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.TestWeek7.RepositoryEF
{
    public class RepositoryDishEF : IRepositoryDish
    {
        public Dish Add(Dish item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Dishes.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Dish item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Dishes.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Dish> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Dishes.Include(d => d.Menu).ToList();
            }
        }

        public Dish GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Dishes.Include(d => d.Menu).FirstOrDefault(d => d.Id == id);
            }
        }

        public Dish Update(Dish item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Dishes.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
