using Microsoft.AspNetCore.Mvc;
using RecipeApi.WebApi.Models;
using RecipeApi.WebApi.Helpers;
using RecipeApi.WebApi.Services.Authentication.Interfaces;

namespace RecipeApi.Api.Controllers;

public class UsersController : Controller
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("Authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [Authorize]
    [HttpGet("GetAll")]

    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}
