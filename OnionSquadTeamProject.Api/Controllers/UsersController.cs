using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionSquadTeamProject.Api.Models;
using OnionSquadTeamProject.Api.Services.Authentication;

namespace OnionSquadTeamProject.Api.Controllers
{
  public class UsersController : ControllerBase
  {
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public async Task<ActionResult> Authenticate(AuthenticateRequest model)
    {
      AuthenticateResponse response = await _userService.Authenticate(model);

      if (response == null)
        return BadRequest(new { message = "Username or password is incorrect" });

      return Ok(response);
    }
    
    [AllowAnonymous]
    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody]RegisterUserModel model)
    {
      try
      {
        // create user
        await _userService.Create(model, model.Password);
        return Ok();
      }
      catch (Exception ex)
      {
        // return error message if there was an exception
        return BadRequest(new { message = ex.Message });
      }
    }
  }
}