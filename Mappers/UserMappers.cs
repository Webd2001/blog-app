using System;
using blog_app_api.DTO.User;
using blog_app_api.Models;

namespace blog_app_api.Mappers;

public static class UserMappers
{
    public static UserDTO ToUserDTO(this User user)
    {
        return new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Type = user.Type,
            Posts = user.Posts?.Select(x => x.ToPostDTO()).ToList()
        };
    }

    public static User ToCreateUserDTO(this CreateUerDTO createUerDTO)
    {
        return new User
        {
            Name = createUerDTO.Name,
            Type = createUerDTO.Type,
            Password = createUerDTO.Password
        };
    }

    public static User ToUpdateUserDTO(this UpdateUserDTO updateUserDTO)
    {
        return new User
        {
            Name = updateUserDTO.Name,
            Type = updateUserDTO.Type
        };
    }
}
