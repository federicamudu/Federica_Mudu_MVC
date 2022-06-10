using AcademyF.TestWeek7.Core.Entities;
using AcademyF.TestWeek7.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.TestWeek7.RepositoryEF
{
    public class RepositoryUserEF : IRepositoryUser
    {
        public User Add(User item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Users.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(User item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Users.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<User> Fetch()
        {
            using (var ctx = new MasterContext())
            {
                return ctx.Users.ToList();
            }
        }

        public User GetByUsername(string username)
        {
            using (var ctx = new MasterContext())
            {
                if (string.IsNullOrEmpty(username))
                {
                    return null;
                }
                return ctx.Users.FirstOrDefault(u => u.Username == username);
            }
        }

        public User Update(User item)
        {
            using (var ctx = new MasterContext())
            {
                ctx.Users.Update(item);
                ctx.SaveChanges();
            }
            return item;
        }
    }
}
