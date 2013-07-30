using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timetable.Math.DataMining
{
    public class GeneticAlgorithm
    {
        private double _totalFitness;
        private List<Genome> _thisGeneration;
        private List<Genome> _nextGeneration;
        private List<double> _fitnessTable;
        private static readonly Random Random = new Random();

        public Func<double[], double> FitnessFunction { get; set; }
        public int PopulationSize { get; set; }
        public int GenerationSize { get; set; }
        public int GenomeSize { get; set; }
        public double MutationRate { get; set; }
        public string FitnessFile { get; set; }
        public double CrossoverRate { get; set; }
        public bool Elitism { get; set; }

        /// <summary>
        /// Default constructor sets mutation rate to 5%, crossover to 80%, population to 100, and generations to 2000.
        /// </summary>
        public GeneticAlgorithm() : this(0.8, 0.05, 100, 2000, 2){}

        public GeneticAlgorithm(int genomeSize) : this(0.8, 0.05, 100, 2000, genomeSize){}

        public GeneticAlgorithm(double crossoverRate, double mutationRate, int populationSize, int generationSize, int genomeSize)
        {
            Elitism = false;
            MutationRate = mutationRate;
            CrossoverRate = crossoverRate;
            PopulationSize = populationSize;
            GenerationSize = generationSize;
            GenomeSize = genomeSize;
            FitnessFile = "test.txt";
        }

        /// <summary>
        /// Method which starts the GA executing.
        /// </summary>
        public void Calculate()
        {
            if (FitnessFunction == null)
                throw new ArgumentNullException("Need to supply fitness function");

            if (GenomeSize == 0)
                throw new ArgumentException("Genome size not set");

            //  Create the fitness table.
            _fitnessTable = new List<double>();
            _thisGeneration = new List<Genome>(GenerationSize);
            _nextGeneration = new List<Genome>(GenerationSize);
            Genome.MutationRate = MutationRate;
            
            CreateGenomes();
            RankPopulation();

            StreamWriter outputFitness = null;
            var write = false;
            if (FitnessFile != "")
            {
                write = true;
                outputFitness = new StreamWriter(FitnessFile);
            }

            for (var i = 0; i < GenerationSize; i++)
            {
                CreateNextGeneration();
                RankPopulation();
                if (write)
                {
                    if (outputFitness != null)
                    {
                        var d = (double) ((Genome) _thisGeneration[PopulationSize - 1]).Fitness;
                        outputFitness.WriteLine("{0},{1}", i, d);
                    }
                }
            }
            if (outputFitness != null)
                outputFitness.Close();
        }

        /// <summary>
        /// After ranking all the genomes by fitness, use a 'roulette wheel' selection
        /// method.  This allocates a large probability of selection to those with the
        /// highest fitness.
        /// </summary>
        /// <returns>Random individual biased towards highest fitness</returns>
        private int RouletteSelection()
        {
            var randomFitness = Random.NextDouble()*_totalFitness;
            var idx = -1;
            var first = 0;
            var last = PopulationSize - 1;
            var mid = last/2;

            //  ArrayList's BinarySearch is for exact values only
            //  so do this by hand.
            while (idx == -1 && first <= last)
            {
                if (randomFitness < _fitnessTable[mid])
                    last = mid;
                else if (randomFitness > _fitnessTable[mid])
                    first = mid;
                mid = (first + last)/2;
                //  lies between i and i+1
                if ((last - first) == 1)
                    idx = last;
            }
            return idx;
        }

        /// <summary>
        /// Rank population and sort in order of fitness.
        /// </summary>
        private void RankPopulation()
        {
            _totalFitness = 0;
            for (var i = 0; i < PopulationSize; i++)
            {
                var g = ((Genome) _thisGeneration[i]);
                g.Fitness = FitnessFunction(g.Genes);
                _totalFitness += g.Fitness;
            }
            _thisGeneration.Sort(new GenomeComparer());

            //  now sorted in order of fitness.
            var fitness = 0.0;
            _fitnessTable.Clear();
            for (var i = 0; i < PopulationSize; i++)
            {
                fitness += (_thisGeneration[i]).Fitness;
                _fitnessTable.Add((double) fitness);
            }
        }

        /// <summary>
        /// Create the *initial* genomes by repeated calling the supplied fitness function
        /// </summary>
        private void CreateGenomes()
        {
            for (var i = 0; i < PopulationSize; i++)
            {
                var genome = new Genome(GenomeSize);
                _thisGeneration.Add(genome);
            }
        }

        private void CreateNextGeneration()
        {
            _nextGeneration.Clear();
            Genome genome = null;
            if (Elitism)
                genome = _thisGeneration[PopulationSize - 1];

            for (var i = 0; i < PopulationSize; i += 2)
            {
                var pidx1 = RouletteSelection();
                var pidx2 = RouletteSelection();
                Genome child1, child2;
                var parent1 = _thisGeneration[pidx1];
                var parent2 = _thisGeneration[pidx2];

                if (Random.NextDouble() < CrossoverRate)
                    parent1.Crossover(parent2, out child1, out child2);
                else
                {
                    child1 = parent1;
                    child2 = parent2;
                }
                child1.Mutate();
                child2.Mutate();

                _nextGeneration.Add(child1);
                _nextGeneration.Add(child2);
            }
            if (Elitism && genome != null)
                _nextGeneration[0] = genome;

            _thisGeneration.Clear();
            for (var i = 0; i < PopulationSize; i++)
                _thisGeneration.Add(_nextGeneration[i]);
        }

        public Genome GetBest()
        {
            var genome = _thisGeneration[PopulationSize - 1];
            return genome;
        }

        public Genome GetWorst()
        {
            return GetNthGenome(0);
        }

        public Genome GetNthGenome(int n)
        {
            if (n < 0 || n > PopulationSize - 1)
                throw new ArgumentOutOfRangeException("n too large, or too small");

            return _thisGeneration[n];
        }
    }
}
