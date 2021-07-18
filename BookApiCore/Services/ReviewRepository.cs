using BookApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiCore.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private BookDbContext _bookDbContext;

        public ReviewRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }
        public Book GetBookOfAReview(int reviewId)
        {
            return _bookDbContext.Reviews.Where(r => r.Id == reviewId).Select(r => r.Book).FirstOrDefault();
        }

        public Review GetReview(int reviewId)
        {
            return _bookDbContext.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviewsOfABook(int bookId)
        {
            return _bookDbContext.Reviews.Where(r => r.Book.Id == bookId).ToList();
        }

        public ICollection<Review> GetReviews()
        {
            return _bookDbContext.Reviews.OrderByDescending(r => r.Rating).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _bookDbContext.Reviews.Any(r => r.Id == reviewId);
        }
    }
}
