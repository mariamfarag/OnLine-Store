using DALSevenCodeOnlineStore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLLSevenCodeOnlineStore.BaseRepository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        //protected DbContext _context;
        //protected DbSet<TEntity> _dbSet;
        //public BaseRepository(DbContext context)
        //{
        //    _context = context;
        //    _dbSet = context.Set<TEntity>();
        //}
        //-------*******************amro 
        private SevenCodeOnlineStoreContext _context = null;
        protected DbSet<TEntity> _dbSet;
        public BaseRepository(SevenCodeOnlineStoreContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public BaseRepository()
        {
            _context = new SevenCodeOnlineStoreContext();
            _dbSet = _context.Set<TEntity>();
        }
        //***********************************************
        //-----amr
        // public BaseRepository(DbContext context)
        //{
        //    _context = context;
        //    _dbSet = context.Set<TEntity>();
        //}
        //------------------------------------------

        // private DbSet<T> table = null;
        //public GenericRepository()
        //{
        //    this._context = new EmployeeDBContext();
        //    table = _context.Set<T>();
        //}
        //public GenericRepository(EmployeeDBContext _context)
        //{
        //    this._context = _context;
        //    table = _context.Set<T>();
        //}



        //--------------------------------------
        public TEntity GetById(object id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }
        public IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public IEnumerable<TEntity> GetByAll()
        {
            return _dbSet.ToList<TEntity>();
        }

        public IQueryable<TEntity> GetByAllQuery()
        {
            return _dbSet;
        }

        public TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;  //amr change 
            //EntityEntry < TEntity >
            //return _dbSet.Add(entity);
        }
        //public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entity)
        //{
        //    return _dbSet.AddRange(entity);
        //}
        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }
        public TEntity Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
            return entityToUpdate;
        }
        public void RemoveById(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }
        public void Remove(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            _dbSet.RemoveRange(entity);
        }
        //-----amr add

        //https://stackoverflow.com/a/47908159
        public ICollection<TType> Get<TType>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TType>> select) where TType : class
        {
            return _dbSet.Where(where).Select(select).ToList();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
