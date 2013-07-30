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
    public class TutorialTypeService : BaseService<TutorialType>, ITutorialTypeService
    {
        public TutorialType GetTutorialTypeById(int tutorialTypeId)
        {
            return GetsTutorialTypeById(tutorialTypeId).FirstOrDefault();
        }

        public IQueryable<TutorialType> GetsTutorialTypeById(int tutorialTypeId)
        {
            var result = Repository.Get(x => x.Id.Equals(tutorialTypeId));

            return result;
        }

        public IQueryable<TutorialType> GetAll()
        {
            return Repository.Get();
        }
    }
}
