using System;

namespace blog_app_api.DTO.Posts;

public class CreatePostDTO
{
    public string? Title { get; set; }
    public string? Content { get; set; }
}
