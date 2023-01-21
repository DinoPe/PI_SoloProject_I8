using Ishod08.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ishod08
{

    public class Terminal
    {
        public delegate void TrainTresholdReachedEventHandler(object sender, TrainTresholdReachedEventArgs e);
        public event TrainTresholdReachedEventHandler TrainTresholdReached;

        private const int BATTERY_TRESHOLD = 10;
        private const int GAS_TRESHOLD = 10;

        private TrainDepot trainDepot = new TrainDepot();
        private static Terminal terminalInstance;
        private int _terminalIncome = 0;

        private List<ILoadManagable> allTrainRides = new List<ILoadManagable>();
        private List<Vehicle> vehicles = new List<Vehicle>();
        private Queue<IVehicle> smalls = new Queue<IVehicle>();
        private Queue<IVehicle> bigs = new Queue<IVehicle>();
        private List<Worker> workers = new List<Worker>();
        public int TerminalIncome { get => _terminalIncome; }

        private Terminal() { }

        public static Terminal getTerminal()
        {
            if (terminalInstance == null)
            {
                terminalInstance = createInstance();
            }
            return terminalInstance;
        }

        public void AddTrainToList(ILoadManagable train)
        {
            allTrainRides.Add(train);   
        }

        public List<ILoadManagable> GetAllTrains()
        {
            return allTrainRides;
        }
        public void AddWorkers(List<Worker> loadedWorkers)
        {
            workers = loadedWorkers;
        }

        public void UpdateWorkerIncome(Worker w, int total)
        {

            var b = workers.Find(a => a.ID == w.ID);
            b.Income += w.Commision*total;
            
        }

        private Worker GetAvailableWorker()
        {
            int index = RandomHelper.getRndMinMax(0,workers.Count);
            Thread.Sleep(50);
            return workers[index];
            
        }

        public List<Worker> GetWorkers()
        {
            return workers;
        }

        public int getTotalTerminalIncome()
        {
            return _terminalIncome;
        }

        public void AddTerminalIncome(int income)
        {
            _terminalIncome += income;
        }

        private static Terminal createInstance()
        {
           return new Terminal();
        }

        public void AddVehicleToTerminal(Vehicle vehicle)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"NEW ARRIVAL: {vehicle}");
            Console.ResetColor();
            vehicles.Add(vehicle);
            CheckBatteryAndGass(vehicle,GAS_TRESHOLD,BATTERY_TRESHOLD);

        }

        public void EmptyQueue(Queue<IVehicle> vehicles)
        {
            if (vehicles.Count==6)
            {
                bigs.Clear();
            }
            else if (vehicles.Count==8)
            {
                smalls.Clear();
            }
        }

        public void SortVehiclesInTerminal()
        {
            vehicles = terminalInstance.getVehicles();
  
            for (int i = 0; i <= vehicles.Count(); i++)
            {
                if (vehicles[i] is BigVehicle)
                {
                    if (!bigs.Contains(vehicles[i]))
                    {
                        bigs.Enqueue((BigVehicle)vehicles[i]);
                        vehicles.RemoveAt(i);
                        Console.WriteLine($"Current queue status: SMALL:{smalls.Count} // BIGS:{bigs.Count}");

                        CheckIfEnoughVehicles(bigs);
                    }

                }
                else if (vehicles[i] is SmallVehicle)
                {
                    if (!smalls.Contains(vehicles[i]))
                    {
                        smalls.Enqueue((SmallVehicle)vehicles[i]);
                        vehicles.RemoveAt(i);
                        Console.WriteLine($"Current queue status: SMALL:{smalls.Count} // BIGS:{bigs.Count}");

                        CheckIfEnoughVehicles(smalls);
                    }

                }
                
            }
        }

        private void CheckIfEnoughVehicles(Queue<IVehicle> vehicles)
        {
            if (vehicles.Any(a => a is SmallVehicle))
            {
                if (vehicles.Count >= (int)TrainCapacity.SmallTrain)
                {
                    Console.WriteLine("Mali vlak spreman....");
                    terminalInstance.TrainTresholdReached += trainDepot.OnTrainTresholdReached;
                    OnTrainTresholdReached(vehicles);
                    //EmptyQueue(smalls);



                }
            }

            else if (vehicles.Any(a => a is BigVehicle))
            {
                if (vehicles.Count >= (int)TrainCapacity.BigTrain)
                {
                    Console.WriteLine("Veliki vlak spreman....");
                    terminalInstance.TrainTresholdReached += trainDepot.OnTrainTresholdReached;
                    OnTrainTresholdReached(vehicles);
                    //EmptyQueue(bigs);


                }
            }
        }

        protected virtual void OnTrainTresholdReached(Queue<IVehicle> vehicles)
        {
            
            TrainTresholdReached?.Invoke(this, new TrainTresholdReachedEventArgs() { queuedVehicles = vehicles, availableWorker = GetAvailableWorker() });
            
        }

        public List<Vehicle> getVehicles()
        {
            return vehicles;
        }

        public void ListVehicles()
        {
            foreach (Vehicle vehicle in getVehicles())
            {
                Console.WriteLine(vehicle.ToString());
            }
        }

        private void CheckBatteryAndGass(Vehicle vehicle,int gas, int battery)
        {
            if (vehicle.GasStatus < gas)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{vehicle} sent to Gas Station.");
                Console.ResetColor();
                GasStation gasStation = new GasStation();
                gasStation.Charge(vehicle);

            }

            if (vehicle.BatteryStatus < battery)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{vehicle} sent to EV Station.");
                Console.ResetColor();
                EVStation evStation = new EVStation();
                evStation.Charge(vehicle);
            }
        }
    }
}
