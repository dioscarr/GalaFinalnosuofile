using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public abstract class GenericRepository<T> where T : class
    {
        protected DbContext _dataContext;
        protected DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            this._dataContext = context;
            this._dbSet = context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            try
            {
                _dbSet.Add(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(int id)
        {
            try
            {
                T entity = _dbSet.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (_dataContext.Entry(entity).State == EntityState.Detached)
                {
                    _dbSet.Attach(entity);
                }
                _dbSet.Remove(entity);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual T GetById(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual T GetById(string pId)
        {
            try
            {
                int id = Int32.Parse(pId);
                return _dbSet.Find(id);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public virtual IList<T> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public virtual IList<T> FindBy(Func<T, bool> where)
        {
            try
            {
                return _dbSet.Where(where).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IList<T> FindBy(string pName, object pVal)
        {
            var itemParameter = Expression.Parameter(typeof(T), "item");
            var where = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(
                    Expression.Property(
                        itemParameter, pName),
                    Expression.Constant(pVal)
                    ),
                new[] { itemParameter }
            );

            try
            {
                return _dbSet.Where(where).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public T UniqueCheck(Func<T, bool> where)
        {
            try
            {
                return _dbSet.Where(where).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _dataContext.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}