using Ishod08.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08.Trains
{
    public interface IChargeable
    {
        int GetTotalChargeForTrain(Queue<IVehicle> vehicles);
        void setCharge(int totalCharge);
        int getCharge();
    }
}
