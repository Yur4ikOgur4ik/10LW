using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MusicalInstruments
{
    public class Guitar : MusicalInstrument
    {
        private int stringCount;//kol-vo strun

        public int StringCount
        {
            get { return stringCount; }
            set
            {
                if (value < 3 || value > 20)
                    throw new ArgumentException("Number of strigs must be between 3 and 20");
                stringCount = value;
            }
        }

        public Guitar() : base()
        {
            StringCount = 6;
        }

        public Guitar(string name, int stringCount) : base(name)
        {
            StringCount = stringCount;
        }

        public override void ShowVirtual()
        {
            base.ShowVirtual();
            Console.WriteLine($"Number of strings: {StringCount}");
        }
        public  void Show()
        {
            Console.WriteLine($"Instrument is: {Name}");
            Console.WriteLine($"Number of strings: {StringCount}");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {StringCount}";
        }

        public override void Init()
        {
            base.Init();
            stringCount = ValidInput.GetInt();
        }

        public override void RandomInit(Random rnd)
        {
            string[] names = { "Balalaika", "Bass guitar", "Acoustic guitar", "Classic guitar"};
            Name = names[rnd.Next(names.Length)];
            StringCount = rnd.Next(3, 21);
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;

            Guitar other = (Guitar)obj;
            return stringCount == other.StringCount;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ StringCount.GetHashCode();
        }
    }
}
