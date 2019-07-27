using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;


namespace WanStap.DAL.Repository
{
    public class GenericRepository<TEntity> : IDisposable, IGenericRepository<TEntity> where TEntity : class
    {
        protected DbSet<TEntity> DbSet;
        private readonly DbContext _dbContext;
        private bool _disposed;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }
        public GenericRepository() { }
        public IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }
        public IQueryable<TEntity> GetAll(string includeProperties = "")
        {
            _dbContext.Configuration.AutoDetectChangesEnabled = false;
            IQueryable<TEntity> query = DbSet;

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query;
        }
        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return query.Where(predicate);
        }
        public IQueryable<TEntity> SearchFor(List<Expression<Func<TEntity, bool>>> predicate, string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;
            foreach (var p in predicate)
            {
                query = query.Where(p);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public TEntity GetById(object id)
        {
            return DbSet.Find(id);
        }
        public TEntity GetSingle(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.FirstOrDefault(filter);
        }
        public TEntity GetSingle(Expression<Func<TEntity, bool>> filter, string includeProperties)
        {
            IQueryable<TEntity> query = DbSet;
            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefault(filter);
        }
        public DateTime GetCurrentDate()
        {
            return _dbContext.Database.SqlQuery<DateTime>("select getdate()").Single();
        }
        public void Edit(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }
        public void Insert(IEnumerable<TEntity> entity)
        {
            DbSet.AddRange(entity);
        }
        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }
        public void Delete(IEnumerable<TEntity> entity)
        {
            DbSet.RemoveRange(entity);
        }
        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(filter).Any();
        }
        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _dbContext.Dispose();
            }
            _disposed = true;
        }
    }
}
