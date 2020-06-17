using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        internal static Dictionary<string, List<string>> GetVehicleProperties(eVehicleType i_VehicleType)
        {
            Vehicle vehicle = null;
            switch (i_VehicleType)
            {
                case eVehicleType.Car:
                    vehicle = new FuelCar();
                    break;
                case eVehicleType.ElectricCar:
                    vehicle = new ElectricCar();
                    break;
                case eVehicleType.Motorcycle:
                    vehicle = new FuelMotorcycle();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle();
                    break;
                case eVehicleType.Truck:
                    vehicle = new Truck();
                    break;
            }

            return vehicle.GetVehicleProperties();
        }

        internal static Vehicle CreateVehicle(eVehicleType VehicleType, Dictionary<string, string> i_VehicleProperties)
        {
            Vehicle vehicle = null;
            switch (VehicleType)
            {
                case eVehicleType.Car:
                    vehicle = new FuelCar();
                    break;
                case eVehicleType.ElectricCar:
                    vehicle = new ElectricCar();
                    break;
                case eVehicleType.Motorcycle:
                    vehicle = new FuelMotorcycle();
                    break;
                case eVehicleType.ElectricMotorcycle:
                    vehicle = new ElectricMotorcycle();
                    break;
                case eVehicleType.Truck:
                    vehicle = new Truck();
                    break;
            }

            vehicle.SetVehicleProperties(i_VehicleProperties);

            return vehicle;
        }
    }
}
