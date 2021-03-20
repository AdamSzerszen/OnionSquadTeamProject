using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnionSquadTeamProject.Api.Structures;
using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Services.Sending
{
  public class FakeSendingService: ISendingService
  {
    public async Task<SendingResponse> SendSingle(WatcherViewModel watchers)
    {
      await Task.Delay(1);
      return new SendingResponse
      {
        SentTime = DateTime.Now,
        AllSentWithSuccess = true
      };
    }

    public async Task<SendingResponse> SendBulk(List<WatcherViewModel> watchers)
    {
      await Task.Delay(1);
      return new SendingResponse
      {
        SentTime = DateTime.Now,
        AllSentWithSuccess = true
      };
    }
  }
}