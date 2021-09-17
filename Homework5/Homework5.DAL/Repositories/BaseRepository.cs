using Homework5.DAL.EF;
using Homework5.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        protected readonly DbSet<TEntity> settedEntity;
        protected readonly ApplicationDbContext context;

        public BaseRepository(ApplicationDbContext context)
        {
            this.context = context;
            settedEntity = this.context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {            
            settedEntity.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            TEntity entity = settedEntity.Find(id);
            settedEntity.Remove(entity);
            context.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return settedEntity.Find(id);
        }        

    }
}
