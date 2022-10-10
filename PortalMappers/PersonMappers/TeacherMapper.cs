using PortalModels.DomainModels;
using PortalModels.WebModels;

namespace PortalMappers.PersonMappers
{
    public static class TeacherMapper
    {


        public static TeacherModel ToModel(this Teacher source)
        {
            return new TeacherModel
            {
                Address = source.Address,
                Email = source.Email,
                FirstName = source.FirstName,
                Id = source.Id,
                IsPermanent = (bool)source.IsPermanent,
                LastName = source.LastName,
                Phone = source.Phone,
                Qualification = source.Qualification.ToModel(),
                TeacherCode = source.TeacherCode,
                QualificationId = source.QualificationId,
                Specialization = source.Specialization
            };
        }

        public static Teacher ToDb(this TeacherModel source)
        {
            return new Teacher
            {
                Address = source.Address,
                Email = source.Email,
                FirstName = source.FirstName,
                Id = source.Id,
                IsPermanent = source.IsPermanent,
                LastName = source.LastName,
                Phone = source.Phone,
                QualificationId = source.QualificationId,
                TeacherCode = source.TeacherCode,
                Specialization = source.Specialization
            };
        }

    }
}
