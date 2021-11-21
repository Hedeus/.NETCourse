using System;
using System.Collections.Generic;

namespace Course.Models
{
    internal class CalcResults
    {
        public class CalcResult
        {
            public double X { get; set; }
            public double Q { get; set; }
            public double Y { get; set; }
        }
    }

    internal class FunctionResult
    {
        public ICollection<CalcResults> XnResult { get; set; }
    }
}
