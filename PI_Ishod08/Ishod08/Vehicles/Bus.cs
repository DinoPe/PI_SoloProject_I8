using Ishod08.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08
{
    public class Bus : BigVehicle, IVehicle
    {
        public Bus()
        {
        }

        public Bus(string name, int batteryStatus, int gasStatus) : base(name, batteryStatus, gasStatus)
        {
        }
    }
}
