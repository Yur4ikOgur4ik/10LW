﻿namespace MusicalInstruments
{
    public class MusicalInstrument
    {
        protected string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException("Name cannot be empty");
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

        public virtual void Show()
        {
            Console.WriteLine($"Instrument is: {Name}");
        }

        public virtual void Init()//Vvod nazvaniya instrumenta
        {
            Name = Console.ReadLine();
        }

        public virtual void RadomInit(Random rnd)
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
