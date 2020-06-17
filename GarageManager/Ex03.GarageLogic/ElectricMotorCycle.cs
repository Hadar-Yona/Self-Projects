using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorcycle : Motorcycle
    {
        private readonly float r_MaxBatteryLife = (float) 1.2;

        public ElectricMotorcycle()
        {
            EnergySource = new Battery(MaxBatteryLife);
        }

        public float MaxBatteryLife
        {
            get
            {
                return r_MaxBatteryLife;
            }
        }

        internal override Dictionary<string, List<string>> GetVehicleProperties()
        {
            Dictionary<string, List<string>> carProperties = new Dictionary<string, List<string>>();
            carProperties.Add("Model name", new List<string>()); 
            carProperties.Add("License type", new List<string> { });
            carProperties["License type"].AddRange(Enum.GetNames(typeof(eLicenseType)));
            carProperties.Add("Engine capacity", new List<string>() { "int" });
            carProperties.Add("Current precent of battery", new List<string>() { "float" }); 
            carProperties.Add("Tires' manufacturer", new List<string>());
            carProperties.Add("Tires' current air pressure", new List<string>() { "30", "float" });

            return carProperties;
        }

        internal override void SetVehicleProperties(Dictionary<string, string> i_Properties)
        {
            this.ModelName = i_Properties["Model name"];
            this.LicenseType = this.MatchedLicenseType(i_Properties["License type"]);
            this.EngineCmVolume = int.Parse(i_Properties["Engine capacity"]);
            this.EnergySource.CurrPrecent = float.Parse(i_Properties["Current precent of battery"]);
            this.EnergySource.CurrAmount = MaxBatteryLife * EnergySource.CurrPrecent;
            this.WheelsSet = SetupWheels(2, i_Properties["Tires' manufacturer"], 30, float.Parse(i_Properties["Tires' current air pressure"]));
        }

        public override string ToString()
        {
            return string.Format(
                "\nElectric Motorcycle's Details:\nLicence Number: {0}\nModel name: {1}\nLicence Type: {2}\nEngine Capacity: {3}\nMax Battery Life: {4}\nEnergy Left in tank (in hours): {5}", 
                LicenseNumber, 
                ModelName, 
                LicenseType, 
                EngineCmVolume, 
                EnergySource.MaxAmount, 
                EnergySource.CurrAmount);
        }
    }
}
