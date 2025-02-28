using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalInstruments
{
    public class ElectroGuitar : Guitar
    {
        private string powerSource;

        public string PowerSource
        {
            get { return powerSource; }
            set
            {
                string[] validSources = { "Batteries", "Battery", "Fixed Power", "USB" };
                bool isValid = false;

                //cheching if value in valid array
                foreach (string source in validSources)
                {
                    if (source.Equals(value, StringComparison.OrdinalIgnoreCase))
                    {
                        isValid = true;
                        break; 
                    }
                }

                //if value not in array
                if (!isValid)
                {
                    throw new ArgumentException("Invalid power source.");
                }

                // if in
                powerSource = value;
            }


        }

        public ElectroGuitar() : base()
        {
            PowerSource = "Battery";
        }

        public ElectroGuitar(string name, int stringCount, string powerSource) : base(name, stringCount)
        {
            PowerSource = powerSource;
        }

        public void Show()
        {
            Console.WriteLine($"Instrument is: {Name}");
            Console.WriteLine($"Number of strings = {StringCount}");
            Console.WriteLine($"Power source: {PowerSource}");
        }

        public override string ToString()
        {
            return $"{base.ToString()}, power source: {PowerSource}";
        }

        public override void Init()
        {
            base.Init();
            PowerSource = Console.ReadLine();
        }

        public override void RandomInit(Random rnd)
        {
            base.RandomInit(rnd);
            string[] randomSource = { "Batteries", "Battery", "Fixed Power", "USB" };
            PowerSource = randomSource[rnd.Next(randomSource.Length)];
        }

        public override bool Equals(object obj)
        {
            if (!base.Equals(obj)) return false;

            ElectroGuitar other = (ElectroGuitar)obj;
            
            return base.Equals(obj) && string.Equals(PowerSource, other.PowerSource, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ PowerSource.GetHashCode();
        }
    }
}
