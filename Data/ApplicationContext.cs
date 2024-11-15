using System;
using blog_app_api.Models;
using Microsoft.EntityFrameworkCore;

namespace blog_app_api.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
}
