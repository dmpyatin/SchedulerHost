using Timetable.Base.Entities;

namespace Timetable.Base.Interfaces.DataSources
{
    public interface IDatabase
    {
        void Add<TEntity>(TEntity entity) where TEntity : BaseEntity;

        void Update<TEntity>(TEntity entity) where TEntity : BaseEntity;

        void Delete<TEntity>(TEntity entity) where TEntity : BaseEntity;

        void AttachIsNotAttached<TEntity>(TEntity entity) where TEntity : BaseEntity;
    }
}
