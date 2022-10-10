using PortalModels.DomainModels;
using PortalModels.WebModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMappers.PortalMapperes
{
    public static class JobMapper
    {
        public static JobModel ToModel(this Job source)
        {
            return new JobModel
            {
                Id = source.Id,
                Designation = source.Designation,
                Details = source.Details,
                SalaryBraket = source.SalaryBraket,
                Title = source.Title
            };
        }
        public static Job ToDb(this JobModel source)
        {
            return new Job
            {
                Id = source.Id,
                Designation = source.Designation,
                Details = source.Details,
                SalaryBraket = source.SalaryBraket,
                Title = source.Title,
            };
        }


    }
}
