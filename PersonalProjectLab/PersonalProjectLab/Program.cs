using System;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata;

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
                Console.WriteLine("Enter the Estimated amount of filament needed in grams");
                Console.WriteLine("(This Includeds Supports, Rafts, Brim)");
                
                //Prompt User to enter Filament Information including Roll Cost, Roll Size, and Estimated amount needed
                string materialInput = Console.ReadLine();
                int filamentAmountNeeded = int.Parse(materialInput);

                Console.WriteLine("Enter the Cost of the Roll");
                materialInput = Console.ReadLine();
                int rollCost = int.Parse(materialInput);

                Console.WriteLine("Enter the Size of the Roll in grams");
                Console.WriteLine("(This value is typically 500g or 1000g)");
                materialInput = Console.ReadLine();
                int rollSize = int.Parse(materialInput);

                //Calculate Material Costs
                PrintCostEstimator stats = new PrintCostEstimator();

                decimal materialCost = stats.CalculatingMaterialCost(filamentAmountNeeded, rollCost, rollSize);
                Console.WriteLine("");
                Console.WriteLine("Enter the Estimated Print Time in Hours");
                //Prompt User to enter Machine Cost including estimated Machine Run Time and Charge per Hour for Machine
                string machineInputs = Console.ReadLine();
                int machineHours = int.Parse(machineInputs);

                Console.WriteLine("Enter Charge to Run Machine");
                Console.WriteLine("(Typically 0 to 5 depending on the desired level of detail)");
                machineInputs = Console.ReadLine();
                int machineCostPerHour = int.Parse(machineInputs);

                //Calculate Machine Costs               
                decimal machineCost = stats.CalculatingMachineCost(machineHours, machineCostPerHour);
                Console.WriteLine("");
                Console.WriteLine("Enter Estimated Man Hours");
                Console.WriteLine("(This includes File Setup, File Creation, and Final Cleaning)");
                //Prompt User to enter Man Hour Cost including estimated Man Hours needed and Cost per Man Hour
                string manInputs = Console.ReadLine();
                int manHours = int.Parse(manInputs);

                Console.WriteLine("Enter Cost per Man Hour");
                manInputs = Console.ReadLine();
                int manCostPerHour = int.Parse(manInputs);

                //Calculate Man Hours Cost 
                decimal manHoursCost = stats.CalculatingManHoursCost(manHours, manCostPerHour);

                //Calculate Taxed Amount
                decimal tax = (materialCost + machineCost + manHoursCost) * (decimal)(0.07);
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
                    Console.WriteLine("File Description: \t" + printDescription);
                    Console.WriteLine("Material: \t\t" + materialCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("Machine: \t\t" + machineCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("Man Hours: \t\t" + manHoursCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("Tax: \t\t\t" + tax.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("********************************");
                    Console.WriteLine("Total Cost: \t\t" + totalSalesCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("");//Readability

                    //Create Stream Writer and save new estimated values to file                             
                    using (StreamWriter outputFile = new StreamWriter("PrintCostEstimation.txt"))
                    {
                        outputFile.WriteLine("*****3D Print Cost Estimation*****");
                        outputFile.WriteLine("");//Readability
                        outputFile.WriteLine("File Description: \t" + printDescription);
                        outputFile.WriteLine("Material: \t\t" + materialCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Machine: \t\t" + machineCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Man Hours: \t\t" + manHoursCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Tax: \t\t\t" + tax.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("********************************");
                        outputFile.WriteLine("Total Cost: \t\t" + totalSalesCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Document Created on: \t" + DateTime.Now);
                    }
                }

                else
                {
                    //Print Calculated All Values to Console
                    Console.WriteLine("");//Readability
                    Console.WriteLine("Material: \t\t" + materialCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("Machine: \t\t" + machineCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("Man Hours: \t\t" + manHoursCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("Tax: \t\t\t" + tax.ToString("C", CultureInfo.GetCultureInfo("en-US"))); ;
                    Console.WriteLine("********************************");
                    Console.WriteLine("Total Cost: \t\t" + totalSalesCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                    Console.WriteLine("");//Readability

                    //Create Stream Writer and save new estimated values to file                             
                    using (StreamWriter outputFile = new StreamWriter("PrintCostEstimation.txt"))
                    {
                        outputFile.WriteLine("*****3D Print Cost Estimation*****");
                        outputFile.WriteLine("");//Readability
                        outputFile.WriteLine("Material: \t\t" + materialCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Machine: \t\t" + machineCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Man Hours: \t\t" + manHoursCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Tax: \t\t\t" + tax.ToString("C", CultureInfo.GetCultureInfo("en-US"))); ;
                        outputFile.WriteLine("********************************");
                        outputFile.WriteLine("Total Cost: \t\t" + totalSalesCost.ToString("C", CultureInfo.GetCultureInfo("en-US")));
                        outputFile.WriteLine("Document Created on: \t" + DateTime.Now);
                    }
                }
                //Ask User if they wish to continue
                Console.WriteLine("Do you wish to calculate another estimation? [1] Yes or [2] to quit program.");
                string userAnswer = Console.ReadLine();
               
                //If yes, Return to start of Program
                if (userAnswer == "2")
                {
                    userConintue = false;
                }                                   
            }
            Console.WriteLine("Thank You For Using This Program!");
        }
    }
}