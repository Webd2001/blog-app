using blog_app_api.DTO.Posts;

namespace blog_app_api.DTO.User;

public class UserDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public List<PostDTO>? Posts { get; set; }
}
