using Ishod08.Trains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08
{
    public class SmallTrain : Train, ILoadManagable, IChargeable
    {
        private List<SmallVehicle> smallVehicles = new List<SmallVehicle>();

        public SmallTrain(string name) : base(name)
        {
            this.Capacity = 8;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle is SmallVehicle)
            {
                if (smallVehicles.Count<=Capacity)
                {
                    smallVehicles.Add((SmallVehicle)vehicle);
                }
                
            }
            
        }

        public void ClearTrain()
        {
           smallVehicles.Clear();
        }

        public void getCurrentTrainComposition()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<<" + this.ID + "." + this.Name + ")-");
            foreach (var vehicle in smallVehicles)
            {
                sb.Append("(");
                sb.Append(vehicle); 
                sb.Append(")-");

            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(sb.ToString());
            Console.ResetColor();
        }
    }
}
