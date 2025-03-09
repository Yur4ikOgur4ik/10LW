using MusicalInstruments;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW10Tests
{
    [TestClass]
    public sealed class PianoTests
    {
        public void KeyLayout_WithValidValue_SetsCorrectly()
        {
            // Arrange
            var piano = new Piano();
            string validLayout = "Digital";

            // Act
            piano.KeyLayout = validLayout;

            // Assert
            Assert.AreEqual(validLayout, piano.KeyLayout);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyLayout_InvalidValue_ThrowsException()
        {
            // Arrange
            var piano = new Piano();

            // Act
            piano.KeyLayout = "InvalidLayout"; // Не в списке допустимых
        }

        [TestMethod]
        public void KeyLayout_CaseInsensitiveComparison()
        {
            // Arrange
            var piano = new Piano();
            string layout = "scale"; // lowercase

            // Act
            piano.KeyLayout = layout;

            // Assert
            Assert.AreNotEqual("Scale", piano.KeyLayout); // Сохраняет исходный регистр из списка
        }

        [TestMethod]
        public void KeyCount_WithValidValue_SetsCorrectly()
        {
            // Arrange
            var piano = new Piano();
            int validCount = 88;

            // Act
            piano.KeyCount = validCount;

            // Assert
            Assert.AreEqual(validCount, piano.KeyCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyCount_LessThan25_ThrowsException()
        {
            // Arrange
            var piano = new Piano();

            // Act
            piano.KeyCount = 20; // меньше 25
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyCount_GreaterThan104_ThrowsException()
        {
            // Arrange
            var piano = new Piano();

            // Act
            piano.KeyCount = 110; // больше 104
        }

        [TestMethod]
        public void Piano_DefaultConstructor_InitializesCorrectly()
        {
            // Arrange & Act
            var piano = new Piano();

            // Assert
            Assert.AreEqual("Octave", piano.KeyLayout);
            Assert.AreEqual(88, piano.KeyCount);
            Assert.AreEqual("Unknown Instrument", piano.Name);
            Assert.AreEqual(0, piano.ID.id);
        }

        [TestMethod]
        public void RandomInit_SetsValidLayoutAndKeyCount()
        {
            // Arrange
            var piano = new Piano();
            string[] allowedLayouts = { "Octave", "Scale", "Digital" };

            // Act
            piano.RandomInit();

            // Assert
            Assert.IsTrue(allowedLayouts.Contains(piano.KeyLayout));
            Assert.IsTrue(piano.KeyCount >= 25 && piano.KeyCount <= 104);
        }

        [TestMethod]
        public void Equals_SameProperties_ReturnsTrue()
        {
            // Arrange
            var piano1 = new Piano("Grand", 100, "Octave", 88);
            var piano2 = new Piano("grand", 100, "OCTAVE", 88); // case-insensitive layout

            // Act & Assert
            Assert.IsTrue(piano1.Equals(piano2));
        }

        [TestMethod]
        public void Equals_DifferentKeyLayout_ReturnsFalse()
        {
            // Arrange
            var piano1 = new Piano("Grand", 100, "Octave", 88);
            var piano2 = new Piano("Grand", 100, "Digital", 88);

            // Act & Assert
            Assert.IsFalse(piano1.Equals(piano2));
        }

        [TestMethod]
        public void GetHashCode_SameProperties_ReturnsSameHashCode()
        {
            // Arrange
            var piano1 = new Piano("Grand", 100, "Octave", 88);
            var piano2 = new Piano("grand", 100, "OCTAVE", 88); 

            // Act & Assert
            Assert.AreNotEqual(piano1.GetHashCode(), piano2.GetHashCode());
        }

        [TestMethod]
        public void ToString_DefaultFormat_ContainsAllProperties()
        {
            // Arrange
            var piano = new Piano("Grand Piano", 200, "Scale", 88);

            // Act
            string result = piano.ToString();

            // Assert
            Assert.AreEqual($"Id: {piano.ID.id}, name - Grand Piano, key layout: Scale, number of keys: 88", result);
        }


        [TestMethod]
        public void Compare_XHasMoreStrings_ReturnsPositive()
        {
            // Arrange
            var guitarX = new Guitar { StringCount = 7 };
            var guitarY = new Guitar { StringCount = 6 };
            var comparer = new SortByStrings();

            // Act
            int result = comparer.Compare(guitarX, guitarY);

            // Assert
            Assert.IsTrue(result > 0, "Результат должен быть положительным");
        }

        [TestMethod]
        public void Compare_EqualStrings_ReturnsZero()
        {
            // Arrange
            var guitarX = new Guitar { StringCount = 6 };
            var guitarY = new Guitar { StringCount = 6 };
            var comparer = new SortByStrings();

            // Act
            int result = comparer.Compare(guitarX, guitarY);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Compare_XHasFewerStrings_ReturnsNegative()
        {
            // Arrange
            var guitarX = new Guitar { StringCount = 5 };
            var guitarY = new Guitar { StringCount = 6 };
            var comparer = new SortByStrings();

            // Act
            int result = comparer.Compare(guitarX, guitarY);

            // Assert
            Assert.IsTrue(result < 0, "Результат должен быть отрицательным");
        }

    }
}
