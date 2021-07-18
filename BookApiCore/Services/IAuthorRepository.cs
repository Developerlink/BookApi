using BookApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiCore.Services
{
    public interface IAuthorRepository
    {
        bool AuthorExists(int authorId);
        ICollection<Author> GetAuthors();
        Author GetAuthor(int authorId);
        ICollection<Author> GetAuthorsOfABook(int bookId);
        ICollection<Book> GetBooksOfAnAuthor(int authorId);
    }
}
