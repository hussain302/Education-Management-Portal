using PortalModels.DomainModels;
using PortalModels.WebModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMappers.PersonMappers
{
    public static class QualificationMapper
    {

        public static QualificationModel ToModel(this Qualification source)
        {
            return new QualificationModel
            {
                Id = source.Id,
                Name = source.Name
            };
        }

        public static Qualification ToDb(this QualificationModel source)
        {
            return new Qualification
            {
                Id = source.Id,
                Name = source.Name
            };
        }

    }
}
