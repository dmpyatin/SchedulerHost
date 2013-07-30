
using System.Collections.Generic;
using Timetable.Math.DataMining.NeuralNetwork.Layers;
using Timetable.Math.DataMining.NeuralNetwork.Networks;
using Timetable.Math.DataMining.NeuralNetwork.Neurons;

namespace Timetable.Math.DataMining.NeuralNetwork.Learning
{
    /// <summary>
	/// Back propagation learning algorithm
	/// </summary>
	/// <remarks>The class implements back propagation learning algorithm,
	/// which is widely used for training multi-layer neural networks with
	/// continuous activation functions.</remarks>
	public class BackPropagationLearning : ISupervisedLearning
	{
		// network to teach
		private readonly ActivationNetwork _network;
		// learning rate
		private double _learningRate = 0.1;
		// momentum
		private double _momentum = 0.0;

		// neuron's errors
		private readonly double[][]	_neuronErrors = null;
		// weight's updates
		private readonly double[][][] _weightsUpdates = null;
		// threshold's updates
		private readonly double[][]	_thresholdsUpdates = null;


		/// <summary>
		/// Learning rate
		/// </summary>
		/// <remarks>The value determines speed of learning. Default value equals to 0.1.</remarks>
		public double LearningRate
		{
			get { return _learningRate; }
			set
			{
				_learningRate = System.Math.Max( 0.0, System.Math.Min( 1.0, value ) );
			}
		}

