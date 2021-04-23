using System;
using System.Threading.Tasks;
using OnionSquadTeamProject.Api.Models;
using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Services.Authentication
{
  public interface IUserService
  {
    Task<bool> IsUserValid(UserViewModel userViewModel);
    Task<UserViewModel> GetUserById(int userId);
    Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
    Task Create(RegisterUserModel user, string password);
  }
}