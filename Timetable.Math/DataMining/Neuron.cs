namespace Timetable.Math.DataMining
{
    public class Neuron
    {
        public double[] Weights;
        public int X;
        public int Y;
        private readonly int _length;
        private readonly double _nf;

        public Neuron(int x, int y, int length)
        {
            X = x;
            Y = y;
            this._length = length;
            _nf = 1000 / System.Math.Log(length);
        }

        private double Gauss(Neuron win, int it)
        {
            var distance = System.Math.Sqrt(System.Math.Pow(win.X - X, 2) + System.Math.Pow(win.Y - Y, 2));
            return System.Math.Exp(-System.Math.Pow(distance, 2) / (System.Math.Pow(Strength(it), 2)));
        }

        private double LearningRate(double it)
        {
            return System.Math.Exp(-it / 1000) * 0.1;
        }

        private double Strength(int it)
        {
            return System.Math.Exp(-it / _nf) * _length;
        }

        public double UpdateWeights(double[] pattern, Neuron winner, int it)
        {
            double sum = 0;

            for (var i = 0; i < Weights.Length; i++)
            {
                var delta = LearningRate(it) * Gauss(winner, it) * (pattern[i] - Weights[i]);
                Weights[i] += delta;
                sum += delta;
            }
            return sum / Weights.Length;
        }
    }
}
