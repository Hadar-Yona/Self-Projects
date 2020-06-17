using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Battery : Energy
    {
        public Battery(float i_MaxCapacity)
        {
            this.MaxAmount = i_MaxCapacity;
        }

        internal void ChargeBattery(float i_NumOfHoursToAdd)
        {
            try
            {
                AddEnergyResource(i_NumOfHoursToAdd);
            }
            catch (ValueOutOfRangeException)
            {
                throw new ValueOutOfRangeException(0, MaxAmount - CurrAmount);
            }
        }
    }
}