using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenceType;
        private int m_EngineCMVolume;

        public Motorcycle()
        {
            m_WheelsMaxAirPressure = (float)30;
            m_NumOfWheels = 2;
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenceType;
            }

            set
            {
                m_LicenceType = value;
            }
        }

        public int EngineCmVolume
        {
            get
            {
                return m_EngineCMVolume;
            }

            set
            {
                m_EngineCMVolume = value;
            }
        }

        internal override Dictionary<string, List<string>> GetVehicleProperties()
        {
            throw new NotImplementedException();
        }

        internal override void SetVehicleProperties(Dictionary<string, string> i_Properties)
        {
            throw new NotImplementedException();
        }
    }
}
