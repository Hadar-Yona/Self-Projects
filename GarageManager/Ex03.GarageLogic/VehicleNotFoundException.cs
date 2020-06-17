using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleNotFoundException : Exception
    {
        private readonly string r_LicenseNum;

        public VehicleNotFoundException(string i_LicenseNum)
            : base()
        {
            r_LicenseNum = i_LicenseNum;
        }

        public override string Message
        {
            get
            {
                return string.Format("Vehicle does not exist in the garage");
            }
        }
    }
}
