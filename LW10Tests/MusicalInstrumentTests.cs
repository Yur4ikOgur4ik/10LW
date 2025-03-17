using MusicalInstruments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LW10Tests
{
    [TestClass]
    public sealed class MusicalInstrumentTests
    {
        [TestMethod]
        public void SetName_WithValidName()
        {
            var instrument = new MusicalInstrument();
            instrument.Name = "Aboba";
            Assert.AreEqual("Aboba", instrument.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_WithEmptyString_ThrowsException()
        {
            var instrument = new MusicalInstrument();
            instrument.Name = string.Empty;
        }

        [TestMethod]
        public void MusicalInstrument_DefaultConstructor_InitializesCorrectly()
        {
            var instrument = new MusicalInstrument();
            Assert.AreEqual("Unknown Instrument", instrument.Name);
            Assert.AreEqual(0, instrument.ID.id);
        }

        [TestMethod]
        public void MusicalInstrument_ParameterizedConstructor_InitializesCorrectly()
        {
            var instrument = new MusicalInstrument("Guitar", 123);
            Assert.AreEqual("Guitar", instrument.Name);
            Assert.AreEqual(123, instrument.ID.id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_WithWhiteSpace_ThrowsException()
        {
            var instrument = new MusicalInstrument();
            instrument.Name = "   ";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_NullValue_ThrowsException()
        {
            var instrument = new MusicalInstrument();
            instrument.Name = null;
        }

        [TestMethod]
        public void RandomInit_SetsNameFromAllowedList()
        {
            var instrument = new MusicalInstrument();
            string[] allowedNames = { "Piano", "Guitar", "ElectroGuitar" };
            instrument.RandomInit();
            Assert.IsTrue(allowedNames.Contains(instrument.Name));
        }

        [TestMethod]
        public void RandomInit_GeneratesIDBetween0And100()
        {
            var instrument = new MusicalInstrument();
            instrument.RandomInit();
            Assert.IsTrue(instrument.ID.id >= 0 && instrument.ID.id <= 100);
        }

        [TestMethod]
        public void Equals_SameObject_ReturnsTrue()
        {
            var instrument = new MusicalInstrument("Piano", 123);
            Assert.IsTrue(instrument.Equals(instrument));
        }

        [TestMethod]
        public void Equals_DifferentObjects_ReturnsTrue()
        {
            var instrument1 = new MusicalInstrument("Piano", 123);
            var instrument2 = new MusicalInstrument("Piano", 123);
            Assert.IsTrue(instrument1.Equals(instrument2));
        }

        [TestMethod]
        public void Equals_NullObject_ReturnsFalse()
        {
            var instrument = new MusicalInstrument("Piano", 123);
            Assert.IsFalse(instrument.Equals(null));
        }

        [TestMethod]
        public void Equals_DifferentTypes_ReturnsFalse()
        {
            var instrument = new MusicalInstrument("Piano", 123);
            object differentObject = new object();
            Assert.IsFalse(instrument.Equals(differentObject));
        }

        [TestMethod]
        public void CompareTo_Null_ReturnsNegative()
        {
            var instrument = new MusicalInstrument("Piano", 123);
            Assert.AreEqual(-1, instrument.CompareTo(null));
        }

        [TestMethod]
        public void CompareTo_SameName_ReturnsZero()
        {
            var instrument1 = new MusicalInstrument("Piano", 123);
            var instrument2 = new MusicalInstrument("Piano", 123);
            Assert.AreEqual(0, instrument1.CompareTo(instrument2));
        }

        [TestMethod]
        public void CompareTo_LowerName_ReturnsNegative()
        {
            var instrument1 = new MusicalInstrument("H", 123);
            var instrument2 = new MusicalInstrument("Z", 123);
            Assert.IsTrue(instrument1.CompareTo(instrument2) < 0);
        }

        [TestMethod]
        public void CompareTo_HigherName_ReturnsPositive()
        {
            var instrument1 = new MusicalInstrument("z", 123);
            var instrument2 = new MusicalInstrument("h", 123);
            Assert.IsTrue(instrument1.CompareTo(instrument2) > 0);
        }

        [TestMethod]
        public void Clone_CreatesDeepCopy()
        {
            var original = new MusicalInstrument("Saxophone", 800);
            original.RandomInit();
            var clone = (MusicalInstrument)original.Clone();
            Assert.AreNotSame(original, clone);
            Assert.AreEqual(original.Name, clone.Name);
            Assert.AreEqual(original.ID.id, clone.ID.id);
        }

        [TestMethod]
        public void ShallowCopy_CreatesShallowCopy()
        {
            var original = new MusicalInstrument("Viola", 900);
            original.RandomInit();
            var shallowCopy = (MusicalInstrument)original.ShallowCopy();
            Assert.AreNotSame(original, shallowCopy);
            Assert.AreEqual(original.Name, shallowCopy.Name);
            Assert.AreSame(original.ID, shallowCopy.ID);
        }
    }
}