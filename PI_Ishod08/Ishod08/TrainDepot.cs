using Ishod08.Trains;
using Ishod08.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ishod08
{
    public class TrainDepot
    {
        public TrainDepot()
        {
        }

        public void OnTrainTresholdReached(object sender, TrainTresholdReachedEventArgs args)
        {
          
                if (args.queuedVehicles.Any(a => a is SmallVehicle))
                {
                    if (args.queuedVehicles.Count >= (int)TrainCapacity.SmallTrain)
                    {
                    ILoadManagable train = TrainFactory.getTrain("SmallTrain") as ILoadManagable;
                    foreach (var vehicle in args.queuedVehicles)
                    {
                        train.AddVehicle(vehicle as SmallVehicle);

                    }

                    train.getCurrentTrainComposition();
                    train.setCharge(train.GetTotalChargeForTrain(args.queuedVehicles));


                    //args.availableWorker.Income += (train.GetTotalChargeForTrain(args.queuedVehicles)) * args.availableWorker.Commision;
                    TrainDepotFinancialInfo(args, train);
                    NotifyAndUpdateTerminalStatus(args, train);
                    }
                }
                if (args.queuedVehicles.Any(a => a is BigVehicle))
                {
                    if (args.queuedVehicles.Count >= (int)TrainCapacity.BigTrain)
                    {
                    ILoadManagable train = TrainFactory.getTrain("BigTrain") as ILoadManagable;
                    foreach (var vehicle in args.queuedVehicles)
                    {
                        train.AddVehicle(vehicle as BigVehicle);

                    }

                    train.getCurrentTrainComposition();
                    train.setCharge(train.GetTotalChargeForTrain(args.queuedVehicles));


                    //args.availableWorker.Income += (train.GetTotalChargeForTrain(args.queuedVehicles)) * args.availableWorker.Commision;
                    TrainDepotFinancialInfo(args, train);
                    NotifyAndUpdateTerminalStatus(args, train);
                    }

                }
            
        }

        private static void TrainDepotFinancialInfo(TrainTresholdReachedEventArgs args, ILoadManagable train)
        {
            Console.WriteLine($"Naplaćeno za {train} = {train.GetTotalChargeForTrain(args.queuedVehicles)}");
            Console.WriteLine($"Vlak napunio radnik: {args.availableWorker.Name}" +
            $" te je zaradio: {(train.GetTotalChargeForTrain(args.queuedVehicles)) * args.availableWorker.Commision}");
           
        }

        private static void NotifyAndUpdateTerminalStatus(TrainTresholdReachedEventArgs args, ILoadManagable train)
        {
            args.availableWorker.Income += (train.GetTotalChargeForTrain(args.queuedVehicles)) * args.availableWorker.Commision;
            var terminal = Terminal.getTerminal();
            terminal.AddTrainToList(train);
            terminal.EmptyQueue(args.queuedVehicles);
            terminal.AddTerminalIncome(train.getCharge());
            Console.WriteLine($"{args.availableWorker.Name} - Trenutno totalna zarada: {args.availableWorker.Income}");
            Console.WriteLine($"Terminal trenutna zarada: {terminal.getTotalTerminalIncome()}");
            
           
            
        }
    }
}
