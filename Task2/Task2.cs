using System.Text;

internal class Program
{
    class Book
    {
        private string title;
        private double price;
        private string author;
        
        public Book(string title, double price, string author)
        {
            this.title = title;
            this.price = price;
            this.author = author;
        }
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                if (value[0] >= 48 && value[0] <= 57)
                {
                    throw new ArgumentException("The name should be started from letter");
                }

                author = value;
            }
        }
        public virtual double Price
        {
            get { return price; }
            set 
            {
                if (value <=0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                
                price = value; 
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set 
            {
                if (value.Length<3)
                {
                    throw new ArgumentException("Title not valid");
                }
                
                title = value; 
            }
        }
    }
    class GoldenEditionBook : Book
    {
        public GoldenEditionBook (string title, double price, string author) : base (title, price, author)
        {
            this.Price = price;
        }
        public override double Price
        {
            get
            {
                return base.Price * 1.3;
            }
        }
    }
    static void Main()
    {
        try
        {
            Console.WriteLine("Enter a author");
            string author = Console.ReadLine();
            Console.WriteLine("Enter a title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter a price");
            double price = double.Parse(Console.ReadLine());

            Book book = new Book(title, price, author);
            GoldenEditionBook goldenEditionBook = new GoldenEditionBook(title, price, author);

            Console.WriteLine("\nType: Book\n" + "Author: " + book.Author + "\nTitle: " + book.Title + "\nPrice: " + book.Price);
            Console.WriteLine("\nType: GoldenEditionBook\n" + "Author: " + goldenEditionBook.Author + "\nTitle: " + goldenEditionBook.Title + "\nPrice: " + goldenEditionBook.Price);
        }

        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }

        
    }
}