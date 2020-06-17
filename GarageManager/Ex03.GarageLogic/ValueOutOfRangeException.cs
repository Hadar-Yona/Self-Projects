using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private readonly float r_MaxValue;
        private readonly float r_MinValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue)
        {
            this.r_MinValue = i_MinValue;
            this.r_MaxValue = i_MaxValue;
        }

        public override string Message
        {
            get
            {
                return string.Format("\nValue out of range, set a new value between {0} (exclude) and {1} (include)", r_MinValue, r_MaxValue);
            }
        }
    }
}
