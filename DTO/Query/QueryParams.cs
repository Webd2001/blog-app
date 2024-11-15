using System;

namespace blog_app_api.DTO.Query;

public class QueryParams
{
    public int? Id { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
}
