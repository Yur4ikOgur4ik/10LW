using MusicalInstruments;
using Lab10;
using System;

namespace LW10Tests
{
    [TestClass]
    public sealed class ProgramTests
    {

        [TestMethod]
        public void AverageNumberOfStrings_WithGuitars_ReturnsCorrectAverage()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new Guitar("Guitar1", 1, 6),
                new Guitar("Guitar2", 2, 7),
                new ElectroGuitar("ElectroGuitar1", 3, 8, "Battery") // check if works with guiatr
            };

            // Act
            double average = Program.AverageNumberOfStrings(instruments);

            // Assert
            Assert.AreEqual(7, average); // (6 + 7 + 8) / 3 = 7
        }

        [TestMethod]
        public void AverageNumberOfStrings_WithElectroGuitars_ReturnsCorrectAverage()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new ElectroGuitar("ElectroGuitar1", 1, 6, "Battery"),
                new ElectroGuitar("ElectroGuitar2", 2, 7, "Fixed Power")
            };

            // Act
            double average = Program.AverageNumberOfStrings(instruments);

            // Assert
            Assert.AreEqual(6.5, average); // (6 + 7) / 2 = 6.5
        }

        [TestMethod]
        public void AverageNumberOfStrings_MixedInstruments_CalculatesOnlyGuitars()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new Guitar("Acoustic", 1, 6),
                new Piano("Grand", 2, "Octave", 88),
                new ElectroGuitar("Stratocaster", 3, 7, "Fixed Power")
            };

            // Act
            double average = Program.AverageNumberOfStrings(instruments);

            // Assert
            Assert.AreEqual(6.5, average); // (6 + 7) / 2 = 6.5
        }

        [TestMethod]
        public void AverageNumberOfStrings_NoGuitars_ReturnsMinusOne()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new Piano("Piano1", 1, "Octave", 88),
                new Piano("Piano2", 2, "Scale", 76)
            };

            // Act
            double average = Program.AverageNumberOfStrings(instruments);

            // Assert
            Assert.AreEqual(-1, average);
        }

        [TestMethod]
        public void AverageNumberOfStrings_EmptyArray_ReturnsMinusOne()
        {
            // Arrange
            var instruments = new MusicalInstrument[0];

            // Act
            double average = Program.AverageNumberOfStrings(instruments);

            // Assert
            Assert.AreEqual(-1, average);
        }

        [TestMethod]
        public void AverageNumberOfStrings_SingleGuitar_ReturnsSingleStringCount()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new Guitar("Acoustic", 1, 6)
            };

            // Act
            double average = Program.AverageNumberOfStrings(instruments);

            // Assert
            Assert.AreEqual(6, average);
        }

        [TestMethod]
        public void AverageNumberOfStrings_AllElectroGuitars_ReturnsCorrectAverage()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new ElectroGuitar("ElectroGuitar1", 1, 6, "Battery"),
                new ElectroGuitar("ElectroGuitar2", 2, 7, "Fixed Power"),
                new ElectroGuitar("ElectroGuitar3", 3, 8, "USB")
            };

            // Act
            double average = Program.AverageNumberOfStrings(instruments);

            // Assert
            Assert.AreEqual(7.0, average); // (6 + 7 + 8) / 3 = 7.0
        }



        [TestMethod]
        public void NumberOfStringInElectroGuitarsWithFixedPower_ValidCases_ReturnsSum()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new ElectroGuitar("Guitar1", 1, 6, "Fixed Power"),
                new ElectroGuitar("Guitar2", 2, 7, "fixed power"), // регистронезависимо
                new Guitar("Acoustic", 3, 5) // Не ElectroGuitar → игнорируется
            };

            // Act
            int result = Program.NumberOfStringInElectroGuitarsWithFixedPower(instruments);

            // Assert
            Assert.AreEqual(13, result); // 6 + 7
        }

        [TestMethod]
        public void NumberOfStringInElectroGuitarsWithFixedPower_NoMatches_ReturnsMinusOne()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new ElectroGuitar("Guitar1", 1, 6, "Battery"),
                new ElectroGuitar("Guitar2", 2, 7, "USB")
            };

            // Act
            int result = Program.NumberOfStringInElectroGuitarsWithFixedPower(instruments);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void NumberOfStringInElectroGuitarsWithFixedPower_MixedInstruments()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new ElectroGuitar("Guitar1", 1, 6, "Fixed Power"),
                new Piano("Piano", 2, "Octave", 88),
                new ElectroGuitar("Guitar2", 3, 8, "fixed Power") // регистронезависимо
            };

            // Act
            int result = Program.NumberOfStringInElectroGuitarsWithFixedPower(instruments);

            // Assert
            Assert.AreEqual(14, result); // 6 + 8
        }

        [TestMethod]
        public void NumberOfStringInElectroGuitarsWithFixedPower_EmptyArray_ReturnsMinusOne()
        {
            // Arrange
            var instruments = new MusicalInstrument[0];

            // Act
            int result = Program.NumberOfStringInElectroGuitarsWithFixedPower(instruments);

            // Assert
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void NumberOfStringInElectroGuitarsWithFixedPower_SingleMatch_ReturnsStringCount()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new ElectroGuitar("Guitar1", 1, 6, "Fixed Power")
            };

            // Act
            int result = Program.NumberOfStringInElectroGuitarsWithFixedPower(instruments);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void NumberOfStringInElectroGuitarsWithFixedPower_NoElectroGuitars_ReturnsMinusOne()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new Guitar("Guitar", 1, 6),
                new Piano("Piano", 2, "Octave", 88)
            };

            // Act
            int result = Program.NumberOfStringInElectroGuitarsWithFixedPower(instruments);

            // Assert
            Assert.AreEqual(-1, result);
        }



        [TestMethod]
        public void MaxNumberOfKeysOnOctave_ValidCases_ReturnsMax()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new Piano("Piano1", 1, "Octave", 88),
                new Piano("Piano2", 2, "octave", 92), 
                new Piano("Piano3", 3, "Scale", 85) 
            };

            // Act
            int max = Program.MaxNumberOfKeysOnOctave(instruments);

            // Assert
            Assert.AreEqual(92, max);
        }

        [TestMethod]
        public void MaxNumberOfKeysOnOctave_NoPianos_ReturnsMinusOne()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new Guitar("Guitar", 1, 6),
                new ElectroGuitar("Electro", 2, 7, "Battery")
            };

            // Act
            int max = Program.MaxNumberOfKeysOnOctave(instruments);

            // Assert
            Assert.AreEqual(-1, max);
        }

        [TestMethod]
        public void MaxNumberOfKeysOnOctave_MixedConditions()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new Piano("Piano1", 1, "Octave", 88),
                new Piano("Piano2", 2, "octave", 92),
                new Piano("Piano3", 3, "Scale", 85),
                new Piano("Piano4", 4, "Octave", 100)
            };

            // Act
            int max = Program.MaxNumberOfKeysOnOctave(instruments);

            // Assert
            Assert.AreEqual(100, max);
        }

        [TestMethod]
        public void MaxNumberOfKeysOnOctave_NoOctavePianos_ReturnsMinusOne()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new Piano("Piano1", 1, "Scale", 88),
                new Piano("Piano2", 2, "Digital", 76)
            };

            // Act
            int max = Program.MaxNumberOfKeysOnOctave(instruments);

            // Assert
            Assert.AreEqual(-1, max);
        }

        [TestMethod]
        public void MaxNumberOfKeysOnOctave_EmptyArray_ReturnsMinusOne()
        {
            // Arrange
            var instruments = new MusicalInstrument[0];

            // Act
            int max = Program.MaxNumberOfKeysOnOctave(instruments);

            // Assert
            Assert.AreEqual(-1, max);
        }

        [TestMethod]
        public void MaxNumberOfKeysOnOctave_SingleOctavePiano_ReturnsKeyCount()
        {
            // Arrange
            var instruments = new MusicalInstrument[]
            {
                new Piano("Piano", 1, "Octave", 88)
            };

            // Act
            int max = Program.MaxNumberOfKeysOnOctave(instruments);

            // Assert
            Assert.AreEqual(88, max);
        }


    }
}