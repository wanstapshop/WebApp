using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WanStap.DAL.Repository
{
    public interface IGenericRepository<TEntity> : IDisposable
    {
        TEntity GetById(object id);
        TEntity GetSingle(Expression<Func<TEntity, bool>> filter);
        TEntity GetSingle(Expression<Func<TEntity, bool>> filter, string includeProperties = "");
        IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate, string includeProperties = "");
        IQueryable<TEntity> SearchFor(List<Expression<Func<TEntity, bool>>> predicate, string includeProperties = "");
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(string includeProperties);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "");
        DateTime GetCurrentDate();
        void Edit(TEntity entity);
        void Insert(TEntity entity);
        void Insert(IEnumerable<TEntity> entity);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entity);
        void SaveChanges();
        bool Any(Expression<Func<TEntity, bool>> filter);
    }
}