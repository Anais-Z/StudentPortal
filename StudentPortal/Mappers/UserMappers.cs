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
    }
}
