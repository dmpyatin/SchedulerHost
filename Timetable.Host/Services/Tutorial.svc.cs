using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Timetable.Base.Entities;
using Timetable.Base.Interfaces.Services.DataServices.Extensions;
using Timetable.Host.Interfaces;

namespace Timetable.Host.Services
{
    public class TutorialService : BaseService<Tutorial>, ITutorialService
    {

        public Tutorial GetTutorialById(int tutorialId)
        {
            return GetsTutorialsById(tutorialId).FirstOrDefault();
        }

        public IQueryable<Tutorial> GetsTutorialsById(int tutorialId)
        {
            var result = Repository.Get(x => x.Id.Equals(tutorialId));

            return result;
        }




        public IQueryable<Tutorial> GetAllForGroup(int facultyId, int courseId, int groupId)
        {
            return Repository.Get(
                x => x.ScheduleInfoes.Any(
                    y => y.Faculties.Any(z => z.Id.Equals(facultyId)))
                && x.ScheduleInfoes.Any(
                    y => y.Courses.Any(z => z.Id.Equals(courseId)))
                && x.ScheduleInfoes.Any(
                    y => y.Groups.Any(z => z.Id.Equals(groupId))));
        }

        public IQueryable<Tutorial> GetAllForSpeciality(int facultyId, int courseId, int specialityId)
        {
            return Repository.Get(
                    x => x.ScheduleInfoes.Any(
                        y => y.Faculties.Any(z => z.Id.Equals(facultyId)))
                    && x.ScheduleInfoes.Any(
                        y => y.Courses.Any(z => z.Id.Equals(courseId)))
                    && x.ScheduleInfoes.Any(
                        y => y.Specialities.Any(z => z.Id.Equals(specialityId))));
        }

        public IQueryable<Tutorial> GetAllForCourse(int facultyId, int courseId)
        {
            return Repository.Get(
                    x => x.ScheduleInfoes.Any(
                        y => y.Faculties.Any(z => z.Id.Equals(facultyId)))
                    && x.ScheduleInfoes.Any(
                         y => y.Courses.Any(z => z.Id.Equals(courseId))));
        }
    }
}
