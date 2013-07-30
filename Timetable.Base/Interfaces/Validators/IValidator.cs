using System.Collections.Generic;
using Timetable.Base.Entities;


namespace Timetable.Base.Interfaces.Validators
{
    public interface IValidator<T> where T : BaseEntity
    {
        bool Validate(T entity);

        IEnumerable<object> GetErrors();
    }
}
