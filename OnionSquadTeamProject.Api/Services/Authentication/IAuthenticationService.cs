using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Services.Authentication
{
  public interface IAuthenticationService
  {
    bool IsUserValid(UserViewModel userViewModel);
  }
}