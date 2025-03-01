
namespace MusicalInstruments
{
    public class MusicalInstrument
    {
        protected string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))//added orWhiteSpace for "   "
                    throw new ArgumentNullException("Name cannot be empty");//chech for probeli
                name = value;
            }
        }

        public MusicalInstrument()//bez parametrov
        {
            Name = "Unknown Instrument";
        }

        public MusicalInstrument(string name)//s parametrom
        {
            Name = name;
        }

        public virtual void ShowVirtual()
        {
            Console.WriteLine($"Instrument name: {Name}");
        }
        public void Show()
        {
            Console.WriteLine($"Instrument is: {Name}");
        }

        public override string ToString()
        {
            return Name;
        }

        public virtual void Init()//Vvod nazvaniya instrumenta
        {
            Name = Console.ReadLine();
        }

        public virtual void RandomInit(Random rnd)
        {
            string[] names = {"Piano", "Guitar", "ElectroGuitar"};
            Name = names[rnd.Next(names.Length)];
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())//chech if null or different types
                return false;

            MusicalInstrument other = (MusicalInstrument)obj;
            return string.Equals(Name, other.Name, StringComparison.OrdinalIgnoreCase);//compare ignoring register (A = a)
        }

        public override int GetHashCode()//pereopredelyaem hash code
        {
            return Name.GetHashCode();
        }

    }
}
