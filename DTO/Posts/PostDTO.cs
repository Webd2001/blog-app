using System;

namespace blog_app_api.DTO.Posts;

public class PostDTO
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public int UserId { get; set; }
}
