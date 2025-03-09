using MusicalInstruments;
using System.Globalization;

namespace LW10Tests
{
    [TestClass]
    public sealed class EguitarTests
    {
        [TestMethod]
        public void PowerSource_WithValidValue_SetsCorrectly()
        {
            // Arrange
            var guitar = new ElectroGuitar();
            string validSource = "USB";

            // Act
            guitar.PowerSource = validSource;

            // Assert
            Assert.AreEqual(validSource, guitar.PowerSource);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PowerSource_InvalidValue_ThrowsException()
        {
            // Arrange
            var guitar = new ElectroGuitar();

            // Act
            guitar.PowerSource = "Jopa";
        }



        [TestMethod]
        public void ElectroGuitar_DefaultConstructor_InitializesCorrectly()
        {
            // Arrange & Act
            var guitar = new ElectroGuitar();

            // Assert
            Assert.AreEqual("Battery", guitar.PowerSource);
            Assert.AreEqual(6, guitar.StringCount);
            Assert.AreEqual("Unknown Instrument", guitar.Name);
            Assert.AreEqual(0, guitar.ID.id);
        }

        [TestMethod]
        public void ElectroGuitar_ParameterizedConstructor_InitializesCorrectly()
        {
            // Arrange
            string expectedName = "Electric Guitar";
            int expectedId = 789;
            int expectedStringCount = 7;
            string expectedPowerSource = "Fixed Power";

            // Act
            var guitar = new ElectroGuitar(expectedName, expectedId, expectedStringCount, expectedPowerSource);

            // Assert
            Assert.AreEqual(expectedName, guitar.Name);
            Assert.AreEqual(expectedId, guitar.ID.id);
            Assert.AreEqual(expectedStringCount, guitar.StringCount);
            Assert.AreEqual(expectedPowerSource, guitar.PowerSource);
        }

        [TestMethod]
        public void RandomInit_SetsValidPowerSource()
        {
            // Arrange
            var guitar = new ElectroGuitar();
            string[] allowedSources = { "Batteries", "Battery", "Fixed Power", "USB" };

            // Act
            guitar.RandomInit();

            // Assert
            Assert.IsTrue(allowedSources.Contains(guitar.PowerSource));
        }


        [TestMethod]
        public void Equals_SamePowerSource_ReturnsTrue()
        {
            // Arrange
            var guitar1 = new ElectroGuitar("Guitar", 100, 6, "Battery");
            var guitar2 = new ElectroGuitar("guitar", 100, 6, "battery"); // case-insensitive

            // Act & Assert
            Assert.IsTrue(guitar1.Equals(guitar2));
        }

        [TestMethod]
        public void Equals_DifferentPowerSource_ReturnsFalse()
        {
            // Arrange
            var guitar1 = new ElectroGuitar("Guitar", 100, 6, "Battery");
            var guitar2 = new ElectroGuitar("Guitar", 100, 6, "USB");

            // Act & Assert
            Assert.IsFalse(guitar1.Equals(guitar2));
        }

        

        [TestMethod]
        public void ToString_CustomFormat_ProducesCorrectOutput()
        {
            // Arrange
            var guitar = new ElectroGuitar("ad", 200, 6, "USB");

            // Act
            string result = guitar.ToString("P&S", CultureInfo.CurrentCulture);

            // Assert
            Assert.AreEqual("Power source USB, number of strings 6", result);
        }

        [TestMethod]
        public void ToString_DefaultFormat_ContainsAllProperties()
        {
            var guitar = new ElectroGuitar("adsad", 200, 6, "USB");
            string expected = $"Id: {200}, name - adsad, number of strings: 6, power source: USB";

            string result = guitar.ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ToString_InvalidFormat_ThrowsException()
        {

            var guitar = new ElectroGuitar();

            guitar.ToString("boba", CultureInfo.CurrentCulture);
        }

    }
}

