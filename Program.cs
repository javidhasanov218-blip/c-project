namespace Library_Management_System
{
    class Program
    {
        static List<Book> books = new List<Book>();

        class Book
        {
            public string Name { get; set; }

            public int Quantity { get; set; }

            public string Author { get; set; }

            public Book(string name, int quantity, string author)
            {
                Name = name;
                Quantity = quantity;
                Author = author;
            }
        }

        class Library
        {
            static void Main(string[] args)
            {
                bool running = true;
                while (running)
                {
                    Console.WriteLine("Library Management System");
                    Console.WriteLine("1. Add Book");
                    Console.WriteLine("2. View Books");
                    Console.WriteLine("3. Borrow Book");
                    Console.WriteLine("4. Return Book");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine() ?? string.Empty;

                    switch (choice)
                    {
                        case "1":
                            Program.AddBook();
                            break;
                        case "2":
                            Program.ViewBooks();
                            break;
                        case "3":
                            Program.BorrowBook();
                            break;
                        case "4":
                            Program.ReturnBook();
                            break;
                        case "5":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }




        }




        static void AddBook()
        {
            Console.Write("Enter book name: ");
            string name = Console.ReadLine() ?? string.Empty;
            Console.Write("Enter book quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity))
            {
                Console.WriteLine("Please enter a valid quantity.");
                return;
            }
            Console.Write("Enter book author: ");
            string author = Console.ReadLine() ?? string.Empty;

            if (quantity < 0)
            {
                Console.WriteLine("Quantity cannot be negative. Please try again.");
                return;
            }
            else
            {
                Book newBook = new Book(name, quantity, author);
                books.Add(newBook);
                Console.WriteLine("Book added successfully.");
            }


        }

        static void ViewBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
            }
            else
            {
                Console.WriteLine("Available Books:");
                foreach (Book book in books)
                {
                    Console.WriteLine($"Name: {book.Name}, Quantity: {book.Quantity}, Author: {book.Author}");
                }
            }


        }
        static void BorrowBook()
        {
            Console.WriteLine("Enter book name to borrow: ");
            string name = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Book name cannot be empty. Please try again.");
                return;
            }
            else if (books.Count == 0)
            {
                Console.WriteLine("No books available to borrow.");
                return;
            }
            else
            {
                Book? bookToBorrow = FindBookByName(name);
                if (bookToBorrow == null)
                {
                    Console.WriteLine("Book not found.");
                }
                else if (bookToBorrow.Quantity <= 0)
                {
                    Console.WriteLine("Book is currently unavailable.");
                }
                else
                {
                    bookToBorrow.Quantity--;
                    Console.WriteLine($"You have borrowed '{bookToBorrow.Name}'.");
                }
            }
        }
    static Book? FindBookByName(string name)
        {
           foreach (Book book in books)
            {
               if (book.Name.ToLower() == name.ToLower())
                {
                    return book;
                }
            }
            return null;
        }
        static void ReturnBook()
        {
            Console.WriteLine("Enter book name to return: ");
            string name = Console.ReadLine() ?? string.Empty;
            Book? book = FindBookByName(name);
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Book name cannot be empty. Please try again.");
                return;
            }
            else
            {

                if (book == null)
                {
                    Console.WriteLine("Book not found.");
                }
                else
                {
                    book.Quantity++;
                    Console.WriteLine($"You have returned '{book.Name}'.");
                }
            }
        }


    }
}
