using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace WeeklyNews.DAL
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected IObjectSet<TEntity> _objectSet;
        public Repository(ObjectContext context)
        {
            _objectSet = context.CreateObjectSet<TEntity>();                
        }
        public void Add(TEntity entity)
        {
            _objectSet.AddObject(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public abstract TEntity GetById(long id);


        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter)
        {
            return _objectSet.Where(filter);
        }

        public void Remove(TEntity entity)
        {
            _objectSet.DeleteObject(entity);
        }
    }
}