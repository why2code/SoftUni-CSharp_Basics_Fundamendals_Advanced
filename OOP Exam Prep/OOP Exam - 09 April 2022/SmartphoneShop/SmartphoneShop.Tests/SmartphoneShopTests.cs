using System;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [TestCase("LG", 10)]
        [TestCase("Samsung", 35)]
        [TestCase("Apple", 20)]
        public void SmartphoneConstructorShouldGenerateSmartphoneCorrectly(string modelName, int maximumBatteryCharge)
        {
            Smartphone phone = new Smartphone(modelName, maximumBatteryCharge);

            string expectedName = modelName;
            string actualName = phone.ModelName;

            int expectedMaxCharge = maximumBatteryCharge;
            int actualMaxCharge = phone.MaximumBatteryCharge;

            int expectedCurrentCharge = maximumBatteryCharge;
            int actualCurrentCharge = phone.CurrentBateryCharge;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedMaxCharge, actualMaxCharge);
            Assert.AreEqual(expectedCurrentCharge, actualCurrentCharge);
        }

        [TestCase(10)]
        [TestCase(150)]
        [TestCase(0)]
        public void GeneratingShopShouldCreateANewShopWithProvidedCount(int capacity)
        {
            Shop shop = new Shop(capacity);
            int expectedCapacity = capacity;
            int actualCapacity = shop.Capacity;
            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [TestCase(-5)]
        [TestCase(-10)]
        [TestCase(-1)]
        public void ProvidingNegativeCountShouldThrowException(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Shop shop = new Shop(capacity);
            }, "Invalid capacity.");

        }

        [Test]
        public void CountPropertyShouldReturnCapacityOfTheListOfShops()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("LG", 10);
            shop.Add(phone);

            int expectedCount = 1;
            int actualCount = shop.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddingDuplicateSmarphoneShouldThrowException()
        {
            Shop shop = new Shop(5);
            Smartphone phone = new Smartphone("LG", 10);
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phone);
            }, $"The phone model {phone.ModelName} already exist.");
        }


        [Test]
        public void AddingSmarphoneOverMaxCapacityShouldThrowException()
        {
            Shop shop = new Shop(1);
            Smartphone phone = new Smartphone("LG", 10);
            Smartphone phoneTwo = new Smartphone("Samsung", 10);
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Add(phoneTwo);
            }, "The shop is full.");
        }

        [Test]
        public void AddingSmarphonesShouldWorkCorrectlyWhenNotDuplicatedAndCapacityIsAvailable()
        {
            Shop shop = new Shop(3);
            Smartphone phone = new Smartphone("LG", 10);
            Smartphone phoneTwo = new Smartphone("Samsung", 10);
            shop.Add(phone);
            shop.Add(phoneTwo);

            int actualCount = shop.Count;
            int expectedCount = 2;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TryingToRemoveMissingPhoneShouldThrowException()
        {
            Shop shop = new Shop(3);
            Smartphone phone = new Smartphone("LG", 10);
            shop.Add(phone);

            string phoneNameToRemove = "Samsung";
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.Remove(phoneNameToRemove);

            }, $"The phone model {phoneNameToRemove} doesn't exist.");
        }

        [Test]
        public void RemovingPhoneFromTheShopWhichIsPartOfTheShopShouldWork()
        {
            Shop shop = new Shop(3);
            Smartphone phone = new Smartphone("LG", 10);
            shop.Add(phone);

            string phoneNameToRemove = phone.ModelName;

            shop.Remove(phoneNameToRemove);

            int expectedCount = 0;
            int actualCount = shop.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void TestingNonexistingPhoneShouldThrowException()
        {
            Shop shop = new Shop(3);
            Smartphone phone = new Smartphone("LG", 10);
            shop.Add(phone);

            string phoneToTest = "Xiaomi";
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(phoneToTest, 5);
            },$"The phone model {phoneToTest} doesn't exist.");
        }

        [Test]
        public void TestingPhoneWithUnsufficienBatteryUsageShouldThrowException()
        {
            Shop shop = new Shop(3);
            Smartphone phone = new Smartphone("LG", 10);
            shop.Add(phone);

            string phoneToTest = phone.ModelName;
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.TestPhone(phoneToTest, 50);
            },$"The phone model {phoneToTest} is low on batery.");
        }


        [Test]
        public void SuccessfullyTestingPhoneShouldReduceCurrentBatteryCharge()
        {
            Shop shop = new Shop(3);
            Smartphone phone = new Smartphone("LG", 10);
            shop.Add(phone);

            shop.TestPhone(phone.ModelName, 3);

            int expectedCurrentBatteryCharge = 7;
            int actualCurrentBatteryCharge = phone.CurrentBateryCharge;

            Assert.AreEqual(expectedCurrentBatteryCharge, actualCurrentBatteryCharge);
        }

        [Test]
        public void ChargingNonexistingPhoneShouldThrowException()
        {
            Shop shop = new Shop(3);
            Smartphone phone = new Smartphone("LG", 10);
            shop.Add(phone);

            string phoneToTest = "Xiaomi";
            Assert.Throws<InvalidOperationException>(() =>
            {
                shop.ChargePhone(phoneToTest);
            },$"The phone model {phoneToTest} doesn't exist.");
        }


        [Test]
        public void SuccessfullyChargingPhoneShouldIncreaseCurrentBatteryChargeToMaximumCharge()
        {
            Shop shop = new Shop(3);
            Smartphone phone = new Smartphone("LG", 10);
            shop.Add(phone);

            shop.TestPhone(phone.ModelName,6);

            int expectedCurrentBatteryCharge = 4;
            int actualCurrentBatteryCharge = phone.CurrentBateryCharge;
            Assert.AreEqual(expectedCurrentBatteryCharge, actualCurrentBatteryCharge);

            shop.ChargePhone(phone.ModelName);
            int expectedCurrentChargeAfterCharePhoneMethod = phone.MaximumBatteryCharge;
            int actualBatteryChargeAfterChargePhoneMethod = phone.CurrentBateryCharge;
            Assert.AreEqual(expectedCurrentChargeAfterCharePhoneMethod, actualBatteryChargeAfterChargePhoneMethod);
        }

    }
}