using System;

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
            //Material Cost mulitplied by 2 to account for printing errors
            decimal materialCost = filamentAmountNeeded * rollCost / rollSize * 2;
            return materialCost;
        }

        public decimal CalculatingMachineCost(int machineHour, int machineCostPerHour)
        {
            //Machine Cost is a Combination of charge to run the machine, machine wear and tear, and maintence costs.
            //KiloWatt Hour Printer Usage and KiloWatt for Electricity Charge are determined by current averages found online.
            decimal kiloWattHourPrinter = 0.20m;
            decimal kiloWattHourElectricity = 0.12m;
            decimal electricalCost = kiloWattHourElectricity * kiloWattHourPrinter * machineHour * machineCostPerHour;

            //Maintenance = man time to maintain the machine * cost of machine/estimated liftime(in hrs) * machine hours
            decimal maintenance = (decimal)(.5 * 300 / 10000 * machineHour * 20);

            //Sum of 2 costs = What it cost to run the machine.
            decimal machineCost = maintenance + electricalCost;

            return machineCost;
        }

        public decimal CalculatingManHoursCost(int manHours, int manCostPerHour)
        {
            //Man Hours Cost = Estimated man hours (including file creating, set up, physical set up) * cost per man hour
            decimal manHoursCost = manHours * manCostPerHour;

            return manHoursCost;
        }   

        public decimal CalculatingTotalSalesCost(decimal materialCost, decimal machineCost, decimal manHoursCost)
        {
            decimal minimumSale = 25.00m;
            decimal tax = (materialCost + machineCost + manHoursCost) *(decimal).07;
            decimal TotalCostPrint = materialCost + machineCost + manHoursCost + tax;

            if (TotalCostPrint < minimumSale)
            {
                return minimumSale;
            }
            else
            {
                return TotalCostPrint;
            }

            
        }
        
    }
}
