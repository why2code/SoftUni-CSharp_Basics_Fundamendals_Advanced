
namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class RobotsTests
    {
        [Test]
        public void CreatingARobotShouldInitializeCorrectData()
        {
            string robotName = "Gosho";
            int battCapacity = 5;

            Robot rob = new Robot(robotName, battCapacity);

            Assert.AreEqual(robotName, rob.Name);
            Assert.AreEqual(battCapacity, rob.Battery);
            Assert.AreEqual(battCapacity, rob.MaximumBattery);

        }

        [Test]
        public void CreatingRobotManagerShouldProduceCorrectCapacity()
        {
            RobotManager manager = new RobotManager(10);
            Assert.AreEqual(10, manager.Capacity);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        [TestCase(-100)]
        public void RobotManagerCapacityMustBeAboveZero(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager rob = new RobotManager(capacity);
            }, "Invalid capacity!");
        }

        [Test]
        public void ManagerCountShouldReturnCorrectValue()
        {
            RobotManager rob = new RobotManager(5);
            Robot myRobot = new Robot("Gosho", 10);
            rob.Add(myRobot);

            int expectedCount = 1;
            int actualCount = rob.Count;
            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void AddingDuplicateRobotsShouldThrowException()
        {
            RobotManager rob = new RobotManager(5);
            Robot myRobot = new Robot("Gosho", 10);
            rob.Add(myRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                rob.Add(myRobot);
            }, $"There is already a robot with name {myRobot.Name}!");

        }

        [Test]
        public void NoRobotShouldBeAddedIfCapacityIsMaxedOut()
        {
            RobotManager rob = new RobotManager(2);
            Robot myRobot = new Robot("Gosho", 10);
            Robot mySecondRobot = new Robot("Pesho", 15);
            Robot myThirdRobot = new Robot("Ivan", 32);
            rob.Add(myRobot);
            rob.Add(mySecondRobot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                rob.Add(myThirdRobot);
            }, "Not enough capacity!");
        }

        [Test]
        public void AddingMaxCapacityRobotsShouldWorkAndAddAllRobotsIntoTheManager()
        {
            RobotManager rob = new RobotManager(3);
            Robot myRobot = new Robot("Gosho", 10);
            Robot mySecondRobot = new Robot("Pesho", 15);
            Robot myThirdRobot = new Robot("Ivan", 32);
            rob.Add(myRobot);
            rob.Add(mySecondRobot);
            rob.Add(myThirdRobot);

            int actualCapacity = rob.Count;
            int expectedCapacity = 3;
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void AttemptingToRemoveUnexistingRobot()
        {
            RobotManager rob = new RobotManager(3);
            Robot myRobot = new Robot("Gosho", 10);
            Robot mySecondRobot = new Robot("Pesho", 15);

            rob.Add(myRobot);
            rob.Add(mySecondRobot);

            string nameToRemove = "Ivan";
            Assert.Throws<InvalidOperationException>(() =>
            {
                rob.Remove(nameToRemove);
            }, $"Robot with the name {nameToRemove} doesn't exist!");
        }


        [Test]
        public void RemovingExistingRobotShouldRemoveItFromRobotManagerAndReduceCapacity()
        {
            RobotManager rob = new RobotManager(3);
            Robot myRobot = new Robot("Gosho", 10);
            Robot mySecondRobot = new Robot("Pesho", 15);

            rob.Add(myRobot);
            rob.Add(mySecondRobot);

            string nameToRemove = "Gosho";
            rob.Remove(nameToRemove);

            int expectedCountAfterRemoval = 1;
            int actualCountAfterRemoval = rob.Count;

            Assert.AreEqual(expectedCountAfterRemoval, actualCountAfterRemoval);
         

        }

        [Test]
        public void RemovingTwiceExistingRobotShouldThrowException()
        {
            RobotManager rob = new RobotManager(3);
            Robot myRobot = new Robot("Gosho", 10);
            Robot mySecondRobot = new Robot("Pesho", 15);

            rob.Add(myRobot);
            rob.Add(mySecondRobot);

            string nameToRemove = "Gosho";
            rob.Remove(nameToRemove);

           
            Assert.Throws<InvalidOperationException>(() =>
            {
                rob.Remove(nameToRemove);
            }, $"Robot with the name {nameToRemove} doesn't exist!");

        }


        [Test]
        public void TryingToPutNonexistingRobotToWorkShouldThrowException()
        {
            RobotManager rob = new RobotManager(3);
            Robot myRobot = new Robot("Gosho", 10);
            Robot mySecondRobot = new Robot("Pesho", 15);

            rob.Add(myRobot);
            rob.Add(mySecondRobot);

            string workingRobot = "Zlatka";
            Assert.Throws<InvalidOperationException>(() =>
            {
                rob.Work(workingRobot, "IT", 10);
            }, $"Robot with the name {workingRobot} doesn't exist!");
        }



        [Test]
        public void IfRequiredJobBatteryIsMoreThanRobotsBatteryAnErrorShouldBeThrown()
        {
            RobotManager rob = new RobotManager(3);
            Robot myRobot = new Robot("Gosho", 10);
            Robot mySecondRobot = new Robot("Pesho", 15);

            rob.Add(myRobot);
            rob.Add(mySecondRobot);

            string workingRobot = "Gosho";
            Assert.Throws<InvalidOperationException>(() =>
            {
                rob.Work(workingRobot, "IT", 20);
            }, $"{myRobot.Name} doesn't have enough battery!");
        }




        [Test]
        public void HavingEnoughBatteryShouldAllowRobotToWorkAndReduceHisBattery()
        {
            RobotManager rob = new RobotManager(3);
            Robot myRobot = new Robot("Gosho", 10);
            Robot mySecondRobot = new Robot("Pesho", 15);

            rob.Add(myRobot);
            rob.Add(mySecondRobot);

            string workingRobot = "Gosho";
            rob.Work(workingRobot, "IT", 5);

            int expectedBatteryAfterWork = 5;
            int actualBatteryAfterWork = myRobot.Battery;
            Assert.AreEqual(expectedBatteryAfterWork, actualBatteryAfterWork);
        }


        [Test]
        public void ChargingNonExistingRobotShouldThrowException()
        {
            RobotManager rob = new RobotManager(3);
            Robot myRobot = new Robot("Gosho", 10);
            Robot mySecondRobot = new Robot("Pesho", 15);

            rob.Add(myRobot);
            rob.Add(mySecondRobot);

            string chargingRobot = "Maria";
            Assert.Throws<InvalidOperationException>(() =>
            {
                rob.Charge(chargingRobot);
            }, $"Robot with the name {chargingRobot} doesn't exist!");
        }

        [Test]
        public void ChargingSucccessfullyShouldIncreaseBatteryToMaxBatteryCapacity()
        {
            RobotManager rob = new RobotManager(3);
            Robot myRobot = new Robot("Gosho", 10);
            Robot mySecondRobot = new Robot("Pesho", 15);

            rob.Add(myRobot);
            rob.Add(mySecondRobot);

            string chargingRobot = "Gosho";
            rob.Work(chargingRobot, "IT", 7);
            int batteryBeforeCharging = myRobot.Battery;
            int expectedBattertBeforeCharging = 3;

            rob.Charge(chargingRobot);
            int expectedBatteryAfterCharging = 10;
            int actualBatteryAfterCharging = myRobot.Battery;


            Assert.AreEqual(expectedBattertBeforeCharging, batteryBeforeCharging);
            Assert.AreEqual(expectedBatteryAfterCharging, actualBatteryAfterCharging);
            Assert.AreEqual(myRobot.MaximumBattery,actualBatteryAfterCharging);
        }

    }
}
