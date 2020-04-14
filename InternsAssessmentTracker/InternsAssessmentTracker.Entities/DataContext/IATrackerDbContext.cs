using InternsAssessment.Entities.Entities;
using InternsAssessmentTracker.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.DataContext
{
    public class IATrackerDbContext:DbContext
    {
        public IATrackerDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Interns> Interns { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Technologies> Technologies { get; set; }
        public DbSet<RatingMaster> RatingMaster { get; set; }
        public DbSet<ProjectInternRelation> ProjectInternRelation { get; set; }
        public DbSet<ProjectTechnologiesRelation> ProjectTechnologiesRelation { get; set; }
        public DbSet<InternRating> InternRating { get; set; }

        public DbSet<Mentor> Mentor { get; set; }
        public DbSet<MentorProjectRelation> MentorProjectRelation { get; set; }
    }
}
