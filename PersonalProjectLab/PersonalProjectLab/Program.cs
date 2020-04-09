using System;
using System.Globalization;
using System.IO; 

namespace PersonalProjectLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Write Program Title to Console
            Console.WriteLine("***3D Print Cost Estimator***");
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
                Console.WriteLine("(This Includeds Supports, Rafts, Brim)");
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

                //Prompt User to enter Machine Cost including estimated Machine Run Time and Charge per Hour for Machine
                string machineInputs = "";
                int machineHours = 0;
                int machineCostPerHour = 0;

                Console.WriteLine("");
                Console.WriteLine("Enter the Estimated Print Time in Hours");
                machineInputs = Console.ReadLine();
                machineHours = int.Parse(machineInputs);

                Console.WriteLine("Enter Charge to Run Machine");
                Console.WriteLine("(Typically 0 to 5 depending on the desired level of detail)");
                machineInputs = Console.ReadLine();
                machineCostPerHour = int.Parse(machineInputs);

                //Calculate Machine Costs               
                decimal machineCost = stats.CalculatingMachineCost(machineHours, machineCostPerHour);                            

                //Prompt User to enter Man Hour Cost including estimated Man Hours needed and Cost per Man Hour
                string manInputs = "";
                int manHours = 0;
                int manCostPerHour = 0;
                
                Console.WriteLine("");
                Console.WriteLine("Enter Estimated Man Hours");
                Console.WriteLine("(This includes File Setup, File Creation, and Final Cleaning)");
                manInputs = Console.ReadLine();
                manHours = int.Parse(manInputs);

                Console.WriteLine("Enter Cost per Man Hour");
                manInputs = Console.ReadLine();
                manCostPerHour = int.Parse(manInputs);

                //Calculate Man Hours Cost 
                decimal manHoursCost = stats.CalculatingManHoursCost(manHours, manCostPerHour);


                //Calculate Sale Costs Estimation                
                decimal totalSalesCost = stats.CalculatingTotalSalesCost(materialCost, machineCost, manHoursCost);

                //Request Print Description                
                Console.WriteLine("Would you like to give a Description of the Print? [1] Yes or [2] No");

                string descriptionAnswer = Console.ReadLine();
                if (descriptionAnswer == "1")
                {
                    Console.WriteLine("Please give Print Desciption");
                    string printDescription = Console.ReadLine();

                    //Print Calculated All Values to Console
                    Console.WriteLine("");//Readablility
                    Console.WriteLine("File Description: " + printDescription);
                    Console.WriteLine("Material: " + materialCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("Machine: " + machineCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("Man Hours: " + manHoursCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("Tax: 7%");
                    Console.WriteLine("Total Cost: " + totalSalesCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("");//Readability

                    //Create Stream Writer and save new estimated values to file                             
                    using (StreamWriter outputFile = new StreamWriter("PrintCostEstimation.txt"))
                    {
                        outputFile.WriteLine(DateTime.Now);
                        outputFile.WriteLine("File Description: " + printDescription);
                        outputFile.WriteLine("Material: " + materialCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Machine: " + machineCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Man Hours: " + manHoursCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Tax: 7%");
                        outputFile.WriteLine("Total Cost: " + totalSalesCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    }
                }

                else
                {
                    //Print Calculated All Values to Console
                    Console.WriteLine("");//Readability
                    Console.WriteLine("Material: " + materialCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("Machine: " + machineCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("Man Hours: " + manHoursCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("Tax: 7%");
                    Console.WriteLine("Total Cost: " + totalSalesCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("");//Readability

                    //Create Stream Writer and save new estimated values to file                             
                    using (StreamWriter outputFile = new StreamWriter("PrintCostEstimation.txt"))
                    {
                        outputFile.WriteLine(DateTime.Now);
                        outputFile.WriteLine("");//Readability
                        outputFile.WriteLine("Material: " + materialCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Machine: " + machineCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Man Hours: " + manHoursCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Tax: 7%");
                        outputFile.WriteLine("Total Cost: " + totalSalesCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    }
                }
                //Ask User if they wish to continue
                Console.WriteLine("Do you wish to calculate another estimation? [1] Yes or [2] to quit program.");
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