namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        [TestCase("Toyota", "Yaris", 5, 60)]
        public void VerifyConstructorsWorkCorrectly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car currentCar = new Car(make, model, fuelConsumption, fuelCapacity);
            Car expectedCar = new Car("Toyota", "Yaris", 5, 60);

            
            string currCarMake = currentCar.Make;
            string expectedCarMake = expectedCar.Make;
            string currCarModel = currentCar.Model;
            string expectedCarModel = expectedCar.Model;
            double currCarFuelConsumption = currentCar.FuelConsumption;
            double expectedCarFuelConsumption = expectedCar.FuelConsumption;
            double currCarFuelCapacity = currentCar.FuelCapacity;
            double expectedCarFuelCapacity = expectedCar.FuelCapacity;

            //Assert.AreEqual(expectedCarfuelAmount, currCarfuelAmount, "FuelAmount should be set to 0 by default and should match.");
            Assert.AreEqual(0, currentCar.FuelAmount);
            Assert.AreEqual(expectedCarMake, currCarMake, "Makes should be matching.");
            Assert.AreEqual(expectedCarModel, currCarModel, "Models should be matching.");
            Assert.AreEqual(expectedCarFuelConsumption, currCarFuelConsumption, "Consumption should be matching.");
            Assert.AreEqual(expectedCarFuelCapacity, currCarFuelCapacity, "FuelCapacity should be matching.");
        }


        [TestCase("", "Yaris", 5, 60)]
        [TestCase(null, "Yaris", 5, 60)]

        public void CreateCarWithNullOrEmptyMakeShouldReturnAnError(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Make cannot be null or empty!");
        }


        [TestCase("Kia", "", 5, 60)]
        [TestCase("BMW", null, 5, 60)]
        public void CreateCarWithNullOrEmptyModelShouldReturnAnError(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Model cannot be null or empty!");
        }


        [TestCase("Kia", "Sportage", 0, 55.5)]
        [TestCase("BMW", "M5", -112.5, 33.5)]
        public void CreateCarWithZeroOrNEgativeFuelConsumptionShouldReturnAnError(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Fuel consumption cannot be zero or negative!");
        }


        [TestCase("Kia", "Sportage", 10, -0)]
        [TestCase("Kia", "Sportage", 10, 0)]
        [TestCase("BMW", "M5", 15, -43)]
        [TestCase("BMW", "X6", 18, -28.5)]
        public void CreateCarWithZeroOrNEgativeFuelCapacityShouldReturnAnError(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            }, "Fuel capacity cannot be zero or negative!");
        }


        [TestCase(-5)]
        [TestCase(-1)]
        [TestCase(-22.5)]
        public void CarFuelAmountCanNotBeNegative(double fuelAmount)
        {
            Car car = new Car("Kia", "Sportage", 6.5, 45);


            Assert.Throws<System.Reflection.TargetInvocationException>(() =>
            {
                car.GetType().GetProperty("FuelAmount").SetValue(car, fuelAmount);
            }, "Fuel amount cannot be negative!");
        }


        [TestCase(20)]
        [TestCase(30)]
        [TestCase(65)]
        public void RefuelingCarShouldAddFuelIntoTank(double fuel)
        {
            Car car = new Car("BMV", "X5", 10, 65);
            car.Refuel(fuel);

            double expectedRefuelResult = fuel;
            double actualFuel = car.FuelAmount;

            Assert.AreEqual(expectedRefuelResult, actualFuel, "Fuel amounts need to be matching.");
        }



        [TestCase(65)]
        [TestCase(85.5)]
        [TestCase(100.5)]
        public void RefuelingFuelMoreThanFuelTankShouldResultInMaximumFuelEqualToFuelTank(double fuel)
        {
            Car car = new Car("BMV", "X5", 10, 65);
            car.Refuel(fuel);

            double expectedRefuelResult = car.FuelCapacity;
            double actualFuel = car.FuelAmount;

            Assert.AreEqual(expectedRefuelResult, actualFuel, "Fuel amount cannot exceed maximum Fuel Capacity");
        }


        [TestCase(0)]
        [TestCase(-0)]
        [TestCase(-5)]
        [TestCase(-45.5)]
        public void RefuelingAmountCannotBeZeroOrNegative(double fuel)
        {
            Car car = new Car("BMV", "X5", 10, 65);

            Assert.Throws<ArgumentException>(() =>
            {
                car.Refuel(fuel);
            }, "Fuel amount cannot be zero or negative!");
        }


        [TestCase(10)]
        [TestCase(15)]
        [TestCase(35.5)]
        public void DriveMethodShouldReduceFuelAmount(double distance)
        {
            Car car = new Car("BMV", "M3", 10, 60);
            car.Refuel(60);

            double fuelNeeded = (distance / 100) * car.FuelConsumption;

            double expectedFuelAmount = 60 - ((distance / 100) * 10);
            double actualFuelAmount = car.FuelAmount - fuelNeeded;

            Assert.AreEqual(expectedFuelAmount, actualFuelAmount, "Fuel amount should be reduced with correct value.");
        }



        [TestCase(10000)]
        [TestCase(15000)]
        public void DrivingWithNotEnoughFuelShouldReturnAnError(double distance)
        {
            Car car = new Car("BMV", "M3", 10, 60);
            car.Refuel(60);

            Assert.Throws<InvalidOperationException>(() =>
            {
                car.Drive(distance);
            },"You don't have enough fuel to drive!");

        }



    }
}