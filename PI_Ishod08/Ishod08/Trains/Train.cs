using Ishod08.Trains;
using Ishod08.Vehicles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08
{
    public class Train
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        private static int _id = 0;
        private int _charge = 0;

        public int ID { get => _id; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Charge { get => _charge; }

        public Train(string name)
        {

            Name = name;
            _id++;
        }

        public int GetTotalChargeForTrain(Queue<IVehicle> vehicles)
        {
            int totalCharge = 0;
            foreach (var vehicle in vehicles)
            {
                if (vehicle is Car)
                {
                    totalCharge += (int)Prices.Car_SmallTrain;
                }
                else if (vehicle is Van)
                {
                    totalCharge += (int)Prices.Van_SmallTrain;
                }
                else if (vehicle is Truck)
                {
                    totalCharge += (int)Prices.Truck_BigTrain;
                }
                else if (vehicle is Bus)
                {
                    totalCharge += (int)Prices.Bus_BigTrain;
                }

            }

            return totalCharge;
        }

        public void setCharge(int charge)
        {
            this._charge = charge;
        }

        public int getCharge()
        {
            return _charge;
        }

        public override string ToString()
        {
            return $"<<{ID}.{Name.ToUpper()}.Capacity:{Capacity})-";
        }


    }
}
