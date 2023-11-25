using ConsoleTable;
using Humanizer;
using System.Collections.Generic;


namespace BasicLibrary
{
    public class LibraryManager : ILibraryManager
    {
        public static List<Library> Library = new();
        public void AddBook(string title, string nameOfAuthor, string issn, UserCategory userCategory, BookGenre bookGenre)
        {
            int id = Library.Count > 0 ? Library.Count + 1 : 1;

            var doesBookExist = DoesBookExist(issn);

            if (DoesBookExist(issn))
            {
                Console.WriteLine("A book with this author's name already exists in our library!");
                return;
            }

            var library = new Library
            {
                Id = id,
                Title = title,
                NameOfAuthor = nameOfAuthor,
                BookGenre = bookGenre,
                UserCategory = userCategory,
                AddedOn = DateTime.Now
            };

            Library.Add(library);
            Console.WriteLine("Book added successfully.");
        }

        public void BorrowBook(string issn)
        {
            var library = FindBook(issn);

            if (library is null)
            {
                Console.WriteLine("Unable to borrow you this book as it does not exist!");
                return;
            }

            Library.Remove(library!);
        }

        public Library? FindBook(string issn)
        {
            return Library.Find(c => c.Issn == issn);
        }

        public void GetBook(string issn)
        {
            var library = FindBook(issn);
            
            if (library is null)
            {
                Console.WriteLine($"Book with {issn} not found");
            }
            else
            {
                Print(library);
            }
        }

        public void GetAllBooks()
        {
            int bookCount = Library.Count;

            Console.WriteLine("You have " + "book".ToQuantity(bookCount));

            if (bookCount == 0)
            {
                Console.WriteLine("There is no book added to the library yet.");
                return;
            }

            var table = new Table();
            
            foreach (var book in Library)
            {
                table.AddColumn("Title", "Author's Name", "Genre", "Issn", "Date Added");
                table.AddRow(book.Title, book.NameOfAuthor,((BookGenre) book.BookGenre).Humanize(), book.Issn, book.AddedOn.Humanize());
            }

            Console.WriteLine(table);
        }

        public void ReturnBook(string title, string nameOfAuthor, string issn)
        {
            var book = FindBook(issn);

            if (book is null)
            {
                Console.WriteLine("Contact does not exist!");
                return;
            }

            book.Title = title;
            book.NameOfAuthor = nameOfAuthor;
            book.Issn = issn;
            Console.WriteLine("Book returned successfully.");
        }

        private void Print(Library library)
        {
            Console.WriteLine($"Name: {library!.Title}\nName of Author: {library!.NameOfAuthor}\nIssn: {library!.Issn}");
        }

        private bool DoesBookExist(string issn)
        {
            return Library.Any(c => c.Issn == issn);
        }
    }
}