using MusicalInstruments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LW10Tests
{
    [TestClass]
    public sealed class GuitarTests
    {
        [TestMethod]
        public void StringCount_WithValidValue_SetsCorrectly()
        {
            var guitar = new Guitar();
            guitar.StringCount = 6;
            Assert.AreEqual(6, guitar.StringCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StringCount_LessThan3_ThrowsException()
        {
            var guitar = new Guitar();
            guitar.StringCount = 2;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StringCount_GreaterThan20_ThrowsException()
        {
            var guitar = new Guitar();
            guitar.StringCount = 21;
        }

        [TestMethod]
        public void Guitar_DefaultConstructor_InitializesCorrectly()
        {
            var guitar = new Guitar();
            Assert.AreEqual(6, guitar.StringCount);
            Assert.AreEqual("Unknown Instrument", guitar.Name);
            Assert.AreEqual(0, guitar.ID.id);
        }

        [TestMethod]
        public void Guitar_ParameterizedConstructor_InitializesCorrectly()
        {
            var guitar = new Guitar("Acoustic Guitar", 456, 7);
            Assert.AreEqual("Acoustic Guitar", guitar.Name);
            Assert.AreEqual(456, guitar.ID.id);
            Assert.AreEqual(7, guitar.StringCount);
        }

        [TestMethod]
        public void RandomInit_SetsValidNameAndStringCount()
        {
            var guitar = new Guitar();
            string[] allowedNames = { "Balalaika", "Bass guitar", "Acoustic guitar", "Classic guitar" };
            guitar.RandomInit();

            Assert.IsTrue(allowedNames.Contains(guitar.Name));
            Assert.IsTrue(guitar.StringCount >= 3 && guitar.StringCount <= 20);
        }

        [TestMethod]
        public void Equals_SameInstance_ReturnsTrue()
        {
            var guitar = new Guitar("Guitar", 100, 6);
            Assert.IsTrue(guitar.Equals(guitar));
        }

        [TestMethod]
        public void Equals_DifferentStringCount_ReturnsFalse()
        {
            var guitar1 = new Guitar("Guitar", 100, 6);
            var guitar2 = new Guitar("Guitar", 100, 7);
            Assert.IsFalse(guitar1.Equals(guitar2));
        }

        [TestMethod]
        public void Equals_SameValues_ReturnsTrue()
        {
            var guitar1 = new Guitar("Guitar", 100, 6);
            var guitar2 = new Guitar("Guitar", 100, 6);
            Assert.IsTrue(guitar1.Equals(guitar2));
        }

        [TestMethod]
        public void ToString_ContainsAllProperties()
        {
            var guitar = new Guitar("Acoustic", 200, 6);
            string result = guitar.ToString();
            Assert.AreEqual("Id: 200, name - Acoustic, number of strings: 6", result);
        }
    }
}