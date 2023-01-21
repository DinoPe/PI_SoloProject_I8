using Ishod08.Trains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08
{
    internal class BigTrain : Train, ILoadManagable
    {
        private List<BigVehicle> bigVehicles = new List<BigVehicle>();

        public BigTrain(string name) : base(name)
        {
            this.Capacity = 6;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (vehicle is BigVehicle)
            {
                bigVehicles.Add((BigVehicle)vehicle);
            }
        }

        public void ClearTrain()
        {
            bigVehicles.Clear();
        }

        public void getCurrentTrainComposition()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<<"+this.ID+"."+this.Name+")-");
            foreach (var vehicle in bigVehicles)
            {
                sb.Append("(");
                sb.Append(vehicle);
                sb.Append(")-");

            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(sb.ToString());
            Console.ResetColor();
        }
    }
}
