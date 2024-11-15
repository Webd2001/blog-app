using System;
using blog_app_api.Data;
using blog_app_api.DTO.Query;
using blog_app_api.Interfaces;
using blog_app_api.Models;
using Microsoft.EntityFrameworkCore;

namespace blog_app_api.Repository;

public class UserRepository(ApplicationContext _context) : IUserRepository
{
    public async Task<User?> CreateAsync(User user)
    {
        if (user == null)
        {
            return null;
        }
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> DeleteAsync(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
        {
            return null;
        }
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> GetAllUserAsync()
    {
        var user = await _context.Users.Include(x => x.Posts).ToListAsync();
        return user;
    }

    public async Task<List<User>> GetByNameAsync(string name)
    {
        var user = await _context.Users.Where(x => x.Name.Contains(name)).ToListAsync();
        return user;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        var user = await _context.Users.Include(c => c.Posts).FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            return null;
        }
        return user;
    }

    public async Task<User?> LoginAsync(QueryParams query)
    {
        if (!string.IsNullOrWhiteSpace(query.Name) && !string.IsNullOrWhiteSpace(query.Password))
        {
            // Query the database for a user with matching name and password
            var user = await _context.Users
                .Where(x => x.Name == query.Name && x.Password == query.Password).Include(c => c.Posts)
                .FirstOrDefaultAsync(); // Return the first matching user or null if not found

            return user; // If user is found, return it, otherwise return null
        }

        // If name or password is empty or null, return null
        return null;
    }

    public async Task<User?> UpdateAsync(int id, User user)
    {
        if (user == null || id != user.Id)
        {
            return null;
        }
        var existingUser = await _context.Users.FindAsync(id);
        if (existingUser == null)
        {
            return null;
        }
        existingUser.Name = user.Name;
        existingUser.Type = user.Type;

        _context.Users.Update(existingUser);
        await _context.SaveChangesAsync();
        return user;
    }
}
