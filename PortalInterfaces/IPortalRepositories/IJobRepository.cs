using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalInterfaces.IPortalRepositories
{
    public interface IJobRepository
    {
        bool AddJob(Job model);
        bool RemoveJob(int jobId);
        bool UpdateJob(Job newJob);
        IEnumerable<Job> GetJobs();
        Job GetJob(int jobId);
        Job GetJob(string jobName);
    }
}
