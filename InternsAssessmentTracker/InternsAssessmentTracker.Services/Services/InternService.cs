using InternsAssessmentTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using InternsAssessment.Entities.Entities;
using InternsAssessmentTracker.Entities.Repository;

namespace InternsAssessmentTracker.Services.BusinessObjects
{
    public class InternService : IInternService
    {
        private readonly  IInternRepository m_InternRepository;

        public InternService(IInternRepository internRepository)
        {
            m_InternRepository = internRepository;
        }

        public void AddIntern()
        {
            try
            {
                this.m_InternRepository.Create(new Interns() { Name = "sdfdffg", EmailId = "dfdfd", PhoneNo = "dfdfgg", CreatedDate = new DateTime() });
                
                this.m_InternRepository.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
