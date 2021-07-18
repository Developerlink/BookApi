using BookApiCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApiCore.Services
{
    public interface IReviewerRepository
    {
        bool ReviewerExists(int reviewerId);
        ICollection<Reviewer> GetReviewers();
        Reviewer GetReviewer(int reviewerId);
        ICollection<Review> GetReviewsByAReviewer(int reviewerId);
        Reviewer GetReviewerOfAReview(int reviewId);
    }
}
