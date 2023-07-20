namespace CarManager.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            string make = "BMW";
            string model = "e46";
            double fuelConsumption = 3.5;
            double fuelCapacity = 100;

            car = new Car(make, model, fuelConsumption, fuelCapacity);
        }

        [Test]
        public void CarShouldBeCreatedSuccessfully()
        {
            string expectedMake = "BMW";
            string expectedModel = "e46";
            double expectedFuelConsumption = 3.5;
            double expectedFuelCapacity = 100;

            Assert.AreEqual(expectedMake, car.Make);
            Assert.AreEqual(expectedModel, car.Model);
            Assert.AreEqual(expectedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expectedFuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void CarShouldBeCreatedWithFuelAmountZero()
        {
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        public void CarMakePropertyShouldWorkProperly()
        {
            string expectedResult = "BMW";
            string actualResult = car.Make;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarMakePropertyShouldThrowExceptionIfStringIsNullOrEmpty(string emptyString)
        {
            string make = emptyString;
            string model = "Camaro";
            double fuelConsumption = 2.3;
            double fuelCapacity = 100;

            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Make cannot be null or empty!", exception.Message);
        }

        [Test]
        public void CarModelPropertyShouldWorkCorrectly()
        {
            string expectedResult = "e46";

            Assert.AreEqual(expectedResult, car.Model);
        }

        [TestCase(null)]
        [TestCase("")]
        public void CarModelPropertyShouldThrowExceptionIfModelIsNullOrEmpty(string emptyString)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("BMW", emptyString, 3.5, 100));

            Assert.AreEqual("Model cannot be null or empty!", exception.Message);
        }

        [Test]
        public void CarFuelConsumptionPropertyShouldWorkCorrectly()
        {
            double expectedResult = 3.5;

            Assert.AreEqual(expectedResult, car.FuelConsumption);
        }
        [TestCase(-1)]
        [TestCase(-2.8)]
        public void CarFuelConsumptionPropertyShouldThrowExceptionIfFuelConsumptionIsNotPositiveNumber(double fuelConsumption)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("BMW", "e46", fuelConsumption, 100));

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarFuelCapacityPropertyShouldWorkCorrectly()
        {
            double expectedResult = 100;

            Assert.AreEqual(expectedResult, car.FuelCapacity);
        }

        [TestCase(-1)]
        [TestCase(-10.7)]
        public void CarFuelCapacityPropertyShouldThrowExceptionIfFuelCapacityIsNotPositiveNumber(double fuelCapacity)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => new Car("BMW", "e46", 3.6, fuelCapacity));

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", exception.Message);
        }

        [Test]
        public void CarFuelAmountSetterShouldWorkProperly()
        {
            car.Refuel(5.7);

            double expectedResult = 5.7;

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [TestCase (-10)]
        [TestCase (-1000)]
        public void CarRefuelMethodShouldThrowExceptionIfRefuelAmountIsNegativeOrZero(double fuelAmount)
        {
            ArgumentException exception = Assert.Throws<ArgumentException>(()
                => car.Refuel(fuelAmount));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", exception.Message);
        }
        [Test]
        public void CarRefuelMehtodShouldnNotBeGreaterThanFuelCapacity()
        {
            car.Refuel(1000);
            double expectedResult = 100;

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }
        [Test]
        public void CarDriveMethodShouldWorkCorrectly()
        {
            car.Refuel(1000);
            car.Drive(100);

            double expectedResult = 96.5;

            Assert.AreEqual(expectedResult, car.FuelAmount);
        }

        [Test]
        public void CarDriveMethidShouldThrowExceptionIfNeededFuelIsGreaterThanFuelAmount()
        {

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() 
                => car.Drive(10));

            Assert.AreEqual("You don't have enough fuel to drive!", exception.Message);
        }
    }
}