using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalInterfaces.IPortalRepositories
{
    public interface IQualificationRepository
    {
        bool AddQualiofication(Qualification model);
        bool RemoveQualiofication(int qualificationId);
        bool UpdateQualiofication(Qualification newQualiofication);
        Qualification GetQualification(int qualificationId);
        IEnumerable<Qualification> GetQualifications();
    }
}
