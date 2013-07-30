#region Using directives

using System;

#endregion

namespace Timetable.Math.MatrixAlgebra
{
    /// @author Didier H. Besset
    /// @translator edgar.sanchez@logicstudio.net
    public class DhbIllegalDimension : ApplicationException
    {

        /// DhbIllegalDimension constructor comment.
        public DhbIllegalDimension() : base()
        {
        }

        /// DhbIllegalDimension constructor comment.
        /// @param s string
        public DhbIllegalDimension(string s) : base(s)
        {
        }
    }
}
