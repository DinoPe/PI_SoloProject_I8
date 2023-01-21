using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08
{
    public class RandomHelper
    {
        public static int getRndMinMax(int a, int b)
        {
            Random random = new Random();
            return random.Next(a, b);

        }
        
       
    }
}
