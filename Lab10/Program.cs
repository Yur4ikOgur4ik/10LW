using System.Runtime.Serialization.Formatters;
using MusicalInstruments;
using Student;
namespace Lab10
{
    internal class Program
    {

        public static double AverageNumberOfStrings(MusicalInstrument[] instruments)
        {
            int count = 0;
            int numberOfStrings = 0;
            foreach (MusicalInstrument instr in instruments)
            {
                if (instr is Guitar guitar)//rassmotr kak v seredine ierarxii vedut => Guitar != EGuitar
                {
                    numberOfStrings += guitar.StringCount;
                    count++;
                }
            }

            if (count != 0)
                return numberOfStrings / count;
            else
                return -1;

        }

        public static int NumberOfStringInElectroGuitarsWithFixedPower(MusicalInstrument[] instruments)
        {
            int numberOfStrings = 0;

            foreach (MusicalInstrument instr in instruments)
            {
                ElectroGuitar eGuitar = instr as ElectroGuitar;
                if (eGuitar != null) 
                {
                    if (eGuitar.PowerSource.Equals("Fixed power", StringComparison.OrdinalIgnoreCase))
                        numberOfStrings += eGuitar.StringCount;
                }
            }
            if (numberOfStrings != 0)
                return numberOfStrings;
            else return -1;
        }

        public static int MaxNumberOfKeysOnOctave(MusicalInstrument[] instruments)
        {
            
            int maxNumberOfKeys = -1;

            foreach (MusicalInstrument instr in instruments)
            {
                if (instr.GetType() == typeof(Piano))
                {
                    Piano piano = (Piano)instr;
                    if (piano.KeyLayout.Equals("Octave", StringComparison.OrdinalIgnoreCase))
                    {
                        maxNumberOfKeys = Math.Max(maxNumberOfKeys, piano.KeyCount);//if max<p.keys
                    }
                }
            }
            return maxNumberOfKeys;
        }

        static void Main(string[] args)
        {
            MusicalInstrument[] instruments = new MusicalInstrument[20];
            Random rnd = new Random();
            

            for (int i = 0; i <instruments.Length; i++)//initializing array of random stuff
            {
                switch (rnd.Next(4))
                {
                    case 0:
                        instruments[i] = new MusicalInstrument();
                        break;
                    case 1:
                        instruments[i] = new Guitar();
                        break;
                    case 2:
                        instruments[i] = new ElectroGuitar();
                        break;
                    case 3:
                        instruments[i] = new Piano();
                        break;

                }
            }

            foreach (var instr in instruments) //making stuff random
            { 
                instr.RandomInit();
            }

            //vivod from array
            foreach (var instr in instruments)
            {
                Console.WriteLine("Output from show (non-virtual)");
                instr.Show();
                Console.WriteLine();
                Console.WriteLine("Output from ToString (virtual)");
                instr.ShowVirtual();
                Console.WriteLine("---------------------------------------------");
            }


            //1 zapros
            if (AverageNumberOfStrings(instruments) < 0)
                Console.WriteLine("Array has no guitars");
            Console.WriteLine($"Average number of string is {AverageNumberOfStrings(instruments)}");
            
            //2 zaproa
            if (NumberOfStringInElectroGuitarsWithFixedPower(instruments) < 0)
                Console.WriteLine("There is no electroguitars with fixed source");
            Console.WriteLine($"Number of strings in e-guitars with fixed power: {NumberOfStringInElectroGuitarsWithFixedPower(instruments)}");

            //2 zapros
            if (MaxNumberOfKeysOnOctave(instruments) < 0)
                Console.WriteLine($"There were no pianos with octave keyboard layout");
            Console.WriteLine($"Max number of keys on octave keyboard is {MaxNumberOfKeysOnOctave(instruments)}");



            //Start of part 3
            int arrLen = 20;
            IInit[] StudentsAndInstruments = new IInit[arrLen];

            for (int i = 0; i < StudentsAndInstruments.Length; i++)
            {
                switch (rnd.Next(5))
                {
                    case 0:
                        StudentsAndInstruments[i] = new MusicalInstrument();
                        break;
                    case 1:
                        StudentsAndInstruments[i] = new Guitar();
                        break;
                    case 2:
                        StudentsAndInstruments[i] = new ElectroGuitar();
                        break;
                    case 3:
                        StudentsAndInstruments[i] = new Piano();
                        break;
                    //case 4:
                    //    StudentsAndInstruments[i] = new Student();
                }
            }
        }
    }
}
