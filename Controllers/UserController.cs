using blog_app_api.DTO.Query;
using blog_app_api.DTO.User;
using blog_app_api.Interfaces;
using blog_app_api.Mappers;
using blog_app_api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace blog_app_api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;

        // Get all users
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepository.GetAllUserAsync();
            return Ok(users);
        }

        // Get user by ID (Guid)
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return user == null ? NotFound("User not found") : Ok(user.ToUserDTO());
        }

        // Create a new user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUerDTO userRequest)
        {
            if (userRequest == null)
            {
                return BadRequest("User data is required.");
            }

            var user = await _userRepository.CreateAsync(userRequest.ToCreateUserDTO());
            return user == null
                ? BadRequest("Failed to create user.")
                : CreatedAtAction(nameof(GetById), new { id = user.Id }, user.ToUserDTO());
        }

        // Update user by ID
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDTO userRequest)
        {
            if (userRequest == null)
            {
                return BadRequest("User data is required.");
            }

            var user = await _userRepository.UpdateAsync(id, userRequest.ToUpdateUserDTO());
            return user == null ? NotFound("User not found") : Ok(user.ToUserDTO());
        }

        // Delete user by ID
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.DeleteAsync(id);
            return user == null ? NotFound("User not found") : Ok(user.ToUserDTO());
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody][FromQuery] QueryParams query)
        {
            var user = await _userRepository.LoginAsync(query);
            return user == null ? NotFound() : Ok(user.ToUserDTO());
        }

        [HttpPost("name")]
        public async Task<IActionResult> GetUserByName([FromBody] string name)
        {
            var user = await _userRepository.GetByNameAsync(name);
            return user == null ? NotFound() : Ok(user);
        }
    }
}
