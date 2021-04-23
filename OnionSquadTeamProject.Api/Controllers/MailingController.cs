using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnionSquadTeamProject.Api.Authentication;
using OnionSquadTeamProject.Api.Services.Authentication;
using OnionSquadTeamProject.Api.Services.Mailing;
using OnionSquadTeamProject.Api.Structures;
using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Controllers
{
  public class MailingController : ControllerBase
  {
    private readonly IUserService _userService;
    private readonly IMailingService _mailingService;

    public MailingController(IUserService userService, IMailingService mailingService)
    {
      _userService = userService;
      _mailingService = mailingService;
    }

    [HttpPost]
    [Authorize]
    [Route("mailing/send")]
    public async Task<ActionResult<SendingResponse>> SendMailToAllWatchers([FromBody] UserViewModel userViewModel)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      bool isUserValid = await _userService.IsUserValid(userViewModel);
      if (isUserValid)
      {
        return Ok(await _mailingService.SendMails(userViewModel, "Foo"));
      }

      return BadRequest("Invalid user!");
    }

    [HttpPost]
    [Authorize]
    [Route("mailing/watchers/add")]
    public async Task<ActionResult<AddWatcherResponse>> AddWatcher([FromBody] AddWatcherRequest addWatcherRequest)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      bool isUserValid = await _userService.IsUserValid(addWatcherRequest.Parent);
      if (!isUserValid)
      {
        return BadRequest("Invalid user!");
      }

      AddWatcherResponse response =
        await _mailingService.AddWatcher(addWatcherRequest.Parent.Id, addWatcherRequest.Watcher);
      return Ok(response);
    }
  }
}