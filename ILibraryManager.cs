using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicLibrary
{
    public interface ILibraryManager
    {
        void AddBook(string title, string nameOfAuthor, string issn, UserCategory userCategory, BookGenre bookGenre);
        Library? FindBook(string issn);
        void ReturnBook(string title, string nameOfAuthor, string issn);
        void GetAllBooks();
        void GetBook(string issn);
        void BorrowBook(string issn);
    }
}