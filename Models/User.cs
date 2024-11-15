using System;
using System.Text.Json.Serialization;

namespace blog_app_api.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Password { get; set; }
    public List<Post>? Posts { get; set; } = [];
}
