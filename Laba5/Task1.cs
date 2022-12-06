using System.Text;
using System.Transactions;
using System.Xml.Linq;

internal class Task1
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public virtual string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Name's length should not be less than 3 symbols!!");
                }
                else
                {
                    name = value;
                }
            }
        }
        public virtual int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be positive!!");
                }
                
                else
                {
                    age = value;
                }
            }
        }

       
    }
    class Child : Person
    {
        public Child (string name, int age): base(name,age)
        {this.Age = age;}
        public override int Age {
            get
            {
                return base.Age;
            }
            set
            {
                if (base.Age > 15)
                {
                    throw new ArgumentException("Child's age must be less than 15");
                }
                base.Age = value;
            }
        }
    }
    static void Main()
    {
        string name = Console.ReadLine();
        int age = int.Parse(Console.ReadLine());

        try
        {
            Child child = new Child(name, age);
            Console.WriteLine("Name: " + child.Name + "\nAge: " + child.Age);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
}




