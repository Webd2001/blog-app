using blog_app_api.DTO.Posts;
using blog_app_api.Interfaces;
using blog_app_api.Mappers;
using blog_app_api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace blog_app_api.Controllers
{
    [Route("api/blog-post")]
    [ApiController]
    public class BlogPostController(IBlogPostRepository blogPostRepository) : ControllerBase
    {
        private readonly IBlogPostRepository _blogPostRepository = blogPostRepository;

        // GET: api/blog-post
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogPosts = await _blogPostRepository.GetAllBlogPostAsync();
            return Ok(blogPosts);
        }

        // GET: api/blog-post/{id}
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blogPost = await _blogPostRepository.GetPostByIdAsync(id);
            return blogPost == null ? NotFound("Blog post not found") : Ok(blogPost.ToPostDTO());
        }

        // POST: api/blog-post
        [HttpPost("{id:int}")]
        public async Task<IActionResult> Create([FromRoute] int id, [FromBody] CreatePostDTO postRequest)
        {
            if (postRequest == null)
            {
                return BadRequest("Invalid blog post data.");
            }

            var createdPost = await _blogPostRepository.CreateAsync(postRequest.ToCreatePostDTO(id));
            return createdPost == null ? BadRequest("Failed to create the blog post.") : CreatedAtAction(nameof(GetById), new { id = createdPost.Id }, createdPost.ToPostDTO());
        }

        // PUT: api/blog-post/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePostDTO postRequest)
        {
            if (postRequest == null)
            {
                return BadRequest("Invalid blog post data.");
            }

            var updatedPost = await _blogPostRepository.UpdateAsync(id, postRequest.ToUpdatePostDTO());
            return updatedPost == null ? NotFound("Blog post not found") : Ok(updatedPost.ToPostDTO());
        }

        // DELETE: api/blog-post/{id}
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedPost = await _blogPostRepository.DeleteAsync(id);
            return deletedPost == null ? NotFound("Blog post not found") : Ok(deletedPost.ToPostDTO());
        }
    }
}
