using InternsAssessment.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessment.Entities.DataContext
{
    public class IATrackerDbContext:DbContext
    {
        public IATrackerDbContext(DbContextOptions<IATrackerDbContext> options) : base(options)
        {

        }

        public DbSet<Interns> Interns { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Technologies> Technologies { get; set; }
        public DbSet<Rating_Master> Rating_Master { get; set; }
        public DbSet<Project_InternRelation> Project_InternRelation { get; set; }
        public DbSet<Project_TechnologiesRelation> Project_TechnologiesRelation { get; set; }
        public DbSet<Intern_Rating> Intern_Rating { get; set; }

    }
}
