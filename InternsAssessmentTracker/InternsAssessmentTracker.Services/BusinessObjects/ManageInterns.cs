using InternsAssessmentTracker.Services.Interfaces;
using InternsAssessmentTracker.Services.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using InternsAssessment.Entities.Entities;

namespace InternsAssessmentTracker.Services.BusinessObjects
{
    public class ManageInterns : ImanageInterns
    {
        private readonly IUnitofWork _unitOfWork;

        public ManageInterns(IUnitofWork unitofWork)
        {
            _unitOfWork = unitofWork;
        }

        public void AddIntern()
        {
            try
            {
                var interns = this._unitOfWork.InternsRepository.Add(new Interns() { Name = "sdfdffg", EmailId = "dfdfd", PhoneNo = "dfdfgg", CreatedDate = new DateTime() });

                //this._unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
