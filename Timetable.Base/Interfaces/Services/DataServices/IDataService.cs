using System.Linq;
using Timetable.Base.Entities;
using Timetable.Base.Interfaces.Repositories;
using Timetable.Base.Interfaces.Validators;

namespace Timetable.Base.Interfaces.Services.DataServices
{
    public interface IDataService<T> where T: BaseEntity
    {
        IRepository<T> Repository { get; }

        IValidator<T> Validator { get; }

        IQueryable<T> All();

        T GetById(int id);

        void Add(T item);
        void Update(T item);
        void Delete(T item);
    }
}
