namespace Timetable.Math
{
    /// <summary>
    /// IOneVariableFunction is an interface for mathematical functions of  a single variable, that is functions of the form f(x).
    /// </summary>
    public interface IOneVariableFunction
    {
        /// <summary>
        /// Returns the value of the function for the specified variable value.
        /// </summary> 
        double Value(double x);
    }
}
