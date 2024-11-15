using System;
using blog_app_api.Models;

namespace blog_app_api.Interfaces;

public interface IBlogPostRepository
{
    Task<List<Post>> GetAllBlogPostAsync();
    Task<Post?> GetPostByIdAsync(int id);
    Task<Post?> UpdateAsync(int id, Post post);
    Task<Post?> DeleteAsync(int id);
    Task<Post?> CreateAsync(Post post);
}
