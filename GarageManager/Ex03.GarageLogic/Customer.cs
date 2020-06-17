using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Customer
    {
        private readonly eVehicleType m_VehicleType;
        private string m_Name;
        private string m_PhoneNumber;
        private Vehicle m_Vehicle;   

        public Customer(eVehicleType io_VehicleType)
        {
            this.m_VehicleType = io_VehicleType;
        }

        public string Name
        {
            get
            {
                return this.m_Name;
            }

            set
            {
                this.m_Name = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return this.m_PhoneNumber;
            }

            set
            {
                this.m_PhoneNumber = value;
            }
        }

        public eVehicleType VehicleType
        {
            get
            {
                return this.m_VehicleType;
            }
        }

        public Vehicle Vehicle
        {
            get
            {
                return this.m_Vehicle;
            }

            set
            {
                this.m_Vehicle = value;
            }
        }

        public override string ToString()
        {
            return string.Format("\nCustomer's Details:\nName: {0}\nPhone Number: {1}", Name, PhoneNumber);
        }
    }
}
