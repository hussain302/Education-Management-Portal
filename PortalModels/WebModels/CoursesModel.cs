using PortalModels.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PortalModels.WebModels
{
    public class CoursesModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreditHours { get; set; }
        public int ProgramId { get; set; }
        public virtual ProgramModel Program { get; set; }
    }
}
