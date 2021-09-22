using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlWork1.DAL.Interfaces
{
    public interface IBaseRepository<TEntity>
         where TEntity : class
    {
        void Add(TEntity entity);
        TEntity Get(int id);
        void Delete(int id);
        IEnumerable<TEntity> GetAll();
        TEntity Update(int id, TEntity entity);
    }
}
