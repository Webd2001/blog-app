using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace blog_app_api.Models;

public class Post
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }
}
