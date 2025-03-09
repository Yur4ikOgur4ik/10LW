using MusicalInstruments;

namespace LW10Tests
{
    [TestClass]
    public sealed class GuitarTests
    {
        
        [TestMethod]
        public void StringCount_WithValidValue_SetsCorrectly()
        {
            // Arrange
            var guitar = new Guitar();
            int validCount = 6;

            // Act
            guitar.StringCount = validCount;

            // Assert
            Assert.AreEqual(validCount, guitar.StringCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StringCount_LessThan3_ThrowsException()
        {
            // Arrange
            var guitar = new Guitar();

            // Act
            guitar.StringCount = 2; // меньше 3
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StringCount_GreaterThan20_ThrowsException()
        {
            // Arrange
            var guitar = new Guitar();

            // Act
            guitar.StringCount = 21; // больше 20
        }

        [TestMethod]
        public void Guitar_DefaultConstructor_InitializesCorrectly()
        {
            // Arrange & Act
            var guitar = new Guitar();

            // Assert
            Assert.AreEqual(6, guitar.StringCount);
            Assert.AreEqual("Unknown Instrument", guitar.Name);
            Assert.AreEqual(0, guitar.ID.id);
        }

        [TestMethod]
        public void Guitar_ParameterizedConstructor_InitializesCorrectly()
        {
            // Arrange
            string expectedName = "Acoustic Guitar";
            int expectedId = 456;
            int expectedStringCount = 7;

            // Act
            var guitar = new Guitar(expectedName, expectedId, expectedStringCount);

            // Assert
            Assert.AreEqual(expectedName, guitar.Name);
            Assert.AreEqual(expectedId, guitar.ID.id);
            Assert.AreEqual(expectedStringCount, guitar.StringCount);
        }

        [TestMethod]
        public void RandomInit_SetsValidNameAndStringCount()
        {
            // Arrange
            var guitar = new Guitar();
            string[] allowedNames = { "Balalaika", "Bass guitar", "Acoustic guitar", "Classic guitar" };

            // Act
            guitar.RandomInit();

            // Assert
            Assert.IsTrue(allowedNames.Contains(guitar.Name));
            Assert.IsTrue(guitar.StringCount >= 3 && guitar.StringCount <= 20);
        }

        [TestMethod]
        public void Equals_SameInstance_ReturnsTrue()
        {
            // Arrange
            var guitar = new Guitar("Guitar", 100, 6);

            // Act & Assert
            Assert.IsTrue(guitar.Equals(guitar));
        }

        [TestMethod]
        public void Equals_DifferentStringCount_ReturnsFalse()
        {
            // Arrange
            var guitar1 = new Guitar("Guitar", 100, 6);
            var guitar2 = new Guitar("Guitar", 100, 7);

            // Act & Assert
            Assert.IsFalse(guitar1.Equals(guitar2));
        }

        [TestMethod]
        public void Equals_SameValues_ReturnsTrue()
        {
            // Arrange
            var guitar1 = new Guitar("Guitar", 100, 6);
            var guitar2 = new Guitar("Guitar", 100, 6);

            // Act & Assert
            Assert.IsTrue(guitar1.Equals(guitar2));
        }


        [TestMethod]
        public void ToString_ContainsAllProperties()
        {
            // Arrange
            var guitar = new Guitar("Acoustic", 200, 6);

            // Act
            string result = guitar.ToString();

            // Assert
            Assert.AreEqual(result, "Id: 200, name - Acoustic, number of strings: 6");
        }


    }
} 

