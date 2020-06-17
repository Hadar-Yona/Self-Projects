using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_Manufacturer;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;     
        
       public Wheel(string i_Manufaceturer, float i_MaxAirPressure, float i_CurrentPressure)
        {
            this.m_Manufacturer = i_Manufaceturer;
            this.m_CurrentAirPressure = i_CurrentPressure; 
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }

            set
            {
                m_MaxAirPressure = value;
            }
        }

        public string Manufacturer
        {      
            get 
            {
                return m_Manufacturer;
            }

            set
            {
                m_Manufacturer = value;
            }
        }

        public float CurrAirPressure
        {
            get 
            {
                return m_CurrentAirPressure;
            }

            set
            {
                m_CurrentAirPressure = value;
            }
        }

        internal static List<Wheel> CreateWheelsSet(int i_NumberOfWheels, string i_Manufacturer, float i_MaxAirPressure, float i_CurrentPressure)
        {
            List<Wheel> wheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                wheels.Add(new Wheel(i_Manufacturer, i_MaxAirPressure, i_CurrentPressure));
            }

            return wheels;
        }

        internal void Inflate(float i_inflateBy)              
        {
            if (this.MaxAirPressure - this.CurrAirPressure >= i_inflateBy - 0.0001 && i_inflateBy > 0)
            {
                this.CurrAirPressure += i_inflateBy;
            }
            else
            {
                throw new ValueOutOfRangeException(0, MaxAirPressure - CurrAirPressure);
            }
        }

        public override string ToString()
        {
            return string.Format("\nWheels' Details:\nWheels' Manufacturer: {0}\nWheels' Maximum air pressure: {1}\nWheels' Current air pressure: {2}", Manufacturer, MaxAirPressure, CurrAirPressure);
        }
    }
}
