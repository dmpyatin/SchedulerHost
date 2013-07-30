using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timetable.Base.Entities;
using System.Text.RegularExpressions;

namespace Timetable.Base.Interfaces.Services.DataServices.Extensions
{
    public static class LecturerService
    {
        public static Lecturer GetByFirstMiddleLastname(this IDataService<Lecturer> dataService, string arg)
        {
            return dataService.GetsByFirstMiddleLastname(arg).FirstOrDefault();
        }

        public static IQueryable<Lecturer> GetsByFirstMiddleLastname(this IDataService<Lecturer> dataService, string arg)
        {
            var match = Regex.Match(arg, "[а-яА-Я]*");

            var result = new List<Lecturer>();

            while (match.Success)
            {
                var query = dataService.Repository.Get(filter => filter.Lastname.Contains(match.Value)
                    || filter.Middlename.Contains(match.Value)
                    || filter.Firstname.Contains(match.Value),
                    null, "Department, Rank, Department.Faculty");

                result.AddRange(query);

                match = match.NextMatch();
            }

            return result.AsQueryable();
        }

        public static IQueryable<Lecturer> GetByDepartmentId(this IDataService<Lecturer> dataService, int deparmentId)
        {
            return dataService.Repository.Get(x => x.Department.Id == deparmentId);
        }

        public static IQueryable<Lecturer> GetByTutorialId(this IDataService<Lecturer> dataService, int tutorialId)
        {
            return dataService.Repository.Get(x => x.ScheduleInfoes.Any(y => y.Tutorial.Id == tutorialId));
        }
    }
}
