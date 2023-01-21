using Ishod08.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08
{
    public class TrainTresholdReachedEventArgs : EventArgs
    {
        public Queue<IVehicle> queuedVehicles { get; set; }
        public Worker availableWorker { get; set; }
    }
}
