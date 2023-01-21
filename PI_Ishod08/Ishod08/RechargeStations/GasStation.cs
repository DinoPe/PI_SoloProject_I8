using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ishod08
{
    public class GasStation : Station, IStationChargeable
    {
        public void Charge(Vehicle vehicle)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{vehicle.Name} has {vehicle.GasStatus}% gas. Refilling...");
            Thread.Sleep(300);
            vehicle.GasStatus = 100;
            Console.WriteLine($"{vehicle.Name} has {vehicle.GasStatus}% gas. Complete");
            Console.ResetColor();




        }
    }
}
