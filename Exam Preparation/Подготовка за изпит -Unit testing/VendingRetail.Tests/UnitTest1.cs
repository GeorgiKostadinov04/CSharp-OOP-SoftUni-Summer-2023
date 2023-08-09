using System.Xml.Linq;
using NUnit.Framework;

namespace VendingRetail.Tests
{
    public class Tests
    {
        
        [SetUp]
        public void Setup()
        {
            CoffeeMat coffeeMat = new CoffeeMat(5, 10);
        }

        [Test]
        public void ConstructorShouldCreateProperly()
        {
            CoffeeMat coffeeMat = new CoffeeMat(5, 10);
            int expectedWaterCapacity = 5;
            int expectedButtons = 10;
            int expectedIncome = 0;

            Assert.AreEqual(expectedIncome, coffeeMat.Income);
            Assert.AreEqual(expectedButtons, coffeeMat.ButtonsCount);
            Assert.AreEqual(expectedWaterCapacity, coffeeMat.WaterCapacity);
        }

        [Test]
        public void FillWaterTankShouldWorkProperly()
        {
            CoffeeMat coffeeMat = new CoffeeMat(5, 10);

            string expectedResult = $"Water tank is filled with {coffeeMat.WaterCapacity}ml";

            Assert.AreEqual(expectedResult, coffeeMat.FillWaterTank());
        }

        [Test]
        public void FillWaterTankShouldThrowExceptionIf()
        {
            CoffeeMat coffeeMat = new CoffeeMat(0, 10);

            string expectedResult = "Water tank is already full!";

            Assert.AreEqual(expectedResult, coffeeMat.FillWaterTank());
        }

        [Test]

        public void AddDrinkMethodReturnsTrueIfNotExistingDrink()
        {
            CoffeeMat coffeeMat = new CoffeeMat(0, 10);

            Assert.IsTrue(coffeeMat.AddDrink("mlqko", 10));
        }
        [Test]
        public void AddDrinkMethodReturnFalseIfDrinkExist()
        {
            CoffeeMat coffeeMat = new CoffeeMat(0, 10);

            coffeeMat.AddDrink("mlqko", 10);

            Assert.IsFalse(coffeeMat.AddDrink("mlqko", 10));
        }

        [Test]

        public void BuyDrinkMethodTest1()
        {
            CoffeeMat coffeeMat = new CoffeeMat(0, 10);
            string expectedResult = "CoffeeMat is out of water!";
            Assert.AreEqual(expectedResult,coffeeMat.BuyDrink("mlqko"));
        }

        [Test]
        public void BuyDrinkMethodTest2()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 10);

            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("mlqko", 10);

            coffeeMat.BuyDrink("mlqko");

            int expectedIncome = 10;

            string expetedStringOutput = $"Water tank is filled with {80}ml";


            Assert.AreEqual(expectedIncome, coffeeMat.Income);
            Assert.AreEqual(expetedStringOutput, coffeeMat.FillWaterTank());
        }

        [Test]
        public void BuyDrinkMethodTest3()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 10);

            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("mlqko", 10);

            string expetedResult = "kola is not available!";

            Assert.AreEqual(expetedResult, coffeeMat.BuyDrink("kola"));
        }


        [Test]
        public void BuyDrinkMethodTest4()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 10);

            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("mlqko", 10);

            string expetedResult = "Your bill is 10.00$";

            Assert.AreEqual(expetedResult, coffeeMat.BuyDrink("mlqko"));
        }

        [Test]

        public void IncomeMehtodShouldWorkProperly1()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 10);

            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("mlqko", 10);

            coffeeMat.BuyDrink("mlqko");


            int expectedIncomeValue = 0;

            coffeeMat.CollectIncome();

            Assert.AreEqual(expectedIncomeValue, coffeeMat.Income);


        }

        [Test]

        public void IncomeMehtodShouldWorkProperly2()
        {
            CoffeeMat coffeeMat = new CoffeeMat(100, 10);

            coffeeMat.FillWaterTank();

            coffeeMat.AddDrink("mlqko", 10);

            coffeeMat.BuyDrink("mlqko");

            double expectedMoney = 10;


            Assert.AreEqual(expectedMoney, coffeeMat.CollectIncome());


        }
    }
}