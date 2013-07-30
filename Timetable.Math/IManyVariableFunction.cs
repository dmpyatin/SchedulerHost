namespace Timetable.Math
{
    /// IManyVariableFunction is an interface for mathematical functions
    /// of many variables, that is functions of the form:
    /// 				f(X) where X is a vector.
    public interface IManyVariableFunction
    {
        /// Returns the value of the function for the specified vector.
        double Value(params double[] x);
    }
}
