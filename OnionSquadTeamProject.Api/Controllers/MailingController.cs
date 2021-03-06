﻿using System.Threading.Tasks;
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
    public async Task<ActionResult<SendingResponse>> SendMail([FromBody] SendMailRequest sendRequest)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      bool isUserValid = await _userService.IsUserValid(sendRequest.Sender);
      if (isUserValid)
      {
        return Ok(await _mailingService.SendMail(sendRequest.Sender, sendRequest.MailViewModel));
      }

      return BadRequest("Invalid user!");
    }
  }
}