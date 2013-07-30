using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using System.Linq;

namespace Timetable.Math.DataMining
{
    public class SelfOrganizingMap
    {
        private Neuron[,] _outputs;  // Collection of weights.
        private int _iteration;      // Current iteration.
        private readonly int _length;        // Side length of output grid.
        private readonly int _dimensions;    // Number of input dimensions.
        private readonly Random _rnd = new Random();

        private readonly List<string> _labels = new List<string>();
        private readonly List<double[]> _patterns = new List<double[]>();

        public SelfOrganizingMap(int dimensions, int length, string file)
        {
            _length = length;
            _dimensions = dimensions;
            Initialise();
            LoadData(file);
            NormalisePatterns();
            Train(0.0000001);
            DumpCoordinates();
        }

        private void Initialise()
        {
            _outputs = new Neuron[_length, _length];

            for (var i = 0; i < _length; i++)
                for (var j = 0; j < _length; j++)
                {
                    _outputs[i, j] = new Neuron(i, j, _length) {Weights = new double[_dimensions]};

                    for (var k = 0; k < _dimensions; k++)
                        _outputs[i, j].Weights[k] = _rnd.NextDouble();
                }
        }

        private void LoadData(string file)
        {
            var reader = File.OpenText(file);
            reader.ReadLine(); // Ignore first line.

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine().Split(',');
                _labels.Add(line[0]);
                var inputs = new double[_dimensions];

                for (var i = 0; i < _dimensions; i++)
                    inputs[i] = double.Parse(line[i + 1], CultureInfo.InvariantCulture);

                _patterns.Add(inputs);
            }
            reader.Close();
        }

        private void NormalisePatterns()
        {
            for (var j = 0; j < _dimensions; j++)
            {
                double sum = 0;
                for (var i = 0; i < _patterns.Count; i++)
                    sum += _patterns[i][j];

                var average = sum / _patterns.Count;

                for (var i = 0; i < _patterns.Count; i++)
                    _patterns[i][j] = _patterns[i][j] / average;
            }
        }

        private void Train(double maxError)
        {
            var currentError = double.MaxValue;

            while (currentError > maxError)
            {
                currentError = 0;
                var trainingSet = _patterns.ToList();

                for (var i = 0; i < _patterns.Count; i++)
                {
                    var pattern = trainingSet[_rnd.Next(_patterns.Count - i)];
                    currentError += TrainPattern(pattern);
                    trainingSet.Remove(pattern);
                }
                //Console.WriteLine(currentError.ToString("0.0000000"));
            }
        }

        private double TrainPattern(double[] pattern)
        {
            double error = 0;
            var winner = Winner(pattern);

            for (var i = 0; i < _length; i++)
            {
                for (var j = 0; j < _length; j++)
                    error += _outputs[i, j].UpdateWeights(pattern, winner, _iteration);
            }
            _iteration++;

            return System.Math.Abs(error / (_length * _length));
        }

        private void DumpCoordinates()
        {
            for (var i = 0; i < _patterns.Count; i++)
                Winner(_patterns[i]);
                //Console.WriteLine("{0},{1},{2}", _labels[i], n.X, n.Y);
        }

        private Neuron Winner(double[] pattern)
        {
            Neuron winner = null;
            var min = double.MaxValue;

            for (var i = 0; i < _length; i++)
                for (var j = 0; j < _length; j++)
                {
                    var d = Distance(pattern, _outputs[i, j].Weights);
                    if (d < min)
                    {
                        min = d;
                        winner = _outputs[i, j];
                    }
                }
            return winner;
        }

        private double Distance(double[] vector1, double[] vector2)
        {
            double value = 0;
            for (var i = 0; i < vector1.Length; i++)
                value += System.Math.Pow((vector1[i] - vector2[i]), 2);

            return System.Math.Sqrt(value);
        }
    }

   
}
