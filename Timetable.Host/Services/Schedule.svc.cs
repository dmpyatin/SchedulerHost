using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Timetable.Base.Entities;
using Timetable.Host.Interfaces;

namespace Timetable.Host.Services
{
    public class ScheduleService : BaseService<Schedule>, IScheduleService
    {
        public IQueryable<Schedule> GetAllForCourse(int facultyId, int courseId)
        {
            return Repository.Get(
                        x => x.ScheduleInfo.Faculties.Any(y => y.Id.Equals(facultyId))
                        && x.ScheduleInfo.Courses.Any(y => y.Id.Equals(courseId)));
        }

        public IQueryable<Schedule> GetAllForGroup(int facultyId, int courseId, int groupId)
        {
            return Repository.Get(
                        x => x.ScheduleInfo.Faculties.Any(y => y.Id.Equals(facultyId))
                        && x.ScheduleInfo.Courses.Any(y => y.Id.Equals(courseId))
                        && x.ScheduleInfo.Groups.Any(y => y.Id.Equals(groupId)));
        }

        public IQueryable<Schedule> GetAllForSpeciality(int facultyId, int courseId, int specialityId)
        {
            return Repository.Get(
                        x => x.ScheduleInfo.Faculties.Any(y => y.Id.Equals(facultyId))
                        && x.ScheduleInfo.Courses.Any(y => y.Id.Equals(courseId))
                        && x.ScheduleInfo.Specialities.Any(y => y.Id.Equals(specialityId)));
        }

        public IQueryable<Schedule> GetAllForLecturer(int lecturerId)
        {
            return Repository.Get(x => x.ScheduleInfo.Lecturer.Id.Equals(lecturerId));
        }

        public IQueryable<Schedule> GetAllForAuditorium(int auditoriumId)
        {
            return Repository.Get(x => x.Auditorium.Equals(auditoriumId));
        }

        public Schedule GetById(int id)
        {
            return Repository.GetById(id);
        }
    }
}
