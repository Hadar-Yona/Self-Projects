using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class FuelCar : Car
    {
        private readonly int r_MaxTankCapacity = 60;

        public FuelCar() 
        {
            EnergySource = new Fuel(MaxTankCapacity, eGasType.Octan96);
        }

        public int MaxTankCapacity
        {
            get
            {
                return r_MaxTankCapacity;
            }
        }

        internal override Dictionary<string, List<string>> GetVehicleProperties()
        {
           Dictionary<string, List<string>> carProperties = new Dictionary<string, List<string>>();
           carProperties.Add("Model name", new List<string>());
           carProperties.Add("Color", new List<string> { });
           carProperties["Color"].AddRange(Enum.GetNames(typeof(eColor)));
           carProperties.Add("Number of doors", new List<string> { });
           carProperties["Number of doors"].AddRange(Enum.GetNames(typeof(eDoorsNumber)));
           carProperties.Add("Current precent of fuel", new List<string>() { "float" }); 
           carProperties.Add("Tires' manufacturer", new List<string>());
           carProperties.Add("Tires' current air pressure", new List<string>() { "32", "float" });

           return carProperties;
        }

        internal override void SetVehicleProperties(Dictionary<string, string> i_Properties)
        {
            this.ModelName = i_Properties["Model name"];
            this.Color = this.MatchColor(i_Properties["Color"]);
            this.NumberOfDoor = this.MatchedDoorsNumber(i_Properties["Number of doors"]);
            this.EnergySource.CurrPrecent = float.Parse(i_Properties["Current precent of fuel"]);
            this.EnergySource.CurrAmount = MaxTankCapacity * EnergySource.CurrPrecent;
            this.WheelsSet = SetupWheels(4, i_Properties["Tires' manufacturer"], 32, float.Parse(i_Properties["Tires' current air pressure"]));
        }

        public override string ToString()
        {
            return string.Format(
                "\nCar's Details:\nLicence Number: {0}\nModel name: {1}\nColor: {2}\nNumber Of Doors: {3}\nGas Type: {4}\nTank Capacity: {5}\nEnergy Left in tank (in litters): {6}",
                LicenseNumber, 
                ModelName, 
                Color,
                NumberOfDoor,
                (EnergySource as Fuel).GasType,
                EnergySource.MaxAmount,
                EnergySource.CurrAmount);
        }
    }
}
