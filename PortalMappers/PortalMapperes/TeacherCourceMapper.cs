using PortalMappers.PersonMappers;
using PortalModels.DomainModels;
using PortalModels.WebModels;

namespace PortalMappers.PortalMapperes
{
    public static class TeacherCourceMapper
    {

        public static TeacherCourseModel ToModel(this TeacherCourse source)
        {
            return new TeacherCourseModel
            {
                Id = source.Id,
                Courses = source.Courses.ToModel(),
                Teacher = source.Teacher.ToModel(),
                CourseId = source.CourseId,
                TeacherId=source.TeacherId,
            };
        }

        public static TeacherCourse ToDb(this TeacherCourseModel source)
        {
            return new TeacherCourse
            {
                Id = source.Id,
                CourseId = source.CourseId,
                TeacherId = source.TeacherId,
            };
        }

    }
}
