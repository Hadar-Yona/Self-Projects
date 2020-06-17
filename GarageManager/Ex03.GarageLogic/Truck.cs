using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private readonly int r_MaxTankCapacity = 120;
        private bool m_DangerMaterials;
        private float m_CargoVolume;

        public Truck()
        {
            m_EnergySource = new Fuel(MaxTankCapacity, eGasType.Soler);
            m_WheelsMaxAirPressure = (float) 28;
            m_NumOfWheels = 16;
        }

        public int MaxTankCapacity
        {
            get
            {
                return r_MaxTankCapacity;
            }
        }

        public bool DangerMaterials
        {
            get
            {
                return m_DangerMaterials; 
            }

            set
            {
               m_DangerMaterials = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }

            set
            {
                m_CargoVolume = value;
            }
        }

        internal override Dictionary<string, List<string>> GetVehicleProperties()
        {
            Dictionary<string, List<string>> carProperties = new Dictionary<string, List<string>>();
            carProperties.Add("Model name", new List<string>()); 
            carProperties.Add("Cargo volume", new List<string>() { "float" });
            carProperties.Add("Is carring dangerous load", new List<string>() { "yes", "no" });
            carProperties.Add("Current precent of fuel", new List<string>() { "float" });  
            carProperties.Add("Tires' manufacturer", new List<string>());
            carProperties.Add("Tires' current air pressure", new List<string>() { "28", "float" });

            return carProperties;
        }

        internal override void SetVehicleProperties(Dictionary<string, string> i_Properties)
        {
            this.m_ModelName = i_Properties["Model name"];
            this.m_CargoVolume = float.Parse(i_Properties["Cargo volume"]);
            this.m_DangerMaterials = i_Properties["Is carring dangerous load"].ToLower() == "yes" ? true : false;
            this.EnergySource.CurrPrecent = float.Parse(i_Properties["Current precent of fuel"]);
            this.EnergySource.CurrAmount = MaxTankCapacity * EnergySource.CurrPrecent;
            this.WheelsSet = SetupWheels(16, i_Properties["Tires' manufacturer"], 28, float.Parse(i_Properties["Tires' current air pressure"]));
        }

        public override string ToString()
        {
            return string.Format(
                "\nTruck's Details:\nLicence Number: {0}\nModel name: {1}\nCargo Volume: {2}\nCarries Dangerous load: {3}\nGas Type: {4}\nTank Capacity: {5}\nEnergy Left in tank (in litters): {6}", 
                LicenseNumber, 
                ModelName, 
                CargoVolume, 
                DangerMaterials, 
                (EnergySource as Fuel).GasType, 
                EnergySource.MaxAmount, 
                EnergySource.CurrAmount);
        }
    }
}
