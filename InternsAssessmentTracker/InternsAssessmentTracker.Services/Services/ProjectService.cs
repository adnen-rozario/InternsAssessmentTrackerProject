using InternsAssessment.Entities.Entities;
using InternsAssessmentTracker.Entities.Repository;
using InternsAssessmentTracker.Entities.Repository.Interfaces;
using InternsAssessmentTracker.Models.Models;
using InternsAssessmentTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternsAssessmentTracker.Services.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;
        private readonly IProjectTechnologiesRepository projectTechnologiesRepository;

        public ProjectService(IProjectRepository projectRepository, IProjectTechnologiesRepository projectTechnologiesRepository)
        {
            this.projectRepository = projectRepository;
            this.projectTechnologiesRepository = projectTechnologiesRepository;
        }

        public bool AddProject(ProjectRequest requestProject)
        {
            try
            {     
                if (!string.IsNullOrEmpty(requestProject.ProjectName))
                {
                    Projects project = new Projects()
                    {
                        Name = requestProject.ProjectName,
                        Description = requestProject.ProjectDescription,
                        CreatedDate = DateTime.Now
                    };

                    this.projectRepository.Create(project);
                    this.projectRepository.Save();

                    if (requestProject.TechId.Any() && project.ProjectsId != 0)
                    {
                        foreach (var id in requestProject.TechId)
                        {
                            this.projectTechnologiesRepository
                                .Create(new ProjectTechnologiesRelation() { ProjectsId = project.ProjectsId, TechnologiesId = id });
                        }

                        this.projectTechnologiesRepository.Save();

                        return true;
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
