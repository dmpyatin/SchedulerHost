using System.Collections.Generic;
using System.Linq;
using Ninject;
using Timetable.Base.Entities.Scheduler;
using Timetable.Base.Interfaces.DataSources;

namespace Timetable.Optimization.Providers
{
    public class CostProvider : ICostProvider
    {
        private const double Fine = 1000.0;
        private ISchedulerDatabase _database;

        public CostProvider(ISchedulerDatabase database)
        {
            _database = database;
            _schedule = new Dictionary<int, Dictionary<int, int>>();
        }

        /// <summary>
        /// <time id, <auditorium id, schedule info id>>
        /// </summary>
        private Dictionary<int, Dictionary<int, int>> _schedule;

        private List<Time> _times;
        private List<Time> Times
        {
            get { return _times 
                ?? (_times = _database.Times.ToList()); }
        }

        private List<Auditorium> _auditoriums;
        private List<Auditorium> Auditoriums
        {
            get { return _auditoriums 
                ?? (_auditoriums = _database.Auditoriums.ToList()); }
        }

        /// <summary>
        /// Fill schedule and count the cost
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        private double FillSchedule(ISolution solution)
        {
            double result = 0;

            // Number of schedule violations
            int currentScheduleViolations = 0;
            for (int i = 1; i <= solution.Count; i++)
            {
                int timeId = 0;

                // Select appropriate time
                foreach (var time in Times)
                {
                    int auditoriumId = 0;

                    if (!_schedule.ContainsKey(time.Id))
                    {
                        // Add new item
                        _schedule[time.Id] = new Dictionary<int, int>();
                    }

                    foreach (var auditorium in Auditoriums)
                    {
                        // Find free auditorium
                        if (!_schedule[time.Id].ContainsKey(auditorium.Id))
                        {
                            timeId = time.Id;
                            auditoriumId = auditorium.Id;
                            _schedule[timeId].Add(auditoriumId, solution.Items[i].Id);
                            break;
                        }
                    }

                    // Suitable auditorium found
                    if (timeId > 0) break;
                }

                // If free space still not found
                if (timeId == 0)
                    currentScheduleViolations++;
            }

            result = currentScheduleViolations * Fine;
            return result;
        }

        public double GetCost(ISolution solution)
        {
            double cost;

            // Fill schedule according to permutation
            cost = FillSchedule(solution);

            return cost;
        }
    }
}
