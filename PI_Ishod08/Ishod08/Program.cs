using Ishod08.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ishod08
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var terminal = Terminal.getTerminal();
            List<Worker> workers = new List<Worker>();
            List<Vehicle> vehicles = new List<Vehicle>();
            List<Vehicle> vehiclesFromTerminal = new List<Vehicle>();


            Worker w1 = new Worker("Slavko", 0.10);
            Worker w2 = new Worker("Mirko", 0.11);
            workers.Add(w1);
            workers.Add(w2);
            terminal.AddWorkers(workers);


            int i = 0;

            while (i < 25)
            {
                int rnd = RandomHelper.getRndMinMax(0, 4);
                terminal.AddVehicleToTerminal(VehicleFactory.getRandomVehicle(rnd));

                Thread.Sleep(100);

                terminal.SortVehiclesInTerminal();


                Thread.Sleep(1000);
                i++;
            }

            ShowFinancialResults(terminal);

            ShowAllTrains(terminal);

        }

        private static void ShowAllTrains(Terminal terminal)
        {
            Console.WriteLine("_______________________________________");
            Console.WriteLine("All Trains:");
            var trains = terminal.GetAllTrains();
            foreach (var train in trains)
            {
                train.getCurrentTrainComposition();
            }
        }

        private static void ShowFinancialResults(Terminal terminal)
        {
            Console.WriteLine("_______________________________________");
            Console.WriteLine("Financial Results:");
            Console.WriteLine($"Total terminal income: {terminal.TerminalIncome}");
            List<Worker> workers1 = terminal.GetWorkers();
            Console.WriteLine("Workers income:");
            foreach (var worker in workers1)
            {
                Console.WriteLine($"{worker}");
            }
           
        }
    }
}
