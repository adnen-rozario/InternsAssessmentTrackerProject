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
        private readonly ITechnologyRepository technologyRepository;
        private readonly IProjectInternRepository projectInternRepository;


        public ProjectService(IProjectRepository projectRepository, IProjectTechnologiesRepository projectTechnologiesRepository, ITechnologyRepository technologyRepository, IProjectInternRepository projectInternRepository)
        {
            this.projectRepository = projectRepository;
            this.projectTechnologiesRepository = projectTechnologiesRepository;
            this.technologyRepository = technologyRepository;
            this.projectInternRepository = projectInternRepository;
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

        public IEnumerable<KeyValueResponse> GetTechnologies()
        {
            try
            {
                return this.technologyRepository.FindAll()
                    .Select(
                    x => new KeyValueResponse()
                    {
                        Key = x.TechnologiesId,
                        Value = x.Name
                    });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<ProjectResponse> GetProjects()
        {
            try
            {
                return this.projectRepository.FindByCondition(x => x.ProjectsId != 0, "ProjectTechnologiesRelation.Technologies")
                .Select(x => new ProjectResponse()
                {
                    ProjectName = x.Name,
                    ProjectDescription = x.Description,
                    ProjectId = x.ProjectsId,
                    CreatedDate = x.CreatedDate,
                    ProjectTechnologies = string.Join(",", x.ProjectTechnologiesRelation.Select(y => y.Technologies.Name))
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<KeyValueResponse> GetProjectNames()
        {
            try
            {
                return this.projectRepository.FindByCondition(x => x.ProjectsId != 0, "ProjectTechnologiesRelation.Technologies")
                .Select(x => new KeyValueResponse()
                {
                    Key = x.ProjectsId,
                    Value = x.Name
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AssignProjectToIntern(AssignProjectRequest request)
        {
            try
            {
                if (request.InternId != 0 && request.ProjId != 0)
                {
                    this.projectInternRepository.Create(new ProjectInternRelation() { InternsId = request.InternId, ProjectsId = request.ProjId });
                    this.projectInternRepository.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
