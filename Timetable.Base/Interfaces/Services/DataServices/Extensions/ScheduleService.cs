using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timetable.Base.Entities;

namespace Timetable.Base.Interfaces.Services.DataServices.Extensions
{
    public static class ScheduleService
    {
        /// <summary>
        /// Return schedul for selected groud
        /// </summary>
        /// <param name="dataService"></param>
        /// <param name="groupId">Group Id</param>
        /// <returns></returns>
        public static IQueryable<Schedule> GetByGroupId(this IDataService<Schedule> dataService, int groupId)
        {
            return dataService.Repository.Get(
                filter => filter.ScheduleInfo.Specialities.Any(x => x.Groups.Any(y => y.Id == groupId)), 
                order => order.OrderBy(x => x.DayOfWeek).OrderBy(x => x.Period.Id), 
                "Period, Lecturer, Tutorial, TutorialType, Auditorium, Auditorium.Building"
            );
        }

        /// <summary>
        /// Return schedule for selected auditorium
        /// </summary>
        /// <param name="dataService"></param>
        /// <param name="auditoriumId">Auditorium Id</param>
        /// <returns></returns>
        public static IQueryable<Schedule> GetByAuditoriumId(this IDataService<Schedule> dataService, int auditoriumId)
        {
            return dataService.Repository.Get(
                filter => filter.Auditorium.Id == auditoriumId, 
                order => order.OrderBy(x => x.DayOfWeek).OrderBy(x => x.Period.Id), 
                "Period, Lecturer, Tutorial, TutorialType, Auditorium, Auditorium.Building, Group, Group.Course, Group.Speciality, Group.Speciality.Department, Group.Speciality.Department.Faculty"
            );
        }

    }
}
