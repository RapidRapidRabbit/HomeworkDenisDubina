using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.DAL.Interfaces
{
   public  interface IBaseRepository<TEntity>
        where TEntity: class
    {
        void Add(TEntity entity);
        TEntity Get(int id);        
        void Delete(int id);
    }
}
