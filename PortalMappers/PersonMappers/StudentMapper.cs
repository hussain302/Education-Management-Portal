using PortalMappers.PortalMapperes;
using PortalModels.DomainModels;
using PortalModels.WebModels;

namespace PortalMappers.PersonMappers
{
    public static class StudentMapper
    {

        public static StudentModel ToModel(this Student source)
        {
            return new StudentModel
            {
                Email = source.Email,
                FirstName = source.FirstName,
                //Address = source.Address,
                Id = source.Id,
                LastName = source.LastName,
                Phone = source.Phone,
                IsGraduated = (bool) source.IsGraduated,
                Program = source.Program.ToModel(),
                RollNumber = source.RollNumber,
                ProgramId = source.ProgramId

            };
        }
        public static Student ToDb(this StudentModel source)
        {
            return new Student
            {
                Email = source.Email,
                //Address = source.Address,
                FirstName = source.FirstName,
                Id = source.Id,
                LastName = source.LastName,
                Phone = source.Phone,
                IsGraduated = source.IsGraduated,
                ProgramId = source.ProgramId,
                RollNumber = source.RollNumber
            };
        }

    }
}
