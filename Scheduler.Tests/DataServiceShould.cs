using System;
using System.Linq;
using NUnit.Framework;
using Timetable.Host.Tests.PublishedDataService;

namespace Timetable.Host.Tests
{
    [TestFixture]
    public class DataServiceShould
    {
        [Test]
        public void GetAllBranches()
        {
            var dataService = new DataServiceClient();

            var branches = dataService.GetBranches();

            Assert.IsTrue(branches.Any());
        }

        [Test]
        public void CreateNewFaculty()
        {
            var dataService = new DataServiceClient();

            var branch = new Branch();
            var faculty = new Faculty();

            branch.Name = "Test name";
            branch.CreatedDate = DateTime.Now;
            branch.UpdateDate = DateTime.Now;
            var result = dataService.Add(branch);

            branch.Id = result.Object.Id;
            faculty.Branch = branch;
            faculty.Name = "Test name";
            faculty.ShortName = "Test short name";
            faculty.CreatedDate = DateTime.Now;
            faculty.IsActual = true;
            faculty.UpdateDate = DateTime.Now;

            result = dataService.Add(faculty);
        }

        //[Test]
        public void UpdateFaculty()
        {
            var dataService = new DataServiceClient();

            var branch = dataService.GetBranches().Last();

            var faculty = dataService.GetFaculties(new Branch { Id = 297 }).Last();
            faculty.BranchId = branch.Id;

            var result = dataService.Update(faculty);
        }

        //[Test]
        public void GetShedulesForAuditorium()
        {
            var dataService = new LocalDataService.DataServiceClient();
            var auditorium = new LocalDataService.Auditorium { Id = 1203 };
            var studyYear = new LocalDataService.StudyYear { Id = 12 };
            //var t = dataService.GetFaculties(new LocalDataService.Branch {Id = 297});

            var result = dataService.GetSchedulesForAuditorium(auditorium, studyYear, 0);
        }
    }
}
