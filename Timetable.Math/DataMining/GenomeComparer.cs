using System;
using System.Collections;
using System.Collections.Generic;

namespace Timetable.Math.DataMining
{
	/// <summary>
	/// Compares genomes by fitness
	/// </summary>
	public sealed class GenomeComparer : IComparer<Genome>
	{
		public int Compare(Genome x, Genome y)
        {
            if (x.Fitness > y.Fitness)
                return 1;
            if (x.Fitness == y.Fitness)
                return 0;
            return -1;
	        
	    }
	}
}
