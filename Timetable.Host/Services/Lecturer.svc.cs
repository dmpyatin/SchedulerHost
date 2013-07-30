using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Timetable.Base.Entities;
using Timetable.Host.Interfaces;
using System.Text.RegularExpressions;

namespace Timetable.Host.Services
{
    public class LecturerService : BaseService<Lecturer>, ILecturerService
    {
        public IQueryable<Lecturer> GetAllForDepartment(int departmentId)
        {
            if (departmentId != 0)
                return Repository.Get(x => x.Department.Id.Equals(departmentId));
            else
                return Repository.Get(x => x.Department == null);
        }

        public IQueryable<Lecturer> GetAllForTutorial(int tutorialId)
        {
            return Repository.Get(x => x.ScheduleInfoes.Any(y => y.Tutorial.Id.Equals(tutorialId)));
        }

        public IQueryable<Lecturer> GetAllForTutorialAndTutorialType(int tutorialId, int tutorialTypeId)
        {
            return Repository.Get(
                x => x.ScheduleInfoes.Any(
                    y => y.Tutorial.Id.Equals(tutorialId) 
                    && y.TutorialType.Id.Equals(tutorialTypeId)));
        }

        public  Lecturer GetByFirstMiddleLastname(string arg)
        {
            return GetsByFirstMiddleLastname(arg).FirstOrDefault();
        }

        public IQueryable<Lecturer> GetsByFirstMiddleLastname(string arg)
        {
            var match = Regex.Match(arg, "[а-яА-Я]*");

            var result = new List<Lecturer>();

            while (match.Success)
            {
                var query = Repository.Get(x => x.Lastname.Contains(match.Value)
                    || x.Middlename.Contains(match.Value)
                    || x.Firstname.Contains(match.Value),
                    null, "Department, Rank, Department.Faculty");

                result.AddRange(query);

                match = match.NextMatch();
            }

            return result.AsQueryable();
        }
    }
}
