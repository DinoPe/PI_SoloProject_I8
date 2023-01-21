using Ishod08.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08
{
    public class Vehicle : IVehicle, IEquatable<Vehicle>
    {

        private static int _id=1;

        public int ID { get=>_id; }
        public string Name { get; set; }
        public int BatteryStatus { get; set; }
        public int GasStatus { get; set; }

        public Vehicle(string name, int batteryStatus, int gasStatus)
        {
            Name = $"{_id}{name}";
            BatteryStatus = batteryStatus;
            GasStatus = gasStatus;
            _id++;
        }

        public Vehicle()
        {
            _id++;
        }



        public override string ToString()
        {
            return $"{Name} G:{GasStatus} B:{BatteryStatus}";
        }

        public bool Equals(Vehicle other)
        {
            if(this.ID == other.ID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
