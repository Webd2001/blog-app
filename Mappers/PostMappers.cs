using System;
using blog_app_api.DTO.Posts;
using blog_app_api.Models;

namespace blog_app_api.Mappers;

public static class PostMappers
{
    public static PostDTO ToPostDTO(this Post post)
    {
        return new PostDTO
        {
            Title = post.Title,
            Content = post.Content,
            DateCreated = post.DateCreated,
            UserId = post.UserId
        };
    }

    public static Post ToUpdatePostDTO(this UpdatePostDTO updatePostDTO)
    {
        return new Post
        {
            Title = updatePostDTO.Title,
            Content = updatePostDTO.Content,
        };
    }

    public static Post ToCreatePostDTO(this CreatePostDTO createPostDTO, int userId)
    {
        return new Post
        {
            Title = createPostDTO.Title,
            Content = createPostDTO.Content,
            UserId = userId
        };
    }
}
