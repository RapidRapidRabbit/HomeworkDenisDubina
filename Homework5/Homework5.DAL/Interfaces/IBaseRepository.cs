using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Не все CRUD операции объявлены:
// 1. TEntity GetById(int id) - есть
// 2. IEnumerable<TEntity> GetAll() - нет. Этот метод необходимо переопределять в конкретных репозиториях, чтобы включать необходимые свойства, если есть необходимость.
// 3. TEntity Add(TEntity entity) - есть. Лучше возвращать результат создания сущности. В нашем случае это будет та же сущность, что и была передана в метод.
// 4. TEntity Update(int id, TEntity entity) - нету. Базовый абстрактный класс должен иметь переопределяемый или абстрактный метод
// 5. Delete(int id) - есть
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
