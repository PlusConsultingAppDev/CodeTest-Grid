using Grid.Domain.Abstract;
using Grid.Domain.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Grid.Domain.Concrete
{
    public class EFRepository : IRepository
    {
        public List<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> wherePredicate = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
            where TEntity : class, IEntity
        {
            using (EFDbContext context = new EFDbContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (include != null)
                    query = include(query);

                if (wherePredicate != null)
                    return query.Where(wherePredicate).ToList();
                else
                    return query.ToList();
            }
        }

        public List<TResult> Select<TEntity, TResult>(Expression<Func<TEntity, bool>> wherePredicate = null, Expression<Func<TEntity, TResult>> selectPredicate = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
            where TEntity : class, IEntity
        {
            using (EFDbContext context = new EFDbContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (include != null)
                    query = include(query);

                if (wherePredicate != null)
                    return query.Where(wherePredicate).Select(selectPredicate).ToList();
                else
                    return query.Select(selectPredicate).ToList();
            }
        }

        public TEntity GetEntityById<TEntity>(long primaryKey)
            where TEntity : class, IEntity
        {
            using (EFDbContext context = new EFDbContext())
            {
                return context.Set<TEntity>().Find(primaryKey);
            }
        }

        public bool Any<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity
        {
            using (EFDbContext context = new EFDbContext())
            {
                return context.Set<TEntity>().Any(predicate);
            }
        }

        public TEntity FirstOrDefault<TEntity>(Expression<Func<TEntity, bool>> wherePredicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IQueryable<TEntity>> include = null)
            where TEntity : class, IEntity
        {
            using (EFDbContext context = new EFDbContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>();

                if (include != null)
                    query = include(query);

                if (orderBy != null)
                    query = orderBy(query);

                if (wherePredicate != null)
                    return query.FirstOrDefault(wherePredicate);
                else
                    return query.FirstOrDefault();
            }
        }

        public TEntity Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            using (EFDbContext context = new EFDbContext())
            {
                TEntity entityToDelete = context.Set<TEntity>().Find(entity.Id);
                context.Set<TEntity>().Remove(entityToDelete);

                context.SaveChanges();

                return entity;
            }
        }

        public void Delete<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            using (EFDbContext context = new EFDbContext())
            {
                foreach (TEntity entity in entities.ToList())
                {
                    TEntity entityToDelete = context.Set<TEntity>().Find(entity.Id);
                    context.Set<TEntity>().Remove(entityToDelete);
                }

                context.SaveChanges();
            }
        }

        public int SaveOrUpdate<TEntity>(TEntity entity)
            where TEntity : class, IEntity
        {
            using (EFDbContext context = new EFDbContext())
            {
                context.Entry(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;
                return context.SaveChanges();
            }
        }

        public int SaveOrUpdate<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity
        {
            using (EFDbContext context = new EFDbContext())
            {
                foreach (TEntity entity in entities)
                    context.Entry(entity).State = entity.Id == 0 ? EntityState.Added : EntityState.Modified;

                return context.SaveChanges();
            }
        }
    }
}
