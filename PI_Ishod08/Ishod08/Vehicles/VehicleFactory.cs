using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ishod08.Vehicles
{
    public class VehicleFactory
    {

       
        
        public static Vehicle getRandomVehicle(int rnd)
        {
            int battery = RandomHelper.getRndMinMax(0, 101);
            Thread.Sleep(100);
            int gas = RandomHelper.getRndMinMax(0, 101);


            switch (rnd)
            {
                case 0:
                    return new Car("Car", battery, gas);
                case 1:
                    return new Van("Van", battery, gas);
                case 2:
                    return new Bus("Bus", battery, gas);
                case 3:
                    return new Truck("Truck", battery, gas);

            }
            return null;
        }
    }
}
