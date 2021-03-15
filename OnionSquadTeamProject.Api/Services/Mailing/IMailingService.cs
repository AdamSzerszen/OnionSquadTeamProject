using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Services.Mailing
{
  public interface IMailingService
  {
    void SendMails(UserViewModel userViewModel);
  }
}