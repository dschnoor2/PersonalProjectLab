using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonalProjectLab;

namespace PersonalProjectLabTests
{
    [TestClass]
    public class PriceCostTest
    {
        [TestMethod]
        public void PriceCosts_MaterialCostTest()
        {
            //arrange
            PrintCostEstimator stats = new PrintCostEstimator();

            //acting
            decimal materialCosts = stats.CalculatingMaterialCost(25, 50, 1000);

            //asserting
            Assert.AreEqual(2.50m, materialCosts);
        }

        [TestMethod]
        public void PriceCosts_ManCostTest()
        {
            //arrange
            PrintCostEstimator stats = new PrintCostEstimator();

            //acting
            decimal manHoursCost = stats.CalculatingManHoursCost(20, 5);

            //asserting
            Assert.AreEqual(100.00m, manHoursCost);
        }

        [TestMethod]
        public void PrintCosts_MachineCostTest()
        {
            //arrange
            PrintCostEstimator stats = new PrintCostEstimator();

            //acting
            decimal machineCost = stats.CalculatingMachineCost(25, 2);

            //asserting
            Assert.AreEqual(8.70m, machineCost);
        }

        [TestMethod]
        public void TotalSaleCost_Test()
        {
            //arrange
            PrintCostEstimator stats = new PrintCostEstimator();

            //acting
            decimal totalPrintCost = stats.CalculatingTotalSalesCost(15, 10, 20);

            //asserting
            Assert.AreEqual(48.15m, totalPrintCost);
        }

        [TestMethod]
        public void MinimumSale_Test()
        {
            //arrange
            PrintCostEstimator stats = new PrintCostEstimator();

            //acting
            decimal minimumPrintCost = stats.CalculatingTotalSalesCost(10, 7, 0);

            //asserting
            Assert.AreEqual(25.00m, minimumPrintCost);

        }
    }
}
