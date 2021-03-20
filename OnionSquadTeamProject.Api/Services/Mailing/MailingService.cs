using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnionSquadTeamProject.Api.Models;
using OnionSquadTeamProject.Api.Repositories.Watchers;
using OnionSquadTeamProject.Api.Services.Sending;
using OnionSquadTeamProject.Api.Structures;
using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Services.Mailing
{
  public class MailingService: IMailingService
  {
    private readonly IWatchersRepository _watchersRepository;
    private readonly ISendingService _sendingService;
    
    public MailingService(IWatchersRepository watchersRepository, ISendingService sendingService)
    {
      _watchersRepository = watchersRepository;
      _sendingService = sendingService;
    }

    public async Task<SendingResponse> SendMails(UserViewModel userViewModel)
    {
      List<WatcherModel> watcherModels = await _watchersRepository.GetAllWatchers(userViewModel.Id);

      ParallelQuery<WatcherViewModel> query = from watcherModel in watcherModels.AsParallel()
        select new WatcherViewModel
        {
          Id = watcherModel.Id,
          Email = watcherModel.Email,
          Name = watcherModel.Name
        };
      
      return await _sendingService.SendBulk(query.ToList());
    }
  }
}