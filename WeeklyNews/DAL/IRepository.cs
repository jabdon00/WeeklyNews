using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WeeklyNews.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> filter);
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
