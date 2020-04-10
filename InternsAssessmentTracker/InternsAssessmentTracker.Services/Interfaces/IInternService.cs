using InternsAssessmentTracker.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InternsAssessmentTracker.Services.Interfaces
{
    public interface IInternService
    {
        bool AddIntern(InternRequest request);

        IEnumerable<InternResponse> GetIntern();

        InternResponse GetInternById(int id);
        bool UpdateIntern(int id, InternRequest internRequest);

        bool DeleteIntern(int id);
    }
}
