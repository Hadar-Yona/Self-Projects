using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Car : Vehicle
    {
        private eColor m_Color;
        private eDoorsNumber m_NumberOfDoors;

    public Car()
    {
        m_WheelsMaxAirPressure = (float)32;
        m_NumOfWheels = 4;
    }

    public eColor Color
    {
        get
        {
            return m_Color;
        }

        set
        {
            m_Color = value;
        }
    }

    public eDoorsNumber NumberOfDoor
    {
        get
        {
            return m_NumberOfDoors;
        }

        set
        {
            m_NumberOfDoors = value;
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
