using PortalModels.DomainModels;
using PortalModels.WebModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortalMappers.PortalMapperes
{
    public static class CourseMapper
    {
        public static CoursesModel ToModel(this Courses source)
        {
            return new CoursesModel
            {
                Id = source.Id,
                CreditHours= source.CreditHours,
                Description= source.Description,
                Name= source.Name,
                Program = source.Program.ToModel()
            };
        }
        public static Courses ToDb(this CoursesModel source)
        {
            return new Courses
            {
                Id = source.Id,
                CreditHours= source.CreditHours,
                Description= source.Description,
                Name= source.Name,
                ProgramId = source.ProgramId
            };
        }
    }
}
