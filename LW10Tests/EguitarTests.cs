using MusicalInstruments;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LW10Tests
{
    [TestClass]
    public sealed class EguitarTests
    {
        [TestMethod]
        public void PowerSource_WithValidValue()
        {
            var guitar = new ElectroGuitar();
            guitar.PowerSource = "USB";
            Assert.AreEqual("USB", guitar.PowerSource);
        }

        [TestMethod]
        public void PowerSource_InvalidValue_ThrowsException()//check expeption
        {
            var guitar = new ElectroGuitar();
            var exception = Assert.ThrowsException<ArgumentException>(() => guitar.PowerSource = "Jopa");
            Assert.AreEqual("Invalid power source.", exception.Message);
        }

        [TestMethod]
        public void ElectroGuitar_DefaultConstructor()
        {
            var guitar = new ElectroGuitar();
            Assert.AreEqual("Battery", guitar.PowerSource);
            Assert.AreEqual(6, guitar.StringCount);
            Assert.AreEqual("Unknown Instrument", guitar.Name);
            Assert.AreEqual(0, guitar.ID.id);
        }

        [TestMethod]
        public void ElectroGuitar_ParameterizedConstructor()
        {
            var guitar = new ElectroGuitar("Electric Guitar", 789, 7, "Fixed Power");
            Assert.AreEqual("Electric Guitar", guitar.Name);
            Assert.AreEqual(789, guitar.ID.id);
            Assert.AreEqual(7, guitar.StringCount);
            Assert.AreEqual("Fixed Power", guitar.PowerSource);
        }

        [TestMethod]
        public void RandomInit_SetsValidPowerSource()
        {
            var guitar = new ElectroGuitar();
            guitar.RandomInit();
            string[] allowedSources = { "Batteries", "Battery", "Fixed Power", "USB" };
            Assert.IsTrue(allowedSources.Contains(guitar.PowerSource));
        }

        [TestMethod]
        public void Equals_SamePowerSource_CaseInsensitive()
        {
            var guitar1 = new ElectroGuitar("Guitar", 100, 6, "Battery");
            var guitar2 = new ElectroGuitar("guitar", 100, 6, "battery");//bolshie bukvi == small bukvi
            Assert.IsTrue(guitar1.Equals(guitar2));
        }

        [TestMethod]
        public void Equals_DifferentPowerSource()
        {
            var guitar1 = new ElectroGuitar("Guitar", 100, 6, "Battery");
            var guitar2 = new ElectroGuitar("Guitar", 100, 6, "USB");
            Assert.IsFalse(guitar1.Equals(guitar2));
        }

        [TestMethod]
        public void ToString_CustomFormat_ProducesCorrectOutput()
        {
            var guitar = new ElectroGuitar("ad", 200, 6, "USB");
            string result = guitar.ToString("P&S", CultureInfo.CurrentCulture);
            Assert.AreEqual("Power source USB, number of strings 6", result);
        }

        [TestMethod]
        public void ToString_DefaultFormat_ContainsAllProperties()
        {
            var guitar = new ElectroGuitar("adsad", 200, 6, "USB");
            string expected = $"Id: {200}, name - adsad, number of strings: 6, power source: USB";
            Assert.AreEqual(expected, guitar.ToString());
        }

        [TestMethod]
        public void ToString_InvalidFormat_ThrowsException()//test for Iformattable
        {
            var guitar = new ElectroGuitar();
            Assert.ThrowsException<Exception>(() => guitar.ToString("boba", CultureInfo.CurrentCulture));
        }
    }
}