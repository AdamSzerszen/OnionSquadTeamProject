using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Services.Authentication
{
  public class AuthenticationService: IAuthenticationService
  {
    public bool IsUserValid(UserViewModel userViewModel)
    {
      return true;
    }
  }
}