		/// <summary>
		/// Momentum
		/// </summary>
		/// <remarks>The value determines the portion of previous weight's update
		/// to use on current iteration. Weight's update values are calculated on
		/// each iteration depending on neuron's error. The momentum specifies the amount
		/// of update to use from previous iteration and the amount of update
		/// to use from current iteration. If the value is equal to 0.1, for example,
		/// then 0.1 portion of previous update and 0.9 portion of current update are used
		/// to update weight's value.<br /><br />
		///	Default value equals to 0.0.</remarks>
		public double Momentum
		{
			get { return _momentum; }
			set
			{
				_momentum = System.Math.Max( 0.0, System.Math.Min( 1.0, value ) );
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BackPropagationLearning"/> class
		/// </summary> 
		/// <param name="network">Network to teach</param> 
		public BackPropagationLearning( ActivationNetwork network )
		{
			this._network = network;

			// create error and deltas arrays
			_neuronErrors = new double[network.LayersCount][];
			_weightsUpdates = new double[network.LayersCount][][];
			_thresholdsUpdates = new double[network.LayersCount][];

			// initialize errors and deltas arrays for each layer
			for ( int i = 0, n = network.LayersCount; i < n; i++ )
			{
				Layer layer = network[i];

				_neuronErrors[i] = new double[layer.NeuronsCount];
				_weightsUpdates[i] = new double[layer.NeuronsCount][];
				_thresholdsUpdates[i] = new double[layer.NeuronsCount];

				// for each neuron
				for ( var j = 0; j < layer.NeuronsCount; j++ )
				    _weightsUpdates[i][j] = new double[layer.InputsCount];
			}
		}

		/// <summary>
		/// Runs learning iteration
		/// </summary> 
		/// <param name="input">input vector</param>
		/// <param name="output">desired output vector</param> 
		/// <returns>Returns squared error of the last layer divided by 2</returns> 
		/// <remarks>Runs one learning iteration and updates neuron's weights.</remarks>
		public double Run( double[] input, double[] output )
		{
			// compute the network's output
			_network.Compute( input );

			// calculate network error
			var error = CalculateError( output );

			// calculate weights updates
			CalculateUpdates( input );

			// update the network
			UpdateNetwork( );

			return error;
		}

		/// <summary>
		/// Runs learning epoch
		/// </summary> 
		/// <param name="input">array of input vectors</param>
		/// <param name="output">array of output vectors</param> 
		/// <returns>Returns sum of squared errors of the last layer divided by 2</returns> 
		/// <remarks>Runs series of learning iterations - one iteration
		/// for each input sample. Updates neuron's weights after each sample
		/// presented.</remarks> 
		public double RunEpoch( double[][] input, double[][] output )
		{
			var error = 0.0;

			// run learning procedure for all samples
			for ( int i = 0, n = input.Length; i < n; i++ )
				error += Run( input[i], output[i] );
			

			// return summary error
			return error;
		}


		/// <summary>
		/// Calculates error values for all neurons of the network
		/// </summary> 
		/// <param name="desiredOutput">Desired output vector</param> 
		/// <returns>Returns summary squared error of the last layer divided by 2</returns>/// 
		private double CalculateError( double[] desiredOutput )
		{
			// current and the next layers
			ActivationLayer	layer, layerNext;
			// current and the next errors arrays
			double[] errors, errorsNext;
			// error values
			double error = 0, e, sum;
			// neuron's output value
			double output;
			// layers count
			var layersCount = _network.LayersCount;

			// assume, that all neurons of the network have the same activation function
			var	function = _network[0][0].ActivationFunction;

			// calculate error values for the last layer first
			layer	= _network[layersCount - 1];
			errors	= _neuronErrors[layersCount - 1];

			for ( int i = 0, n = layer.NeuronsCount; i < n; i++ )
			{
				output = layer[i].Output;
				// error of the neuron
				e = desiredOutput[i] - output;
				// error multiplied with activation function's derivative
				errors[i] = e * function.Derivative2( output );
				// squre the error and sum it
				error += ( e * e );
			}

			// calculate error values for other layers
			for ( var j = layersCount - 2; j >= 0; j-- )
			{
				layer		= _network[j];
				layerNext	= _network[j + 1];
				errors		= _neuronErrors[j];
				errorsNext	= _neuronErrors[j + 1];

				// for all neurons of the layer
				for ( int i = 0, n = layer.NeuronsCount; i < n; i++ )
				{
					sum = 0.0;
					// for all neurons of the next layer
					for ( int k = 0, m = layerNext.NeuronsCount; k < m; k++ )
						sum += errorsNext[k] * layerNext[k][i];
					
					errors[i] = sum * function.Derivative2( layer[i].Output );
				}
			}

			// return squared error of the last layer divided by 2
			return error / 2.0;
		}

		/// <summary>
		/// Calculate weights updates
		/// </summary> 
		/// <param name="input">Network's input vector</param> 
		private void CalculateUpdates( IList<double> input )
		{
			// current neuron
			ActivationNeuron	neuron;
			// current and previous layers
			ActivationLayer		layer, layerPrev;
			// layer's weights updates
			double[][]	layerWeightsUpdates;
			// layer's thresholds updates
			double[]	layerThresholdUpdates;
			// layer's error
			double[]	errors;
			// neuron's weights updates
			double[]	neuronWeightUpdates;
			// error value
			double		error;

			// 1 - calculate updates for the last layer fisrt
			layer = _network[0];
			errors = _neuronErrors[0];
			layerWeightsUpdates = _weightsUpdates[0];
			layerThresholdUpdates = _thresholdsUpdates[0];

			// for each neuron of the layer
			for ( int i = 0, n = layer.NeuronsCount; i < n; i++ )
			{
				neuron	= layer[i];
				error	= errors[i];
				neuronWeightUpdates	= layerWeightsUpdates[i];

				// for each weight of the neuron
				for ( int j = 0, m = neuron.InputsCount; j < m; j++ )
				    // calculate weight update
					neuronWeightUpdates[j] = _learningRate * (_momentum * neuronWeightUpdates[j] +( 1.0 - _momentum ) * error * input[j]);
				

				// calculate treshold update
				layerThresholdUpdates[i] = _learningRate * (
					_momentum * layerThresholdUpdates[i] +
					( 1.0 - _momentum ) * error
					);
			}

			// 2 - for all other layers
			for ( int k = 1, l = _network.LayersCount; k < l; k++ )
			{
				layerPrev			= _network[k - 1];
				layer				= _network[k];
				errors				= _neuronErrors[k];
				layerWeightsUpdates	= _weightsUpdates[k];
				layerThresholdUpdates = _thresholdsUpdates[k];

				// for each neuron of the layer
				for ( int i = 0, n = layer.NeuronsCount; i < n; i++ )
				{
					neuron	= layer[i];
					error	= errors[i];
					neuronWeightUpdates	= layerWeightsUpdates[i];

					// for each synapse of the neuron
					for ( int j = 0, m = neuron.InputsCount; j < m; j++ )
						// calculate weight update
						neuronWeightUpdates[j] = _learningRate * (_momentum * neuronWeightUpdates[j] + ( 1.0 - _momentum ) * error * layerPrev[j].Output);
					

					// calculate treshold update
					layerThresholdUpdates[i] = _learningRate * (
						_momentum * layerThresholdUpdates[i] +
						( 1.0 - _momentum ) * error
						);
				}
			}
		}

		/// <summary>
		/// Update network'sweights
		/// </summary> 
		private void UpdateNetwork( )
		{
			// current neuron
			ActivationNeuron	neuron;
			// current layer
			ActivationLayer		layer;
			// layer's weights updates
			double[][]	layerWeightsUpdates;
			// layer's thresholds updates
			double[]	layerThresholdUpdates;
			// neuron's weights updates
			double[]	neuronWeightUpdates;

			// for each layer of the network
			for ( int i = 0, n = _network.LayersCount; i < n; i++ )
			{
				layer = _network[i];
				layerWeightsUpdates = _weightsUpdates[i];
				layerThresholdUpdates = _thresholdsUpdates[i];

				// for each neuron of the layer
				for ( int j = 0, m = layer.NeuronsCount; j < m; j++ )
				{
					neuron = layer[j];
					neuronWeightUpdates = layerWeightsUpdates[j];

					// for each weight of the neuron
					for ( int k = 0, s = neuron.InputsCount; k < s; k++ )
						// update weight
						neuron[k] += neuronWeightUpdates[k];
					
					// update treshold
					neuron.Threshold += layerThresholdUpdates[j];
				}
			}
		}
	}
}
