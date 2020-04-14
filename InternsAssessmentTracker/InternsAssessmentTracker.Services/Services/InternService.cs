using InternsAssessmentTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using InternsAssessment.Entities.Entities;
using InternsAssessmentTracker.Entities.Repository;
using InternsAssessmentTracker.Models.Models;

namespace InternsAssessmentTracker.Services.BusinessObjects
{
    public class InternService : IInternService
    {
        private readonly IInternRepository internRepository;

        public InternService(IInternRepository internRepository)
        {
            this.internRepository = internRepository;

        }

        public bool AddIntern(InternRequest requestIntern)
        {
            
                this.internRepository.Create(new Interns() { Name = requestIntern.Name, EmailId = requestIntern.EmailId, PhoneNo = requestIntern.PhoneNo, CreatedDate = DateTime.Now });

                this.internRepository.Save();

                return true;           
        }

        public IEnumerable<InternResponse> GetIntern()
        {
                return this.internRepository.FindAll()
                                              .Select(x
                                              => new InternResponse()
                                              {
                                                  Name = x.Name,
                                                  EmailId = x.EmailId,
                                                  PhoneNo = x.PhoneNo,
                                                  CreatedDate = x.CreatedDate,
                                                  InternId = x.InternsId
                                              });
            
        }

        public InternResponse GetInternById(int id)
        {

            if (id > 0)
            {
                return this.internRepository.FindByCondition(x => x.InternsId == id)
                    .Select(y =>
                    new InternResponse()
                    {
                        Name = y.Name,
                        EmailId = y.EmailId,
                        PhoneNo = y.PhoneNo
                    }).FirstOrDefault();
            }

            return new InternResponse();

        }

        public object GetDashboardValues()
        {
            var getDashboardValues = this.internRepository.FindAll().GroupBy(x => x.OverallRating).Select(z => new { ratingId = z.FirstOrDefault().OverallRating, internCount = z.Count() });

            return getDashboardValues;
        }

        public bool UpdateIntern(int id, InternRequest internRequest)
        {
            if (id == internRequest.Id)
            {
                Interns intern = new Interns()
                {
                    InternsId = id,
                    Name = internRequest.Name,
                    EmailId = internRequest.EmailId,
                    PhoneNo = internRequest.PhoneNo,
                    CreatedDate = internRequest.CreatedDate
                };

                this.internRepository.Update(intern);
                this.internRepository.Save();

                return true;
            }

            return false;
        }

        public bool DeleteIntern(int id)
        {

            if (id > 0)
            {
                this.internRepository.Delete(id);
                this.internRepository.Save();

                return true;
            }

            return false;

        }
    }
}
