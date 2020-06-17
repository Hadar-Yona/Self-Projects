using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Fuel : Energy
    {
        private readonly eGasType m_GasType;

        public Fuel(float i_MaxCapacity, eGasType i_GasType)
        {
            this.MaxAmount = i_MaxCapacity;  
            this.m_GasType = i_GasType;
        }     

        public eGasType GasType
        {
            get
            {
                return m_GasType;
            }
        }

        internal bool CheckGasType(string i_GasType, Vehicle i_Vehicle)
        {
            bool flag = true;

            if (i_GasType.ToLower() != getStringForGasType((i_Vehicle.EnergySource as Fuel).GasType).ToLower())
            {
                flag = false;
            }

            return flag;
        }

        private string getStringForGasType(eGasType i_GasType)
        {
            string gasType = string.Empty;

            if (i_GasType == eGasType.Octan95)
            {
                gasType = "octan95";
            }
            else if (i_GasType == eGasType.Octan96)
            {
                gasType = "octan96";
            }
            else if (i_GasType == eGasType.Octan98)
            {
                gasType = "octan98";
            }
            else if (i_GasType == eGasType.Soler)
            {
                gasType = "soler";
            }

            return gasType;
        }

        internal void AddFuel(string i_GasType, float i_NumOfLittersToAdd)
        {
                try
                {
                    AddEnergyResource(i_NumOfLittersToAdd);
                }
                catch (ValueOutOfRangeException)
                {
                    throw new ValueOutOfRangeException(0, MaxAmount - CurrAmount);
                }
            }            
        }       
    }