using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Energy 
    {
        private float m_CurrPrecent;
        private float m_CurrAmount;
        private float m_MaxAmount;   

        public float CurrPrecent
        {
            get
            {
                return m_CurrPrecent;
            }

            set
            {
                m_CurrPrecent = value;
            }
        }

        public float CurrAmount
        {
            get
            {
                return m_CurrAmount;
            }

            set
            {
                m_CurrAmount = value;
            }
        }

        public float MaxAmount
        {
            get
            {
                return this.m_MaxAmount;
            }

            set
            {
                this.m_MaxAmount = value;
            }
        }

        internal void AddEnergyResource(float i_EnergyToAdd) 
        {
            CurrAmount = MaxAmount * CurrPrecent;

            if (MaxAmount - CurrAmount >= i_EnergyToAdd - 0.0001 && i_EnergyToAdd > 0) 
            {
                this.CurrAmount += i_EnergyToAdd;
                this.CurrPrecent = this.CurrAmount / this.MaxAmount;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxAmount - CurrAmount);
            }
        }    
    } 
}
