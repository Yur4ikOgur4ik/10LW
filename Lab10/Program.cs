using System.Runtime.Serialization.Formatters;
using MusicalInstruments;
using StudentLibrary;
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

            int defInstrumentCount = 0;
            int guitarCount = 0;
            int electroGuitarCount = 0;
            int pianoCount = 0;
            int studentCount = 0;


            for (int i = 0; i < StudentsAndInstruments.Length-1; i++)
            {
                switch (rnd.Next(5))
                {
                    case 0:
                        StudentsAndInstruments[i] = new MusicalInstrument();
                        defInstrumentCount++;
                        break;
                    case 1:
                        StudentsAndInstruments[i] = new Guitar();
                        guitarCount++;
                        break;
                    case 2:
                        StudentsAndInstruments[i] = new ElectroGuitar();
                        electroGuitarCount++;
                        break;
                    case 3:
                        StudentsAndInstruments[i] = new Piano();
                        pianoCount++;
                        break;
                    case 4:
                        StudentsAndInstruments[i] = new Student();
                        studentCount++;
                        break;
                }
            }
            int objNum = 0;
            foreach (var obj in StudentsAndInstruments)
            {
                if (obj != null)
                {
                    
                    obj.RandomInit();

                }

            }
            Console.WriteLine("Enter last element of array");
            Console.WriteLine("1 - default instrument, 2 - guitar, 3 - electro-guitar, 4 - piano, 5 - student");
            int choice;
            bool isTrue = false;
            while (!isTrue)
            {
                choice = ValidInput.GetInt();
                if (choice < 1 || choice > 5)
                    Console.WriteLine("Enter a number between 1 and 5");
                else
                {
                    switch (choice) 
                    {
                        case 1:
                            StudentsAndInstruments[arrLen-1] = new MusicalInstrument();
                            Console.WriteLine("Enter name");
                            StudentsAndInstruments[arrLen-1].Init();
                            defInstrumentCount++;
                            isTrue = true;
                            break;
                        case 2:
                            StudentsAndInstruments[arrLen - 1] = new Guitar();
                            Console.WriteLine("Enter name, and then number of strings");
                            StudentsAndInstruments[arrLen - 1].Init();
                            guitarCount++;
                            isTrue = true;
                            break;
                        case 3:
                            StudentsAndInstruments[arrLen - 1] = new ElectroGuitar();
                            Console.WriteLine("Enter name, and then number of strings, then power source");
                            StudentsAndInstruments[arrLen - 1].Init();
                            electroGuitarCount++;
                            isTrue = true;
                            break;
                        case 4:
                            StudentsAndInstruments[arrLen - 1] = new Piano();
                            Console.WriteLine("Enter name, then key layout, and then number of keys");
                            StudentsAndInstruments[arrLen - 1].Init();
                            pianoCount++;
                            isTrue = true;
                            break;
                        case 5:
                            StudentsAndInstruments[arrLen - 1] = new Student();
                            Console.WriteLine("Enter name, then age, and then gpa");
                            StudentsAndInstruments[arrLen - 1].Init();
                            pianoCount++;
                            isTrue = true;
                            break;

                    }
                }
            }

            
            foreach (var obj  in StudentsAndInstruments)
            {
                if (obj != null)
                {

                    objNum++;
                    Console.WriteLine(objNum.ToString() + ") " + obj.ToString());
                }
            }

            Console.WriteLine($"Number of Default Instruments: {defInstrumentCount}");
            Console.WriteLine($"Number of Guitars: {guitarCount}");
            Console.WriteLine($"Number of Electric Guitars: {electroGuitarCount}");
            Console.WriteLine($"Number of Pianos: {pianoCount}");
            Console.WriteLine($"Number of Students: {studentCount}");


            Console.WriteLine("Sorted array of instruments: ");
            Array.Sort(instruments);
            foreach (var instr in instruments)
                { Console.WriteLine(instr.ToString()); }
            
            MusicalInstrument itemToSearch = new MusicalInstrument();
            itemToSearch.RandomInit();
            int index = Array.BinarySearch(instruments, itemToSearch);
            Console.WriteLine($"{itemToSearch.ToString()} found at index {index}");

            Guitar[] guitarArray = new Guitar[8];
            for (int i = 0; i < guitarArray.Length; i++)
            {
                if (i % 2 == 0)
                {
                    guitarArray[i] = new Guitar();
                    guitarArray[i].RandomInit();
                }
                else 
                { 
                    guitarArray[i] = new ElectroGuitar();
                    guitarArray[i].RandomInit();
                    
                }
            }

            Console.WriteLine("Guitars before sorting: ");
            foreach(var item in guitarArray) { Console.WriteLine(item.ToString()); }
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Array of guitars sorted by num of strings: ");
            Array.Sort(guitarArray, new SortByStrings());
            foreach (var item in guitarArray)
            {
                Console.WriteLine(item.ToString());
            }
            Guitar guitarToSearch = new Guitar();
            Console.WriteLine("EnterGuitarToSearch");
            guitarToSearch.Init();
            index = Array.BinarySearch(guitarArray, guitarToSearch);
            Console.WriteLine("Index of desired guitar: ");
            Console.WriteLine(index);

            Console.Clear();

            MusicalInstrument ins = new MusicalInstrument("gagagag", 10);
            MusicalInstrument instrClone = (MusicalInstrument)ins.Clone();
            MusicalInstrument instrCopy = (MusicalInstrument)ins.ShallowCopy();
            Console.WriteLine(ins.ToString());
            Console.WriteLine(instrClone.ToString());
            Console.WriteLine(instrCopy.ToString());
            ins.ID.id = 100;
            ins.Name = "Aboba";
            Console.WriteLine(ins.ToString());
            Console.WriteLine(instrClone.ToString());
            Console.WriteLine(instrCopy.ToString());
        }
    }
}
