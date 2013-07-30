using System.Collections.Generic;
using System.Linq;
using Timetable.Base.Interfaces.Services.DataServices;
using Timetable.Host.Interfaces;

namespace Timetable.Host.Services
{

    public class CourseService : BaseService<Base.Entities.Course>, ICourseService
    {
        public IQueryable<Base.Entities.Course> GetAll()
        {
            var result = Repository.Get(null,null,"ScheduleInfoes").ToList();
            return result.AsQueryable();
        }
    }
}
