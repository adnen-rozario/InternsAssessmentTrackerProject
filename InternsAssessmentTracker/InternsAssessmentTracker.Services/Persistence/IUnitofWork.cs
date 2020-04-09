using InternsAssessment.Entities.DataContext;
using InternsAssessment.Entities.Entities;
using InternsAssessment.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Services.Persistence
{
    public interface IUnitofWork
    {
        void Commit();
        IRepository<Interns> InternsRepository { get; }
        IRepository<Intern_Rating> Intern_RatingRepository { get; }
        IRepository<Projects> ProjectsRepository { get; }
        IRepository<Project_InternRelation> Project_InternRelationRepository { get; }
        IRepository<Project_TechnologiesRelation> Project_TechnologiesRelationRepository { get; }
        IRepository<Rating_Master> Rating_MasterRepository { get; }
        IRepository<Technologies> TechnologiesRepository { get; }
    }
}
