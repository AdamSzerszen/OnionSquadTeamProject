using Microsoft.AspNetCore.Mvc;
using OnionSquadTeamProject.Api.Services.Authentication;
using OnionSquadTeamProject.Api.Services.Mailing;
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
    public void SendMailToAllWatchers(UserViewModel userViewModel)
    {
      if (!ModelState.IsValid)
      {
        return;
      }

      if (_authenticationService.IsUserValid(userViewModel))
      {
          _mailingService.SendMails(userViewModel);
      }
    }
  }
}