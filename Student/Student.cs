using MusicalInstruments;//dlya proverki
namespace StudentLibrary
{
    public class Student : IInit
    {
        // Закрытые атрибуты
        private string name;
        private int age;
        private double gpa;
        static int count = 0;
        Random rnd = new Random();

        // Свойства
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
    
        

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentException("Student's age must be between 0 and 100");
                age = value;
            }
        }

        public double GPA
        {
            get { return gpa; }
            set
            {
                if (value < 0 || value > 10)
                    throw new ArgumentException("GPA must be between 0 and 10");
                gpa = value;
            }
        }

        public Student()
        {
            name = "NameNotSet";
            age = 0;
            gpa = 0;
            count++;
        }
        public Student(string name, int age, double gpa)
        {
            this.name = name;
            this.age = age;
            this.gpa = gpa;
            count++;
        }

        public Student(Student other)
        {
            this.name = other.Name;
            this.age = other.Age;
            this.gpa = other.gpa;
            count++;
        }

        public void Init()
        {
            Name = Console.ReadLine();

            try
            {
                Age = ValidInput.GetInt();
            }
            catch (Exception ex) when (ex is ArgumentException)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Because of error, making a standart age (18)");
                Age = 18;
            }

            try
            {
                GPA = ValidInput.GetDouble();
            }
            catch (Exception ex) when (ex is ArgumentException)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Because of error, making a standart gpa (8)");
                GPA = 8;
            }

            
        }

        public void RandomInit()
        {
            string[] randomNames = {"Alexey", "Stepan", "Danil", "Grigory", "Angelina", "Dasha", "Masha", "Natalia", "Misha", "Sasha", "Evgeniy", "M. A. Plaksin", "Obamna" };
            Name = randomNames[rnd.Next(randomNames.Length)];
            Age = rnd.Next(0, 70);
            GPA = Math.Round(rnd.NextDouble() * 10, 1);  
        }

        public override string ToString()
        {
            return $"Name - {Name}, age - {Age}, GPA - {GPA}";
        }
        public static int GetCount => count;
        public static void ResetCount()
        {
            count = 0;
        }

        public void Show()
        {
            Console.WriteLine($"Student's name - {name}, age - {age}, gpa - {gpa}");
        }

        public static int AgeComparison(Student s1, Student s2)
        {
            if (s1.age > s2.age)
                return 1;
            if (s1.age == s2.age)
                return 0;
            if (s1.age < s2.age)
                return -1;
            return -2;
        }
        public int GpaComparison(Student other)
        {
            if (this.gpa == other.gpa) return 0;
            if (this.gpa > other.gpa) return 1;
            if (this.gpa < other.gpa) return -1;
            return -2;
        }


        //~ приведение имени студента к формату: первая буква заглавная, остальные строчные;
        public static Student operator ~(Student student)
        {
            student.Name = char.ToUpper(student.Name[0]) + student.Name.Substring(1).ToLower();
            return student;
        }


        //++ увеличить возраст студента на 1.
        public static Student operator ++(Student student)
        {
            student.age++;
            return student;
        }

        //int (явная) – результатом является номер курса, на котором обучается студент 
        public static explicit operator int(Student student)
        {
            if ((student.age > 22) || (student.age < 18))
                return -1;
            else return (student.age - 17);
        }

        //bool (неявная) – результатом является true, если gpa< 6 
        public static implicit operator bool(Student student)
        {
            return (student.gpa < 6);
        }

        //% Student s, string newName – результатом является новый студент, у которого возраст и gpa идентичен s, но имя другое;
        public static Student operator %(Student student, string newName)
        {
            return new Student(newName, student.age, student.gpa);
        }

        //- Student s, double d – (правосторонняя операция) результатом является тот же студент, но с уменьшенным gpa на заданное число d. Учитывать, что gpa не может быть меньше 0.
        public static Student operator -(Student student, double decrement)
        {
            student.gpa = Math.Max(0, student.gpa - decrement);
            return student;
        }


    }
}
