
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLLSevenCodeOnlineStore.BaseRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity GetById(object id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "");
        IEnumerable<TEntity> GetByAll();

        IQueryable<TEntity> GetByAllQuery();
        TEntity Add(TEntity entity);
        //IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entity);
        TEntity Update(TEntity entityToUpdate);
        void RemoveById(object id);//delete
        void Remove(TEntity entityToDelete);
        void RemoveRange(IEnumerable<TEntity> entity);

        //---
        int Save();
    }
}
