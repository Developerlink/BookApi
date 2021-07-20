using BookApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiCore.Services
{
    public interface IBookRepository
    {
        bool BookExists(int bookId);
        bool BookExists(string bookIsbn);
        bool IsDuplicateIsbn(int bookId, string  bookIsbn);
        ICollection<Book> GetBooks();
        Book GetBook(int bookId);
        Book GetBook(string bookIsbn);
        decimal GetBookRating(int bookId);

        bool CreateBook(List<int> authorIds, List<int> categoryIds, Book book);
        bool UpdateBook(List<int> authorIds, List<int> categoryIds, Book book);
        bool DeleteBook(Book book);
        bool Save();
    }
}
