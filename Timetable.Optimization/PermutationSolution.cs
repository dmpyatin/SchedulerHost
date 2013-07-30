using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetable.Base.Entities;
using Timetable.Base.Entities.Scheduler;
using Timetable.Optimization.Providers;

namespace Timetable.Optimization
{
    public class PermutationSolution : ISolution
    {
        //[Inject]
        private readonly IProviderContainer _providerContainer;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="n">Number of permutation elements</param>
        public PermutationSolution(int n, ScheduleInfo[] items, IProviderContainer providerContainer)
        {
            Count = n;
            Items = items;
            _providerContainer = providerContainer;
        }

        /// <summary>
        /// Number of permutation elements
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Permutation elements
        /// </summary>
        public ScheduleInfo[] Items { get; set; }
        
        private double? _cost;
        /// <summary>
        /// Solution cost
        /// </summary>
        public double Cost
        {
            get
            {
                if (!_cost.HasValue)
                    _cost = _providerContainer.CostProvider.GetCost(this);
                return _cost.Value;
            }
            set { _cost = value; }
        }

        /// <summary>
        /// Clone current solution
        /// </summary>
        /// <returns>New solution with same items</returns>
        public ISolution Clone()
        {
            var result = new PermutationSolution(Count, Items, _providerContainer);
            return result;
        }

        /// <summary>
        /// Get list of solution neighbors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ISolution> GetNeighbors()
        {
            return _providerContainer.NeighborhoodProvider.GetNeighbors(this);
        }

        /// <summary>
        /// Get best neighbor solution
        /// </summary>
        /// <returns></returns>
        public ISolution GetBestNeighbor()
        {
            return _providerContainer.NeighborhoodProvider.GetBestNeighbor(this);
        }

        /// <summary>
        /// Initialize solution with random data
        /// </summary>
        public void InitializeWithRandomData()
        {
            Random rnd = new Random();
            int swaps = rnd.Next(this.Count * this.Count);

            for (int k = 0; k < swaps; k++)
            {
                int i = rnd.Next(this.Count) + 1;
                int j = rnd.Next(this.Count) + 1;

                var t = Items[i];
                Items[i] = Items[j];
                Items[j] = t;
            }
        }
    }
}
