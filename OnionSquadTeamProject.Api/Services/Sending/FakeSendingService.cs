using System;
using System.Threading.Tasks;
using OnionSquadTeamProject.Api.Structures;
using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Services.Sending
{
  public class FakeSendingService: ISendingService
  {
    public async Task<SendingResponse> SendMessage(SendingMailViewModel mailViewModel)
    {
      throw new NotImplementedException();
    }
  }
}