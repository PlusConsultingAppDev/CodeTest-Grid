using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Domain.Abstract
{
    public interface IRepository
    {
        bool Any<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity;
        TEntity Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity;
        void Delete<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity;
        TEntity GetEntityById<TEntity>(long primaryKey)
            where TEntity : class, IEntity;
        TEntity FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> wherePredicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
            where TEntity : class, IEntity;
        List<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> wherePredicate = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
            where TEntity : class, IEntity;
        int SaveOrUpdate<TEntity>(TEntity entity)
            where TEntity : class, IEntity;
        int SaveOrUpdate<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity;
        List<TResult> Select<TEntity, TResult>(Expression<Func<TEntity, bool>> wherePredicate = null, Expression<Func<TEntity, TResult>> selectPredicate = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
            where TEntity : class, IEntity;
    }
}
