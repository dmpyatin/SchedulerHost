using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timetable.Base.Entities;

namespace Timetable.Base.Interfaces.Services.DataServices.Extensions
{
    public static class ScheduleAttributeService
    {
        public static IEnumerable<ScheduleInfo> GetByDepartment(this IDataService<ScheduleInfo> dataService, int departmentId)
        {
            return dataService.Repository.Get(x => x.Department.Id == departmentId, includeProperties: "Faculties, Courses, Groups, Specialities, Lecturer, LikeAuditoriums, TutorialType, Tutorial, Department");
        }

        public static IEnumerable<ScheduleInfo> GetUnscheduled(this IDataService<ScheduleInfo> dataService, int facultyId, int courseId, int specialityId = 0, int groupId = 0)
        {
            return dataService.Repository.Get(x => 
                x.Schedules.Count == 0 && 
                x.Faculties.Any(y => y.Id == facultyId) && 
                x.Courses.Any(y => y.Id == courseId) &&
                (
                    x.Specialities.Any(y => y.Id == specialityId) ||
                    x.Groups.Any(y => y.Id == groupId)
                ));
        }
    }
}
