using System.Collections.Generic;
using System.Threading.Tasks;
using OnionSquadTeamProject.Api.Structures;
using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Services.Sending
{
  public interface ISendingService
  {
    Task<SendingResponse> SendMessage(SendingMailViewModel mailViewModel);
  }
}