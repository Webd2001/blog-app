using System;

namespace blog_app_api.DTO.User;

public class CreateUerDTO
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Password { get; set; }
}
