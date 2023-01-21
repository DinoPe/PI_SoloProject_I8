using Ishod08.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08
{
    public class Car : SmallVehicle, IVehicle
    {
        public Car()
        {
        }

        public Car(string name, int batteryStatus, int gasStatus) : base(name, batteryStatus, gasStatus)
        {
        }
    }
}
