using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Models.Models
{
    public class InternResponse
    {
        public int InternId { get; set; }

        public string Name { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public DateTime CreatedDate { get; set; }

        public string ProjectName { get; set; }

        public string ProjectDescription { get; set; }

        public string Technologies { get; set; }

        public string RatingValues { get; set; }

    }
}
