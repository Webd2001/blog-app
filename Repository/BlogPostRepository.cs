using System;
using blog_app_api.Data;
using blog_app_api.Interfaces;
using blog_app_api.Models;
using Microsoft.EntityFrameworkCore;

namespace blog_app_api.Repository;

public class BlogPostRepository(ApplicationContext _context) : IBlogPostRepository
{
    public async Task<Post?> CreateAsync(Post post)
    {
        if (post == null)
        {
            return null;
        }
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task<Post?> DeleteAsync(int id)
    {
        var blogPost = await _context.Posts.FindAsync(id);
        if (blogPost == null)
        {
            return null;
        }
        _context.Posts.Remove(blogPost);
        await _context.SaveChangesAsync();
        return blogPost;
    }

    public async Task<List<Post>> GetAllBlogPostAsync()
    {
        var blogPost = await _context.Posts.ToListAsync();
        return blogPost;
    }

    public async Task<Post?> GetPostByIdAsync(int id)
    {
        var blogPost = await _context.Posts.FindAsync(id);
        if (blogPost == null)
        {
            return null;
        }
        return blogPost;
    }

    public async Task<Post?> UpdateAsync(int id, Post post)
    {
        if (post == null || id != post.Id)
        {
            return null;
        }

        var existingPost = await _context.Posts.FindAsync(id);
        if (existingPost == null)
        {
            return null;
        }

        // Update properties (ensure these are the properties you want to update)
        existingPost.Title = post.Title;
        existingPost.Content = post.Content;

        _context.Posts.Update(existingPost);
        await _context.SaveChangesAsync();

        return existingPost;
    }
}
