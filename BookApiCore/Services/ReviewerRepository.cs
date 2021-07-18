using BookApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiCore.Services
{
    public class ReviewerRepository : IReviewerRepository
    {
        private BookDbContext _reviewerDbContext;

        public ReviewerRepository(BookDbContext reviewerDbContext)
        {
            _reviewerDbContext = reviewerDbContext;
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return _reviewerDbContext.Reviewers.Where(r => r.Id == reviewerId).FirstOrDefault();
        }

        public Reviewer GetReviewerOfAReview(int reviewId)
        {
            return _reviewerDbContext.Reviews.Where(r => r.Id == reviewId).Select(r => r.Reviewer).FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _reviewerDbContext.Reviewers.OrderBy(r => r.LastName).ToList();
        }

        public ICollection<Review> GetReviewsByAReviewer(int reviewerId)
        {
            return _reviewerDbContext.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
            // This seems to work too!
            //return _reviewerDbContext.Reviewers.Where(r => r.Id == reviewerId).Select(r => r.Reviews).FirstOrDefault();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _reviewerDbContext.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
