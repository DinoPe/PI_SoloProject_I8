using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08
{
    public class TrainFactory
    {
        private TrainFactory()
        {

        }
        public static Train getTrain(string trainType)
        {
            switch (trainType)
            {
                case "SmallTrain":

                    return new SmallTrain(nameof(SmallTrain));

                case "BigTrain":

                    return new BigTrain(nameof(BigTrain));


            }
            return null;


        }

       
    }
}
