using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Login.Model;
using Login.Repository;

namespace Login.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        LoginRepo _logininterface;

        public LoginController(LoginRepo loginInterface)
        {
            _logininterface = loginInterface;
        }

        [HttpPost("addUser")]
        public IActionResult RegisterUser(User user)
        {
            if (user == null) return BadRequest("User data is required.");
            var newUser = _logininterface.RegisterUser(user);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, newUser);
        }

        // Login User
        [HttpPost("login")]
        public IActionResult LoginUser([FromQuery] string username, [FromQuery] string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Username and password are required.");
            }

            // Check if a user with the given username and password exists in the database
            bool isLoginSuccessful = _logininterface.LoginUser(username, password);

            if (isLoginSuccessful)
            {
                return Ok(new { message = "Login successful" });
            }

            return Unauthorized(new { message = "Invalid username or password." });
        }


        [HttpGet("getUser/{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _logininterface.GetUserById(id);
            if (user == null) return NotFound($"User with ID {id} not found.");
            return Ok(user);
        }

        [HttpPut("updateUser")]
        public IActionResult UpdateUser(User user)
        {
            if (user == null) return BadRequest("User data is required.");
            var updatedUser = _logininterface.UpdateUser(user);
            if (updatedUser == null) return BadRequest("Failed to update user.");
            return Ok(updatedUser);
        }

        [HttpDelete("deleteUser/{id}")]
        public IActionResult DeleteUser(int id)
        {
            var deletedUser = _logininterface.DeleteUser(id);
            if (deletedUser == null) return NotFound($"User with ID {id} not found.");
            return Ok(deletedUser);
        }

    }
}
