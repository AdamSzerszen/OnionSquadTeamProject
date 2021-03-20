using System.Threading.Tasks;
using OnionSquadTeamProject.Api.Structures;
using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Services.Mailing
{
  public interface IMailingService
  {
    Task<SendingResponse> SendMails(UserViewModel userViewModel);
  }
}