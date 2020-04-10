﻿using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Models.Models
{
    public class InternRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
