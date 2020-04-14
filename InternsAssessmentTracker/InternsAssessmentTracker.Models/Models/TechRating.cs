using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Models.Models
{
    public class TechRating
    {
        public int TechId { get; set; }

        public string TechName
        {
            set
            {
                this.TechId = int.Parse(value);
            }
        }

        public string RatingName
        {
            set
            {
                this.RatingId = int.Parse(value);
            }
        }

        public int RatingId { get; set; }


    }
}
