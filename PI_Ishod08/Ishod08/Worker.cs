using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ishod08
{
    public class Worker
    {
        private static int _id = 0;
        public string Name { get; set; }
        public double Commision { get; set; }
        public double Income { get; set; }
        public int ID { get => _id; }

        public Worker(string name, double commision)
        {
            
            Name = $"{ID}| {name}";
            Commision = commision;
            Income = 0.0;
            _id++;
            
        }

        public override string ToString()
        {
            return $"{Name} - Commision: {Commision * 100}%, Income: {Income}";
        }


    }
}
