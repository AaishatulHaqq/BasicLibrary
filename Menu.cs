using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicLibrary
{
    public class Menu
    {
        private readonly ILibraryManager libraryManager;

        public Menu()
        {
            libraryManager = new LibraryManager();
        }
        public void PrintMenu()
        {
            Console.WriteLine("Enter 0 to exit");
            Console.WriteLine("Enter 1 to add a book to our library");
            Console.WriteLine("Enter 2 to borrow a book");
            Console.WriteLine("Enter 3 to return a borrowed book");
            Console.WriteLine("Enter 4 to search for a book");
            Console.WriteLine("Enter 5 to view all books in the library");
        }

        public void MyMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                PrintMenu();
                int option;
                
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 0:
                            exit = true;
                            break;
                        case 1:
                            Console.Write("Enter book title: ");
                            var title = Console.ReadLine()!;
                            Console.Write("Enter author's name: ");
                            var authorName = Console.ReadLine()!;
                            Console.Write("Enter ISSN: ");
                            var issn = Console.ReadLine()!;
                            var userCategoryInt = Utility.SelectEnum("Select user:\n1 Author\n2 Borrower\n Returner\nReader: ", 1, 2);
                            var userCategory = (UserCategory) userCategoryInt;
                            var bookGenreInt = Utility.SelectEnum("Select genre:\n1 Fiction\n2 Non-fiction\n Thriller\nBiography\nAutobiography: ", 1, 2);
                            var bookGenre = (BookGenre) bookGenreInt;
                            libraryManager.AddBook(title, authorName, issn, userCategory, bookGenre);
                            break;
                        case 2:
                            Console.Write("Enter the title of the book to borrow: ");
                            var bookIssn = Console.ReadLine()!;
                            libraryManager.BorrowBook(bookIssn);
                            break;
                        case 3:
                            Console.Write("Enter the title of the book you want to return: ");
                            var bookToReturn = Console.ReadLine()!;
                            Console.WriteLine("Enter Author's name: ");
                            var authorOfBookToReturn = Console.ReadLine()!;
                            Console.WriteLine("Enter issn: ");
                            var issnOfBookToReturn = Console.ReadLine()!;
                            libraryManager.ReturnBook(bookToReturn, authorOfBookToReturn, issnOfBookToReturn);
                            break;
                        case 4:
                            Console.Write("Enter phone number of contact to search:");
                            var search = Console.ReadLine()!;
                            libraryManager.GetBook(search);
                            break;
                        case 5:
                            libraryManager.GetAllBooks();
                            break;
                        default:
                            Console.WriteLine("Unknown operation!");
                            break;
                    }

                    if (!exit)
                    {
                        HoldScreen();
                    }
                }
            }
        }

        private void HoldScreen()
        {
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }    
}