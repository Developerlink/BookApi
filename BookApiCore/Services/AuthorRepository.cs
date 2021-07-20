using BookApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiCore.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private BookDbContext _bookDbContext;

        public AuthorRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }

        public bool AuthorExists(int authorId)
        {
            return _bookDbContext.Authors.Any(a => a.Id == authorId);
        }

        public bool CreateAuthor(Author author)
        {
            _bookDbContext.Add(author);
            return Save();
        }

        public bool DeleteAuthor(Author author)
        {
            _bookDbContext.Remove(author);
            return Save();
        }

        public Author GetAuthor(int authorId)
        {
            return _bookDbContext.Authors.Where(a => a.Id == authorId).FirstOrDefault();
        }

        public ICollection<Author> GetAuthors()
        {
            return _bookDbContext.Authors.OrderBy(a => a.LastName).ToList();
        }

        public ICollection<Author> GetAuthorsOfABook(int bookId)
        {
            return _bookDbContext.BookAuthors.Where(ba => ba.BookId == bookId).Select(ba => ba.Author).ToList();
        }

        public ICollection<Book> GetBooksOfAnAuthor(int authorId)
        {
            return _bookDbContext.BookAuthors.Where(ba => ba.AuthorId == authorId).Select(ba => ba.Book).ToList();
        }

        public bool Save()
        {
            var rowsChanged = _bookDbContext.SaveChanges();
            return rowsChanged >= 0;
        }

        public bool UpdateAuthor(Author author)
        {
            _bookDbContext.Update(author);
            return Save();
        }
    }
}
