using InternsAssessment.Entities.DataContext;
using InternsAssessment.Entities.Entities;
using InternsAssessment.Entities.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Services.Persistence
{
    public class UnitofWork : IUnitofWork
    {
        private readonly IATrackerDbContext Context;

        public UnitofWork(IATrackerDbContext context)
        {
            Context = context;
        }          

    private IRepository<Interns> internsRepository;
    private IRepository<Intern_Rating> intern_RatingRepository;
    private IRepository<Projects> projectsRepository;
    private IRepository<Project_InternRelation> project_InternRelationRepository;
    private IRepository<Project_TechnologiesRelation> project_TechnologiesRelationRepository;
    private IRepository<Rating_Master> rating_MasterRepository;
    private IRepository<Technologies> technologiesRepository;


    public IRepository<Interns> InternsRepository
    {
        get
        {
            if (this.internsRepository == null)
            {
                this.internsRepository = new Repository<Interns>(this.Context);
            }

            return this.internsRepository;
        }
    }

    public IRepository<Intern_Rating> Intern_RatingRepository
    {
        get
        {
            if (this.intern_RatingRepository == null)
            {
                this.intern_RatingRepository = new Repository<Intern_Rating>(this.Context);
            }

            return this.intern_RatingRepository;
        }
    }

    public IRepository<Projects> ProjectsRepository
    {
        get
        {
            if (this.projectsRepository == null)
            {
                this.projectsRepository = new Repository<Projects>(this.Context);
            }

            return this.projectsRepository;
        }
    }

    public IRepository<Project_InternRelation> Project_InternRelationRepository
    {
        get
        {
            if (this.project_InternRelationRepository == null)
            {
                this.project_InternRelationRepository = new Repository<Project_InternRelation>(this.Context);
            }

            return this.project_InternRelationRepository;
        }
    }

    public IRepository<Project_TechnologiesRelation> Project_TechnologiesRelationRepository
    {
        get
        {
            if (this.project_TechnologiesRelationRepository == null)
            {
                this.project_TechnologiesRelationRepository = new Repository<Project_TechnologiesRelation>(this.Context);
            }

            return this.project_TechnologiesRelationRepository;
        }
    }

    public IRepository<Rating_Master> Rating_MasterRepository
    {
        get
        {
            if (this.rating_MasterRepository == null)
            {
                this.rating_MasterRepository = new Repository<Rating_Master>(this.Context);
            }

            return this.rating_MasterRepository;
        }
    }

    public IRepository<Technologies> TechnologiesRepository
    {
        get
        {
            if (this.technologiesRepository == null)
            {
                this.technologiesRepository = new Repository<Technologies>(this.Context);
            }

            return this.technologiesRepository;
        }
    }


    public void Commit()
    {
        Context.SaveChanges();
    }
 }
}


