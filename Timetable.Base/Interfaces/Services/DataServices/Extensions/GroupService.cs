using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timetable.Base.Entities;

namespace Timetable.Base.Interfaces.Services.DataServices.Extensions
{
    public static class GroupService
    {
        public static IQueryable<Group> GetGroups(this IDataService<Group> dataService, int facultyId, int courseId)
        {
            return dataService.Repository.Get(filter => filter.Speciality.Faculty.Id == facultyId && filter.Course.Id == courseId, order => order.OrderBy(group => group.Code), "Course, Parent");
        }
    }
}
