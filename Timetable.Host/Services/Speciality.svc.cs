using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Timetable.Host.Interfaces;

namespace Timetable.Host.Services
{
    public class SpecialityService : BaseService<Base.Entities.Speciality>, ISpecialityService
    {
        public Base.Entities.Speciality[] GetAll(int facultyId)
        {
            var result =  Repository.Get(x => x.Faculty.Id.Equals(facultyId), includeProperties: "Faculty, Groups");
            return result.ToArray();
        }
    }
}
