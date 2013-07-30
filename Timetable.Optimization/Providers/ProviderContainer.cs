using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Optimization.Providers
{
    /// <summary>
    /// Contains providers, requred for solution
    /// </summary>
    public class ProviderContainer : IProviderContainer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="costProvider">Cost provider</param>
        /// <param name="neighborhoodProvider">Neighborhood provider</param>
        /// <param name="combineProvider">Combine provider</param>
        public ProviderContainer(ICostProvider costProvider, INeighborhoodProvider neighborhoodProvider, ICombineProvider combineProvider)
        {
            CostProvider = costProvider;
            NeighborhoodProvider = neighborhoodProvider;
            CombineProvider = combineProvider;
        }

        public ICostProvider CostProvider { get; private set; }
        public INeighborhoodProvider NeighborhoodProvider { get; private set; }
        public ICombineProvider CombineProvider { get; private set; }
    }
}
