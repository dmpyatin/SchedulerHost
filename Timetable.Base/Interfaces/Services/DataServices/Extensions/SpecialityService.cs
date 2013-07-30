using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Timetable.Base.Entities;

namespace Timetable.Base.Interfaces.Services.DataServices.Extensions
{
    public static class SpecialityService
    {
        public static IQueryable<Speciality> GetByFacultyId(this IDataService<Speciality> dataService, int facultyId)
        {
            return dataService.Repository.Get(x => x.Faculty.Id == facultyId);
        }
    }
}
