using MusicalInstruments;
namespace LW10Tests
{
    [TestClass]
    public sealed class MusicalInstrumentTests
    {

        [TestMethod]
        public void SetName_WithValidName_ShouldSetCorrectly()
        {

            MusicalInstrument instr = new MusicalInstrument();
            string validName = "Aboba";


            instr.Name = validName;


            Assert.AreEqual(validName, instr.Name);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_WithEmptyString_ShouldThrowArgumentNullException()
        {
            // Arrange
            var instrument = new MusicalInstrument();

            // Act
            instrument.Name = string.Empty;
        }

        [TestMethod]
        public void MusicalInstrument_DefaultConstructor_InitializesCorrectly()
        {
            // Arrange & Act
            var instrument = new MusicalInstrument();

            // Assert
            Assert.AreEqual("Unknown Instrument", instrument.Name);
            Assert.AreEqual(0, instrument.ID.id);
            
        }

        [TestMethod]
        public void MusicalInstrument_ParameterizedConstructor_InitializesCorrectly()
        {
            // Arrange
            string expectedName = "Guitar";
            int expectedId = 123;

            // Act
            var instrument = new MusicalInstrument(expectedName, expectedId);

            // Assert
            Assert.AreEqual(expectedName, instrument.Name);
            Assert.AreEqual(expectedId, instrument.ID.id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_WithWhiteSpace_ShouldThrowArgumentNullException()
        {
            // Arrange
            var instrument = new MusicalInstrument();

            // Act
            instrument.Name = "   ";
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_NullValue_ShouldThrowArgumentNullException()
        {
            // Arrange
            var instrument = new MusicalInstrument();

            // Act
            instrument.Name = null;
        }

        [TestMethod]
        public void RandomInit_ShouldSetNameFromAllowedList()
        {
            // Arrange
            var instrument = new MusicalInstrument();
            string[] allowedNames = { "Piano", "Guitar", "ElectroGuitar" };

            // Act
            instrument.RandomInit();

            // Assert
            Assert.IsTrue(allowedNames.Contains(instrument.Name));
        }

        [TestMethod]
        public void RandomInit_ShouldGenerateIDBetween0And100()
        {
            // Arrange
            var instrument = new MusicalInstrument();

            // Act
            instrument.RandomInit();

            // Assert
            Assert.IsTrue(instrument.ID.id >= 0 && instrument.ID.id <= 100);
        }

        [TestMethod]
        public void Equals_SameObject_ShouldReturnTrue()
        {
            // Arrange
            var instrument = new MusicalInstrument("Piano", 123);

            // Act & Assert
            Assert.IsTrue(instrument.Equals(instrument));
        }

        [TestMethod]
        public void Equals_DifferentObjects_ShouldReturnTrue()
        {
            var instrument1 = new MusicalInstrument("Piano", 123);
            var instrument2 = new MusicalInstrument("Piano", 123);
            Assert.IsTrue(instrument1.Equals(instrument2));
        }

        public void Equals_NullObject_ShouldReturnFalse()
        {
            // Arrange
            var instrument = new MusicalInstrument("Piano", 123);

            // Act & Assert
            Assert.IsFalse(instrument.Equals(null));
        }

        [TestMethod]
        public void Equals_DifferentTypes_ShouldReturnFalse()
        {
            // Arrange
            var instrument = new MusicalInstrument("Piano", 123);
            object differentObject = new object();

            // Act & Assert
            Assert.IsFalse(instrument.Equals(differentObject));
        }

        [TestMethod]
        public void CompareTo_Null_ReturnsNegative()
        {
            // Arrange
            var instrument = new MusicalInstrument("Piano", 123);

            // Act & Assert
            Assert.AreEqual(-1, instrument.CompareTo(null));
        }

        [TestMethod]
        public void CompareTo_SameName_ReturnsZero()
        {
            // Arrange
            var instrument1 = new MusicalInstrument("Piano", 123);
            var instrument2 = new MusicalInstrument("Piano", 123);

            // Act & Assert
            Assert.AreEqual(0, instrument1.CompareTo(instrument2));
        }

        [TestMethod]
        public void CompareTo_LowerName_ReturnsNegative()
        {
            // Arrange
            var instrument1 = new MusicalInstrument("H", 123);
            var instrument2 = new MusicalInstrument("Z", 123);

            // Act & Assert
            Assert.IsTrue(instrument1.CompareTo(instrument2) < 0);
        }

        [TestMethod]
        public void CompareTo_HigherName_ReturnsPositive()
        {
            // Arrange
            var instrument1 = new MusicalInstrument("z", 123);
            var instrument2 = new MusicalInstrument("h", 123);

            // Act & Assert
            Assert.IsTrue(instrument1.CompareTo(instrument2) > 0);
        }

        [TestMethod]
        public void Clone_CreatesDeepCopy()
        {
            // Arrange
            var original = new MusicalInstrument("Saxophone", 800);
            original.RandomInit();

            // Act
            var clone = (MusicalInstrument)original.Clone();

            // Assert
            Assert.AreNotSame(original, clone);
            Assert.AreEqual(original.Name, clone.Name);
            Assert.AreEqual(original.ID.id, clone.ID.id);
            
        }

        [TestMethod]
        public void ShallowCopy_CreatesShallowCopy()
        {
            // Arrange
            var original = new MusicalInstrument("Viola", 900);
            original.RandomInit();

            // Act
            var shallowCopy = (MusicalInstrument)original.ShallowCopy();

            // Assert
            Assert.AreNotSame(original, shallowCopy);
            Assert.AreEqual(original.Name, shallowCopy.Name);
            Assert.AreSame(original.ID, shallowCopy.ID);
        }


    }
}
