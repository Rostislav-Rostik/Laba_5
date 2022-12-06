using System.Xml.Linq;

internal class Program
{
    class Human
    {
        private string name;
        private string secondname;

        public Human (string name, string secondname)
        {
            this.Name = name;
            this.Secondname = secondname;
        }
        public virtual string Name
        {
            get { return name; }
            set 
            { 
                if (value.Length < 3)
                {
                    throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName!");
                }
                if (value[0] == 97 && value[0] == 122)
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName!");
                }
                name = value; 
            }
        }
        public virtual string Secondname
        {
            get { return secondname; }
            set
            {
                if (value.Length < 2)
                {
                    throw new ArgumentException("Expected length at least 3 symbols! Argument: secondName!");
                }
                else if (value[0] == 97 && value[0] == 122)
                {
                    throw new ArgumentException("Expected upper case letter! Argument: secondName!");
                }
                secondname = value;
            }
        }
    }

    class Worker : Human
    {
        private double weeksalary;
        private int hours;
        private double dayssalary;

        public Worker(string name, string secondname, double weeksalary, int hours) : base(name, secondname)
        { 
            this.WeekSalary = weeksalary;
            this.Hours = hours;
        }
        
        public double WeekSalary
        {
            get { return weeksalary; }
            set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                weeksalary = value;
            }
        }
        public int Hours
        {
            get { return hours; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                hours = value;
            }
        }
        
    }

    class Student : Human
    {
        private string facultynumber;
        public Student (string name, string secondname, string facultynumber) : base (name, secondname)
        { this.FacultyNumber = facultynumber; }
        public virtual string FacultyNumber
        {
            get { return facultynumber; }
            set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number");
                }
                facultynumber = value;
            }
        }
    }
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter a name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter a last name: ");
            string secondname = Console.ReadLine();
            Console.WriteLine("Enter a faculty number: ");
            string facultynumber = Console.ReadLine();

            Student student = new Student(name, secondname,facultynumber);
            

            Console.WriteLine("First Name: " + student.Name + "\nSecond Name: " + student.Secondname + "\nFaculty number: " + student.FacultyNumber);

           
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }

        try
        {
            Console.WriteLine("\n\nEnter a name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter a last name: ");
            string secondname = Console.ReadLine();
            Console.WriteLine("Enter a week salary: ");
            double weeksalary = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter a hours per day: ");
            int hours = int.Parse(Console.ReadLine());

            Worker worker = new Worker(name, secondname, weeksalary, hours);

            double daysalary = weeksalary / 7 / hours;

            Console.WriteLine("\n\nFirst Name: " + worker.Name + "\nSecond Name: " + worker.Secondname + "\nWeek Salary: " + worker.WeekSalary + "\nHours per day: " + worker.Hours + "\nDay salary: " + Math.Round(daysalary, 2));
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}