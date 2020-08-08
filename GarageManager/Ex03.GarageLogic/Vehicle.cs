using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenceNumber;
        internal Energy m_EnergySource;
        internal int m_NumOfWheels;
        internal List<Wheel> m_WheelsSet;
        protected float m_WheelsMaxAirPressure;
        protected int r_NumOfWheels;
        public eVehicleType m_VehicleType;

        public Vehicle()
        {
        }

        public Vehicle(string i_ModelName)
        {
            m_ModelName = i_ModelName;
        }

        internal abstract Dictionary<string, List<string>> GetVehicleProperties();

        internal abstract void SetVehicleProperties(Dictionary<string, string> i_Properties);

        public List<Wheel> SetupWheels(int i_NumOfWheels, string i_Manufucture, float i_MaxPressure, float i_CurrentPressure)
        {
            return Wheel.CreateWheelsSet(i_NumOfWheels, i_Manufucture, i_MaxPressure, i_CurrentPressure);
        }

        public List<Wheel> WheelsSet
        {
            get
            {
                return m_WheelsSet;
            }

            set
            {
                m_WheelsSet = value;
            }
        }

        public int NumOfWheels
        {
            get
            {
                return m_NumOfWheels;
            }

            set
            {
                m_NumOfWheels = value;
            }
        }

        public float WheelsMaxAirPressure
        {
            get
            {
                return m_WheelsMaxAirPressure;
            }

            set
            {
                m_WheelsMaxAirPressure = value;
            }
        }

        public string ModelName
        {
            get
            {
                return m_ModelName;
            }

            set
            {
                m_ModelName = value;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenceNumber;
            }

            set
            {
                m_LicenceNumber = value;
            }
        }

        public Energy EnergySource
        {
            get
            {
                return m_EnergySource;
            }

            set
            {
                m_EnergySource = value;
            }
        }

        public eVehicleType VehicleType
        {
            get
            {
                return m_VehicleType;
            }

            set
            {
                m_VehicleType = value;
            }
        }

        protected eColor MatchColor(string i_ColorAsString)
        {
            eColor matchedColor = eColor.white;
            foreach (eColor color in Enum.GetValues(typeof(eColor)))
            {
                if (color.ToString().ToLower() == i_ColorAsString.ToLower())
                {
                    matchedColor = color;
                }
            }

            return matchedColor;
        }

        protected eDoorsNumber MatchedDoorsNumber(string i_DoorsAsString)
        {
            eDoorsNumber matchedNumber = eDoorsNumber.four;
            foreach (eDoorsNumber number in Enum.GetValues(typeof(eDoorsNumber)))
            {
                if (number.ToString().ToLower() == i_DoorsAsString.ToLower())
                {
                    matchedNumber = number;
                }
            }

            return matchedNumber;
        }

        protected eLicenseType MatchedLicenseType(string i_TypeAsString)
        {
            eLicenseType matchedLicenseType = eLicenseType.A;
            foreach (eLicenseType type in Enum.GetValues(typeof(eLicenseType)))
            {
                if (type.ToString().ToLower() == i_TypeAsString.ToLower())
                {
                    matchedLicenseType = type;
                }
            }

            return matchedLicenseType;
        }

        public static string GetStringForVehicleType(eVehicleType i_VehicleType)
        {
            string type = string.Empty;
            if (i_VehicleType == eVehicleType.ElectricCar)
            {
                type = "Electric Car";
            }
            else if (i_VehicleType == eVehicleType.ElectricMotorcycle)
            {
                type = "Electric Motorcycle";
            }
            else
            {
                type = string.Empty + i_VehicleType;
            }

            return type;
        }
    }
}
