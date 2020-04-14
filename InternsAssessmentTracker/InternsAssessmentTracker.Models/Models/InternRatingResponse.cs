using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Models.Models
{
    public class InternRatingResponse
    {
        public int InternId { get; set; }
        public int TechId { get; set; }

        public List<int> TechIds { get; set; }

        public string InternName { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public string TechnologyName { get; set; }

        public List<string> TechnologyNameList { get; set; }
        public string TechnologyRating { get; set; }

        public List<TechRating> TechRating { get; set; }
    }
}
