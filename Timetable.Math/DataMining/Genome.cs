using System;

namespace Timetable.Math.DataMining
{
	/// <summary>
	/// Genome for genetic algorithm
	/// </summary>
	public class Genome
	{
        private readonly Random _random = new Random();

        public double[] Genes { get; private set; }
        public double Fitness { get; set; }
        public int Length { get; private set; }

        public static double MutationRate { get; set; }

		public Genome(int length): this(length, true){}

		public Genome(int length, bool createGenes)
		{
			Length = length;
			Genes = new double[ length ];
			if (createGenes)
				CreateGenes();
		}

		public Genome(double[] genes)
		{
		    Genes = genes;
            //Length = genes.GetLength(0);
            //Genes = new double[ Length ];
            //for (int i = 0 ; i < Length ; i++)
            //    Genes[i] = genes[i];
		}


		private void CreateGenes()
		{
			for (var i = 0 ; i < Length ; i++)
				Genes[i] = _random.NextDouble();
		}

		public void Crossover(Genome genome2, out Genome child1, out Genome child2)
		{
			var pos = (int)(_random.NextDouble() * Length);
			child1 = new Genome(Length, false);
			child2 = new Genome(Length, false);

			for(var i = 0 ; i < Length ; i++)
			{
				if (i < pos)
				{
					child1.Genes[i] = Genes[i];
					child2.Genes[i] = genome2.Genes[i];
				}
				else
				{
					child1.Genes[i] = genome2.Genes[i];
					child2.Genes[i] = Genes[i];
				}
			}
		}
        
		public void Mutate()
		{
			for (int pos = 0 ; pos < Length; pos++)
			{
				if (_random.NextDouble() < MutationRate)
					Genes[pos] = (Genes[pos] + _random.NextDouble())/2.0;
			}
		}

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < Length; i++)
                result += string.Format("{0:F4}", Genes[i]);

            return result;
        }
	}
}
