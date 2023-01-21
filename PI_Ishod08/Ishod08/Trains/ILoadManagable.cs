using Ishod08.Trains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08
{
    public interface ILoadManagable : IChargeable
    {
        void AddVehicle(Vehicle vehicle);
        void ClearTrain();
        void getCurrentTrainComposition();
    }
}
