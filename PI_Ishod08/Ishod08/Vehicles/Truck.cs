using Ishod08.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08
{
    public class Truck : BigVehicle, IVehicle
    {
        public Truck()
        {
        }

        public Truck(string name, int batteryStatus, int gasStatus) : base(name, batteryStatus, gasStatus)
        {
        }
    }
}
