using BookApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiCore.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BookDbContext _bookDbContext;

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

        public bool CreateReview(Review review)
        {
            //var reviewToUpdate = _bookDbContext.Reviews.FirstOrDefault(r => r.Id == review.Id);
            _bookDbContext.Reviews.Add(review);
            return Save();
        }

        public bool UpdateReview(Review review)
        {
            _bookDbContext.Update(review);
            return Save();
        }

        public bool DeleteReview(Review review)
        {
            _bookDbContext.Remove(review);
            return Save();
        }

        public bool Save()
        {
            var rowsChanged = _bookDbContext.SaveChanges();
            return rowsChanged >= 0;
        }

        public bool DeleteReviews(ICollection<Review> reviews)
        {
            _bookDbContext.RemoveRange(reviews); 
            return Save();
        }
    }
}
