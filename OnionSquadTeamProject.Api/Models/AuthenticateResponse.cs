using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Models
{
  public class AuthenticateResponse
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(UserViewModel user, string token)
    {
      Id = user.Id;
      Name = user.Name;
      Token = token;
    }
  }
}