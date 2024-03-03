using StudentPortal.Dto;
using StudentPortal.Models;

namespace StudentPortal.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Password = userModel.Password
            };
        }

        public static User ToUserObject(this UserDto userDtoModel)
        {
            return new User
            {
                Id = userDtoModel.Id,
                Email = userDtoModel.Email,
                FirstName = userDtoModel.FirstName,
                LastName = userDtoModel.LastName,
                Password = userDtoModel.Password
            };
        }

        public static CourseDto ToCourseDto(this Course courseModel)
        {
            return new CourseDto
            {
                Id = courseModel.Id,
                Name= courseModel.Name,
                UserCount= courseModel.UserCount,
                CourseDescription= courseModel.CourseDescription
            };
        }

        public static Course ToCourseObject(this CourseDto courseDtoModel)
        {
            return new Course
            {
                Id = courseDtoModel.Id,
                Name = courseDtoModel.Name,
                UserCount = courseDtoModel.UserCount,
                CourseDescription = courseDtoModel.CourseDescription
            };
        }
    }
}
