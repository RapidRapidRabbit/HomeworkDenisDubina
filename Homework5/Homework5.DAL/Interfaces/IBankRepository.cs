using Homework5.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.DAL.Interfaces
{
    interface IBankRepository : IBaseRepository<Bank> 
    {
        void Update(int id, string name = null);
    }
}
