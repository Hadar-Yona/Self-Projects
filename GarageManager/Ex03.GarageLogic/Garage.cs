using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<Customer, eStatus> m_garageCustomers;

        public Garage()
        {
            m_garageCustomers = new Dictionary<Customer, eStatus>();
        }

        public Dictionary<Customer, eStatus> GarageCustomers
        {
            get
            {
                return m_garageCustomers;
            }
        }

        public void AddCustomer(Customer i_NewCustomer)
        {
            m_garageCustomers.Add(i_NewCustomer, eStatus.Repair);
        }

        public Customer GetCustomerByLicenseNumber(string i_LicenseNumber)
        {
            int counter = 0;

            if (!IsInGarage(i_LicenseNumber)) 
            {
                throw new VehicleNotFoundException(i_LicenseNumber);
            }

            foreach (KeyValuePair<Customer, eStatus> customer in GarageCustomers)
            {
                if (customer.Key.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    break;
                }
                else
                {
                    counter++;
                }
            }

            return GarageCustomers.ElementAt(counter).Key;
        }

        public Vehicle GetVehicleByLicenseNumber(string i_LicenseNumber)
        {
            int counter = 0;

            if (!IsInGarage(i_LicenseNumber))
            {
                throw new VehicleNotFoundException(i_LicenseNumber);
            }

            foreach (KeyValuePair<Customer, eStatus> customer in GarageCustomers)
            {
                if (customer.Key.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    break;
                }
                else
                {
                    counter++;
                }
            }

            return GarageCustomers.ElementAt(counter).Key.Vehicle;
        }

        public eVehicleType GetVehicleTypeByLicenseNumber(string i_LicenseNumber)
        {
            int counter = 0;

            if (!IsInGarage(i_LicenseNumber))
            {
                throw new VehicleNotFoundException(i_LicenseNumber);
            }

            foreach (KeyValuePair<Customer, eStatus> customer in GarageCustomers)
            {
                if (customer.Key.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    break;
                }
                else
                {
                    counter++;
                }
            }

            return GarageCustomers.ElementAt(counter).Key.VehicleType;
        }

        public eStatus GetStatus(string i_LicenseNumber)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new VehicleNotFoundException(i_LicenseNumber);
            }

            eStatus currStatus = eStatus.Repair;

            foreach (KeyValuePair<Customer, eStatus> item in GarageCustomers)
            {
                if (item.Key.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    currStatus = item.Value;
                    break;
                }
            }

            return currStatus;
        }

        public void ChangeStatus(string i_LicenseNumber, eStatus i_Status)
        {
            if (!IsInGarage(i_LicenseNumber))
            {
                throw new VehicleNotFoundException(i_LicenseNumber);
            }
            else
            {
                foreach (KeyValuePair<Customer, eStatus> item in GarageCustomers.ToList())
                {
                    if (item.Key.Vehicle.LicenseNumber == i_LicenseNumber)
                    {
                        GarageCustomers[item.Key] = i_Status;
                    }
                }
            }
        }

        public bool IsInGarage(string i_LicenseNumber)
        {
            bool flag = false;

            foreach (KeyValuePair<Customer, eStatus> item in GarageCustomers)
            {
                if (item.Key.Vehicle.LicenseNumber == i_LicenseNumber)
                {
                    flag = true;
                }
            }

            return flag;
        }

        public Dictionary<string, List<string>> GetPropertiesForNewVehicle(eVehicleType i_VehicleType)
        {
            return VehicleFactory.GetVehicleProperties(i_VehicleType);
        }

        public void InsertNewVehicle(eVehicleType i_VehicleType, Dictionary<string, string> i_Properties, Customer i_Customer, string i_LicenseNumber)
        {
            Vehicle vehicle = VehicleFactory.CreateVehicle(i_VehicleType, i_Properties);
            vehicle.VehicleType = i_VehicleType;
            i_Customer.Vehicle = vehicle;
            i_Customer.Vehicle.LicenseNumber = i_LicenseNumber;
        }

        public void AddFuel(Vehicle i_Vehicle, string i_GasType, float i_Amount)
        {
            if (!(i_Vehicle.EnergySource as Fuel).CheckGasType(i_GasType, i_Vehicle))
            {
                throw new ArgumentException();
            }

            if (i_Vehicle.EnergySource.CurrAmount == i_Vehicle.EnergySource.MaxAmount || 
                i_Vehicle.EnergySource.MaxAmount - i_Vehicle.EnergySource.CurrAmount < 0.001)
            {
                throw new InvalidOperationException();
            }

            try
            {
                (i_Vehicle.EnergySource as Fuel).AddFuel(i_GasType, i_Amount);
            }
            catch (ValueOutOfRangeException)
            {
                throw new ValueOutOfRangeException(0, i_Vehicle.EnergySource.MaxAmount - i_Vehicle.EnergySource.CurrAmount);
            }
        }

        public void ChargeBattery(Vehicle i_Vehicle, float i_Amount)
        {
            if (i_Vehicle.EnergySource.CurrAmount == i_Vehicle.EnergySource.MaxAmount ||
                i_Vehicle.EnergySource.MaxAmount - i_Vehicle.EnergySource.CurrAmount < 0.001)
            {
                throw new InvalidOperationException();
            }

            try
            {
                (i_Vehicle.EnergySource as Battery).ChargeBattery(i_Amount);
            }
            catch (ValueOutOfRangeException)
            {
                throw new ValueOutOfRangeException(0, i_Vehicle.EnergySource.MaxAmount - i_Vehicle.EnergySource.CurrAmount);
            }
        }

        public void Inflate(Vehicle i_Vehicle, float i_InflateBy)
        {
            if (i_Vehicle.WheelsSet[0].CurrAirPressure == i_Vehicle.WheelsMaxAirPressure ||
                i_Vehicle.WheelsMaxAirPressure - i_Vehicle.WheelsSet[0].CurrAirPressure < 0.001)
            {
                throw new InvalidOperationException();
            }

            try
            {
                foreach (Wheel currWheel in i_Vehicle.WheelsSet)
                { 
                        currWheel.Inflate(i_InflateBy);
                }
            }
            catch (ValueOutOfRangeException)
            {
                   throw new ValueOutOfRangeException(0, i_Vehicle.WheelsMaxAirPressure - i_Vehicle.WheelsSet[0].CurrAirPressure);
            }         
        }

        public static bool isGasVehicle(eVehicleType i_VehicleType)
        {
            bool flag = true;
            switch (i_VehicleType)
            {
                case eVehicleType.ElectricCar:
                case eVehicleType.ElectricMotorcycle:
                    flag = false;
                    break;
            }

            return flag;
        }

        public static string GetStringForGasMethod(eGasMethods i_eGasOperation)
        {
            string operation = string.Empty;
            if (i_eGasOperation == eGasMethods.addFuel)
            {
                operation = "Add fuel";
            }
            else if (i_eGasOperation == eGasMethods.inflate)
            {
                operation = "Inflate air pressure";
            }

            return operation;
        }

        public static string GetStringForElectricOp(eElectricMethods i_eElectricVehiclesOp)
        {
            string operation = string.Empty;
            if (i_eElectricVehiclesOp == eElectricMethods.chargeBattery)
            {
                operation = "Charge battery";
            }
            else if (i_eElectricVehiclesOp == eElectricMethods.inflate)
            {
                operation = "Inflate air pressure";
            }

            return operation;
        }
    }
}
