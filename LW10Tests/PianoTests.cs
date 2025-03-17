using MusicalInstruments;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LW10Tests
{
    [TestClass]
    public sealed class PianoTests
    {
        [TestMethod]
        public void KeyLayout_WithValidValue()
        {
            var piano = new Piano();
            piano.KeyLayout = "Digital";
            Assert.AreEqual("Digital", piano.KeyLayout);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyLayout_InvalidValue_ThrowsException()
        {
            var piano = new Piano();
            piano.KeyLayout = "InvalidLayout";
        }

        [TestMethod]
        public void KeyLayout_CaseInsensitiveComparison()
        {
            var piano = new Piano();
            piano.KeyLayout = "scale";
            Assert.AreNotEqual("Scale", piano.KeyLayout);
        }

        [TestMethod]
        public void KeyCount_WithValidValue()
        {
            var piano = new Piano();
            piano.KeyCount = 88;
            Assert.AreEqual(88, piano.KeyCount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyCount_LessThan25_ThrowsException()
        {
            var piano = new Piano();
            piano.KeyCount = 20;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void KeyCount_GreaterThan104_ThrowsException()
        {
            var piano = new Piano();
            piano.KeyCount = 110;
        }

        [TestMethod]
        public void Piano_DefaultConstructor_InitializesCorrectly()
        {
            var piano = new Piano();
            Assert.AreEqual("Octave", piano.KeyLayout);
            Assert.AreEqual(88, piano.KeyCount);
            Assert.AreEqual("Unknown Instrument", piano.Name);
            Assert.AreEqual(0, piano.ID.id);
        }

        [TestMethod]
        public void RandomInit_SetsValidLayoutAndKeyCount()
        {
            var piano = new Piano();
            string[] allowedLayouts = { "Octave", "Scale", "Digital" };
            piano.RandomInit();

            Assert.IsTrue(allowedLayouts.Contains(piano.KeyLayout));
            Assert.IsTrue(piano.KeyCount >= 25 && piano.KeyCount <= 104);
        }

        [TestMethod]
        public void Equals_SameProperties_ReturnsTrue()
        {
            var piano1 = new Piano("Grand", 100, "Octave", 88);
            var piano2 = new Piano("grand", 100, "OCTAVE", 88);
            Assert.IsTrue(piano1.Equals(piano2));
        }

        [TestMethod]
        public void Equals_DifferentKeyLayout_ReturnsFalse()
        {
            var piano1 = new Piano("Grand", 100, "Octave", 88);
            var piano2 = new Piano("Grand", 100, "Digital", 88);
            Assert.IsFalse(piano1.Equals(piano2));
        }

        [TestMethod]
        public void GetHashCode_SameProperties_ReturnsSameHashCode()
        {
            var piano1 = new Piano("Grand", 100, "Octave", 88);
            var piano2 = new Piano("grand", 100, "OCTAVE", 88);
            Assert.AreNotEqual(piano1.GetHashCode(), piano2.GetHashCode());
        }

        [TestMethod]
        public void ToString_DefaultFormat_ContainsAllProperties()
        {
            var piano = new Piano("Grand Piano", 200, "Scale", 88);
            string result = piano.ToString();
            Assert.AreEqual($"Id: {piano.ID.id}, name - Grand Piano, key layout: Scale, number of keys: 88", result);
        }

        [TestMethod]
        public void Compare_XHasMoreStrings_ReturnsPositive()
        {
            var guitarX = new Guitar { StringCount = 7 };
            var guitarY = new Guitar { StringCount = 6 };
            var comparer = new SortByStrings();
            int result = comparer.Compare(guitarX, guitarY);
            Assert.IsTrue(result > 0, "Результат должен быть положительным");
        }

        [TestMethod]
        public void Compare_EqualStrings_ReturnsZero()
        {
            var guitarX = new Guitar { StringCount = 6 };
            var guitarY = new Guitar { StringCount = 6 };
            var comparer = new SortByStrings();
            int result = comparer.Compare(guitarX, guitarY);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Compare_XHasFewerStrings_ReturnsNegative()
        {
            var guitarX = new Guitar { StringCount = 5 };
            var guitarY = new Guitar { StringCount = 6 };
            var comparer = new SortByStrings();
            int result = comparer.Compare(guitarX, guitarY);
            Assert.IsTrue(result < 0, "Результат должен быть отрицательным");
        }
    }
}