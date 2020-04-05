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
            decimal materialCost = 0.00m;

            materialCost = (decimal)filamentAmountNeeded * rollCost / rollSize;

            return materialCost;
        }
        public decimal CalculatingMachineCost(int machineHour)
        {
            decimal kiloWattHourPrinter = 0.20m;
            decimal kiloWattHourElectricity = 0.12m;

            decimal machineCost = 0.00m;
            machineCost = kiloWattHourElectricity * kiloWattHourPrinter * machineHour;
                        
            return machineCost;
        }
        public decimal CalculatingManHoursCost(int manHours, int costPerHour)
        {
            decimal manHoursCost = 0.00m;
            manHoursCost = (decimal) manHours * costPerHour;

            return manHoursCost;
        }   
        
    }
}
