using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Text;
using System.Text.Json.Serialization;

namespace PersonalProjectLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write Program Title to Console
            Console.WriteLine("***3D Print Cost Estimator 1.5.47 by DSchnoor***");
            Console.WriteLine("");//Blankline for Readability
            
            bool userConintue = true;

            while (userConintue) 
            {
                //Prompt User to enter Filament Information including Roll Cost, Roll Size, and Estimated amount needed
                
                string materialInput = "";
                int filamentAmountNeeded = 0;
                int rollCost = 0;
                int rollSize = 0;

                Console.WriteLine("Enter the Estimated amount of filament needed in grams");
                materialInput = Console.ReadLine();
                filamentAmountNeeded = int.Parse(materialInput);

                Console.WriteLine("Enter the Cost of the Roll");
                materialInput = Console.ReadLine();
                rollCost = int.Parse(materialInput);

                Console.WriteLine("Enter the Size of the Roll in grams");
                Console.WriteLine("(This value is typically 500g or 1000g)");
                materialInput = Console.ReadLine();
                rollSize = int.Parse(materialInput);

                //Calculate Material Costs
                PrintCostEstimator stats = new PrintCostEstimator();

                decimal materialCost = stats.CalculatingMaterialCost(filamentAmountNeeded, rollCost, rollSize);

                //Write Material Costs to Console
                Console.WriteLine("");
                Console.WriteLine("Material Cost: " + materialCost);

                //Prompt User to enter Machine Cost including estimated Machine Run Time and Charge per Hour for Machine
                string machineInputs = "";
                int machineHours = 0;
                int machineCostPerHour = 0;

                Console.WriteLine("");
                Console.WriteLine("Enter the Estimated Print Time in Hours");
                machineInputs = Console.ReadLine();
                machineHours = int.Parse(machineInputs);

                Console.WriteLine("Enter Charge to Run Machine");
                Console.WriteLine("(Typically 0 to 5)");
                machineInputs = Console.ReadLine();
                machineCostPerHour = int.Parse(machineInputs);

                //Calculate Machine Costs               
                decimal machineCost = stats.CalculatingMachineCost(machineHours, machineCostPerHour);

                //Write Machine Cost to Console
                Console.WriteLine("");
                Console.WriteLine("Machine Cost: " + machineCost);
                Console.WriteLine("");

                //Prompt User to enter Man Hour Cost including estimated Man Hours needed and Cost per Man Hour
                string manInputs = "";
                int manHours = 0;
                int manCostPerHour = 0;

                Console.WriteLine("Enter Estimated Man Hours");
                Console.WriteLine("(This includes File Setup, File Creation, and Manned Time to set up Machine)");
                manInputs = Console.ReadLine();
                manHours = int.Parse(manInputs);

                Console.WriteLine("Enter Cost per Man Hour");
                manInputs = Console.ReadLine();
                manCostPerHour = int.Parse(manInputs);

                //Calculate Man Hours Cost 
                decimal manHoursCost = stats.CalculatingManHoursCost(manHours, manCostPerHour);

                //Write Man Hours Cost to the Console
                Console.WriteLine("");
                Console.WriteLine("Cost of Man Hours: " + manHoursCost);
                Console.WriteLine("");

                //Calculate Sale Costs Estimation
                decimal totalCost = 0.00m;
                totalCost = (decimal)manHoursCost + materialCost + machineCost;

                decimal saleCost = 0.00m;
                saleCost = (decimal)(totalCost) * 3 * 7/100;
                //If Cost is below Threshold raise Cost to minimum value.
                if (saleCost < 15)
                {
                    saleCost = 15;
                }
                //Else Continue
                else
                {

                }
                //Print Values and total Costs/Charge to Console
                //Create Stream Writer and save new estimated values to file
                //Ask User if they wish to continue
                Console.WriteLine("Do you wish to calculate another estimation [1] Yes or [2] to quit program.");
                string userAnswer = Console.ReadLine();
                //If yes, Return to start of Program
                if (userAnswer == "2")
                {
                    //Else, End Program
                    userConintue = false;
                }                                   
            }
            Console.WriteLine("Thank You For Using This Program!");
        }
    }
}