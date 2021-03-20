using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnionSquadTeamProject.Api.Services.Authentication;
using OnionSquadTeamProject.Api.Services.Mailing;
using OnionSquadTeamProject.Api.Structures;
using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Controllers
{
  public class MailingController : ControllerBase
  {
    private readonly IAuthenticationService _authenticationService;
    private readonly IMailingService _mailingService;
    
    public MailingController(IAuthenticationService authenticationService, IMailingService mailingService)
    {
      _authenticationService = authenticationService;
      _mailingService = mailingService;
    }

    [HttpPost]
    public async Task<SendingResponse> SendMailToAllWatchers(UserViewModel userViewModel)
    {
      if (!ModelState.IsValid)
      {
        return null;
      }

      if (_authenticationService.IsUserValid(userViewModel))
      {
          return await _mailingService.SendMails(userViewModel);
      }

      return null;
    }

    [HttpPost]
    public void AddWatcher(UserViewModel userViewModel, WatcherViewModel watcher)
    {
      
    }
  }
}