using System;
using Ninject;
using Timetable.Base.Entities;
using Timetable.Base.Interfaces.DataSources;
using Timetable.Host.Interfaces;

namespace Timetable.Host.Services
{
    public class BaseService<TDatabase>: IBaseService where TDatabase: IDatabase
    {
        [Inject]
        public TDatabase Database { get; set; }

        protected OperationResult Crud<T>(Action<T> crud, T entity) where T: BaseEntity
        {
            var result = new OperationResult();

            try
            {
                crud(entity);

                result.Object = entity;
                result.Status = Status.Success;
            }
            catch
            {
                result.Object = entity;
                result.Status = Status.Fail;
            }

            return result;
        }


        public OperationResult Add(BaseEntity entity)
        {
            return Crud(Database.Add, entity);
        }

        public OperationResult Update(BaseEntity entity)
        {
            return Crud(Database.Update, entity);
        }

        public OperationResult Delete(BaseEntity entity)
        {
            return Crud(Database.Delete, entity);
        }
    }
}