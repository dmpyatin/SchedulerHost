using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Timetable.Base.Entities;
using Timetable.Data.Context.Interfaces;

namespace Timetable.Data.Context
{
    public class BaseContext : DbContext, IDataContext
    {
        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public new DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            return base.Entry(entity);
        }

        protected virtual void Initialize()
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        /// <summary>
        /// Add new entity to repository
        /// </summary>
        /// <param name="entity">New entity</param>
        public virtual void Add<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            AttachIsNotAttached(entity);
            Set(entity.GetType()).Add(entity);
            SaveChanges();
        }

        /// <summary>
        /// Updated entity in repositoy
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            AttachIsNotAttached(entity);
            Entry(entity).State = EntityState.Modified;
            SaveChanges();
        }

        /// <summary>
        /// Remove entity from rpository
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            AttachIsNotAttached(entity);
            Set(entity.GetType()).Remove(entity);
            Entry(entity).State = EntityState.Deleted;
            SaveChanges();
        }

        /// <summary>
        /// Return models error
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> GetValidationModelErrors()
        {
            return GetValidationErrors();
        }

        /// <summary>
        /// Attach entity 
        /// </summary>
        /// <param name="entity"></param>
        public void AttachIsNotAttached<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (Entry(entity).State != EntityState.Detached)
                return;

            //var attached = Set(entity.GetType()).Local.FirstOrDefault(x => x.Id == entity.Id);

            //if (attached != null)
            //    Entry(attached).State = EntityState.Detached;

            Set(entity.GetType()).Attach(entity);
        }


        public IEnumerable<TEntity> RawSqlQuery<TEntity>(string query, params object[] parameters) where TEntity : BaseEntity
        {
            return Database.SqlQuery(typeof(TEntity), query, parameters).Cast<TEntity>();
        }
    }
}