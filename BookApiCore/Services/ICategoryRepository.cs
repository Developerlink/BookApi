using BookApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiCore.Services
{
    public interface ICategoryRepository
    {
        bool CategoryExists(int categoryId);
        ICollection<Category> GetCategories();
        Category GetCategory(int categoryId);
        ICollection<Category> GetCategoriesForABook(int bookId);
        ICollection<Book> GetBooksForACategory(int categoryId);
    }
}
