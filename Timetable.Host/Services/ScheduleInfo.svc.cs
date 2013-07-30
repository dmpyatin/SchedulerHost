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
    public class ScheduleInfoService : BaseService<ScheduleInfo>, IScheduleInfoService
    {


        public IQueryable<ScheduleInfo> GetAllForCourse(int facultyId, int courseId)
        {
            return Repository.Get(
                        x => x.Faculties.Any(y => y.Id.Equals(facultyId)) 
                        && x.Courses.Any(y => y.Id.Equals(courseId)));
        }

        public IQueryable<ScheduleInfo> GetAllForSpeciality(int facultyId, int courseId, int specialityId)
        {
            return Repository.Get(
                        x => x.Faculties.Any(y => y.Id.Equals(facultyId)) 
                        && x.Courses.Any(y => y.Id.Equals(courseId)) 
                        && x.Specialities.Any(y => y.Id.Equals(specialityId)));
        }

        public IQueryable<ScheduleInfo> GetAllForGroup(int facultyId, int courseId, int groupId)
        {
            var result = Repository.Get(
                        x => x.Faculties.Any(y => y.Id.Equals(facultyId))
                        && x.Courses.Any(y => y.Id.Equals(courseId))
                        && x.Groups.Any(y => y.Id.Equals(groupId)),null,
                        "Tutorial, TutorialType, Lecturer");

            return result.ToList().AsQueryable();
        }

        public IQueryable<ScheduleInfo> GetAllForDepartment(int departmentId)
        {
            return Repository.Get(x => x.Department.Id == departmentId);
        }


        //Получить незапоанированные предметы

       
        public IQueryable<ScheduleInfo> GetUnscheduled(int facultyId, int courseId, int specialityId, int groupId)
        {
            var test = Repository.Get(x =>
                x.Schedules.Count == 0 &&
                x.Faculties.Any(y => y.Id == facultyId) &&
                x.Courses.Any(y => y.Id == courseId) &&
                (
                  
                    x.Groups.Any(y => y.Id == groupId)
                ), null, "Lecturer, Tutorial").ToList();


            return test.AsQueryable();
        }
        //  x.Specialities.Any(y => y.Id == specialityId) ||...
    }
}
