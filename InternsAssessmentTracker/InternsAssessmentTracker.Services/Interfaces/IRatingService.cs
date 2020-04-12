using InternsAssessmentTracker.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Services.Interfaces
{
    public interface IRatingService
    {
        bool AddInternRating(InternRatingRequest request);
        IEnumerable<InternRatingResponse> GetInternRatings(InternRatingRequest request);
    }
}
