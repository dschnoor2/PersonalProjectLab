using System;
using System.Reflection.PortableExecutable;

namespace PersonalProjectLab
{
    public class PrintCostEstimator
    {
        public PrintCostEstimator()
        {
        }

        public decimal CalculatingMaterialCost ( int filamentAmountNeeded, int rollCost, int rollSize)
        {
           //Material Cost is determined by (cost of the Roll / Roll Size) to get price per gram.
           //Price per gram multipled by amount of material used.
            decimal materialCost = 0.00m;

            materialCost = (decimal)filamentAmountNeeded * rollCost / rollSize;

            return materialCost;
        }
        public decimal CalculatingMachineCost(int machineHour, int machineCostPerHour)
        {
            //Machine Cost is a Combination of charge to run the machine, machine wear and tear, and maintence costs.
            //KiloWatt Hour Printer Usage and KiloWatt for Electricity Charge are determined by current averages found online.
            decimal kiloWattHourPrinter = 0.20m;
            decimal kiloWattHourElectricity = 0.12m;

            decimal electricalCost = 0.00m;
            electricalCost = kiloWattHourElectricity * kiloWattHourPrinter * machineHour * machineCostPerHour;

            //Maintenance = man time to maintain the machine * cost of machine/estimated liftime(in hrs) * machine hours
            decimal maintenance =0.00m;
            maintenance = (decimal)(.5 * 300 / 10000 * machineHour * 20);

            //Sum of 2 costs = What it cost to run the machine.
            decimal machineCost = 0.00m;
            machineCost = maintenance + electricalCost;
                        
            return machineCost;
        }
        public decimal CalculatingManHoursCost(int manHours, int manCostPerHour)
        {
            //Man Hours Cost = Estimated man hours (including file creating, set up, physical set up) * cost per man hour
            decimal manHoursCost = 0.00m;
            manHoursCost = (decimal) manHours * manCostPerHour;

            return manHoursCost;
        }   
        
    }
}
