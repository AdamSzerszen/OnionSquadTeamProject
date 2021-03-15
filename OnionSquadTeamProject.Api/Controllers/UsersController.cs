using System;
using Microsoft.AspNetCore.Mvc;
using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Controllers
{
  public class UsersController : ControllerBase
  {
    [HttpPost]
    public bool CreateUser()
    {
      return true;
    }

    [HttpGet]
    public UserViewModel ReadUser(Guid userId)
    {
      return new UserViewModel();
    }

    [HttpPost]
    public bool UpdateUser(UserViewModel userViewModel)
    {
      return true;
    }

    [HttpPost]
    public bool DeleteUser(Guid userId)
    {
      return true;
    }
  }
}