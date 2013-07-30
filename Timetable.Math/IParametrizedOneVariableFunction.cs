namespace Timetable.Math
{
    /// IParametrizedOneVariableFunction is an interface for mathematical
    /// functions of one variable depending on several parameters,
    /// that is functions of the form f(x;p), where p is a vector.
    public interface IParametrizedOneVariableFunction: IOneVariableFunction
    {
        /// array containing the parameters
        double[] Parameters { get; set; }

        /// Evaluate the function and the gradient of the function with respect
        /// to the parameters.
        /// @return double[]	0: function's value, 1,2,...,n function's gradient
        /// @param x double
        double[] ValueAndGradient(double x);
    }
}
