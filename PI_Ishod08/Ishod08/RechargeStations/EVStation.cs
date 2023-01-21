using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ishod08
{
    public class EVStation : Station, IStationChargeable
    {
        public void Charge(Vehicle vehicle)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{vehicle.Name} has {vehicle.BatteryStatus}% battery. Recharging...");
            Thread.Sleep(300);
            vehicle.BatteryStatus = 100;
            Console.WriteLine($"{vehicle.Name} has {vehicle.BatteryStatus}% battery. Complete");
            Console.ResetColor();
        }
    }
}
