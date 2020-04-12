using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Models.Models
{
    public class InternRatingRequest
    {
        public int InternId { get; set; }

        public List<TechRating> Rating { get; set; }
    }
}
