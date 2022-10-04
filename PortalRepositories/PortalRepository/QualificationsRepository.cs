using Portal.DAL;
using PortalInterfaces.IPortalRepositories;
using PortalModels.DomainModels;
using System.Collections.Generic;
using System.Linq;


namespace PortalRepositories.PortalRepository
{
    public class QualificationsRepository : IQualificationRepository
    {
        private readonly PortalContext context;

        public QualificationsRepository(PortalContext context)
        {
            this.context = context;
        }

        public bool AddQualiofication(Qualification model)
        {
            try
            {
                if (model == null) return false;
                context.Add<Qualification>(model);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Qualification GetQualification(int qualificationId)
        {
            try
            {
                return context.Qualifications.FirstOrDefault(x=>x.Id == qualificationId);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Qualification> GetQualifications()
        {
            try
            {
                return context.Qualifications.ToList();
            }
            catch
            {
                return null;
            }
        }

        public bool RemoveQualiofication(int qualificationId)
        {
            try
            {
                var find = GetQualification(qualificationId);
                context.Remove<Qualification>(find);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateQualiofication(Qualification newQualiofication)
        {
            try
            {
                if (newQualiofication == null) return false;
                context.Update<Qualification>(newQualiofication);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
