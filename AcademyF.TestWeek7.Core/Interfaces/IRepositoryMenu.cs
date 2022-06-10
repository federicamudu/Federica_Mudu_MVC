using AcademyF.TestWeek7.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyF.TestWeek7.Core.Interfaces
{
    public interface IRepositoryMenu:IRepository<Menu>
    {
        Menu GetById(int id);
    }
}
