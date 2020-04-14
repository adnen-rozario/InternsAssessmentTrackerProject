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
        private readonly IInternRepository _internRepository;

        public InternService(IInternRepository internRepository)
        {
            _internRepository = internRepository;
        }

        public bool AddIntern(InternRequest requestIntern)
        {
            try
            {
                _internRepository.Create(new Interns() { Name = requestIntern.Name, EmailId = requestIntern.EmailId, PhoneNo = requestIntern.PhoneNo, CreatedDate = DateTime.Now });

                _internRepository.Save();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<InternResponse> GetIntern()
        {
            try
            {

                return _internRepository.FindAll()
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public InternResponse GetInternById(int id)
        {
            try
            {
                if (id > 0)
                {
                    return _internRepository.FindByCondition(x => x.InternsId == id)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetDashboardValues()
        {
            try
            {

                var getDashboardValues = _internRepository.FindAll().GroupBy(x => x.OverallRating).Select(z => new { ratingId = z.FirstOrDefault().OverallRating, internCount = z.Count() });

                return getDashboardValues;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateIntern(int id, InternRequest internRequest)
        {
            try
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

                    _internRepository.Update(intern);
                    _internRepository.Save();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteIntern(int id)
        {
            try
            {
                if (id > 0)
                {
                    _internRepository.Delete(id);
                    _internRepository.Save();

                    return true;
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
