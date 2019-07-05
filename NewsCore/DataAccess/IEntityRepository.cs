using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using NewsCore.Entities;
using NewsEntities.Entities;

namespace NewsCore.DataAccess
{
    public interface IEntityRepository<T>
        where T : class, IEntity, new()
 
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Get(Func<T, bool> p);
    }
}