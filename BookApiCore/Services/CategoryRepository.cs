using BookApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiCore.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookDbContext _categoryDbContext;

        public CategoryRepository(BookDbContext categoryDbContext)
        {
            _categoryDbContext = categoryDbContext;
        }

        public bool CategoryExists(int categoryId)
        {
            return _categoryDbContext.Categories.Any(c => c.Id == categoryId);
        }

        public ICollection<Category> GetCategories()
        {
            return _categoryDbContext.Categories.OrderBy(c => c.Name).ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryDbContext.Categories.Where(c => c.Id == categoryId).FirstOrDefault();
        }

        public ICollection<Category> GetCategoriesForABook(int bookId)
        {
            return _categoryDbContext.BookCategories.Where(bc => bc.BookId == bookId).Select(bc => bc.Category).OrderBy(c => c.Name).ToList();
        }

        public ICollection<Book> GetBooksForACategory(int categoryId)
        {
            return _categoryDbContext.BookCategories.Where(bc => bc.CategoryId == categoryId).Select(bc => bc.Book).OrderBy(b => b.Title).ToList();
        }

        public bool IsDuplicateCategoryName(int categoryId, string categoryName)
        {
            var category = _categoryDbContext.Categories.Where(c => c.Name.Trim().ToUpper() == categoryName.Trim().ToUpper() && c.Id != categoryId).FirstOrDefault();

            return category != null;
        }

        public bool CreateCategory(Category category)
        {
            _categoryDbContext.AddAsync(category);
            return Save();
        }

        public bool UpdateCategory(Category category)
        {
            _categoryDbContext.Update(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _categoryDbContext.Remove(category);
            return Save();
        }

        public bool Save()
        {
            var rowsChanged = _categoryDbContext.SaveChanges();
            return rowsChanged >= 0;
        }
    }
}
