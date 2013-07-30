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
    public class GroupService : BaseService<Group>, IGroupService
    {
        public Group GetGroupById(int groupId)
        {
            return GetsGroupsById(groupId).FirstOrDefault();
        }

        public Group[] GetsGroupsById(int groupId)
        {
            var result = Repository.Get(x => x.Id.Equals(groupId)).ToArray();

            return result;
        }

        public IQueryable<Group> GetAll(int facultyId, int courseId)
        {
            var result = Repository.Get(
                x => x.Speciality.Faculty.Id.Equals(facultyId)
                && x.Course.Id.Equals(courseId), null, "Speciality, ScheduleInfoes").ToList();

            return result.AsQueryable();
        }
    }
}
