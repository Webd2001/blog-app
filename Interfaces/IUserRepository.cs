using System;
using blog_app_api.DTO.Query;
using blog_app_api.Models;

namespace blog_app_api.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetAllUserAsync();
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> CreateAsync(User user);
    Task<User?> UpdateAsync(int id,User user);
    Task<User?> DeleteAsync(int id);
    Task<User?> LoginAsync(QueryParams query);
    Task<List<User>> GetByNameAsync(string name);
}
