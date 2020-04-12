using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Models.Models
{
    public class InternRatingResponse
    {
        public int InternId { get; set; }
        public string InternName { get; set; }

        public string ProjectName { get; set; }

        public string TechnologyName { get; set; }
        public string TechnologyRating { get; set; }
    }
}
