using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.Entity;
using Timetable.Base.Entities;
using Timetable.Base.Entities.Scheduler;

namespace Timetable.Data.Context.Interfaces
{
    public interface IDataContext
    {
        void SaveChanges();

        IEnumerable<DbEntityValidationResult> GetValidationErrors();

        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : BaseEntity;

        IEnumerable<TEntity> RawSqlQuery<TEntity>(string query, params object[] parameters) where TEntity : BaseEntity;
    }
}
