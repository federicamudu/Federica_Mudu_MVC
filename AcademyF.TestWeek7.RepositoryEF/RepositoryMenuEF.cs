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
    public class RepositoryMenuEF : IRepositoryMenu
    {
        public Menu Add(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menu.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menu.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Menu> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Menu.Include(m => m.Dishes).ToList();
            }
        }

        public Menu GetById(int id)
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Menu.Include(m => m.Dishes).FirstOrDefault(m => m.Id == id);
            }
        }

        public Menu Update(Menu item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Menu.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
