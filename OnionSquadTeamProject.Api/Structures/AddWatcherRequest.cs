using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Structures
{
  public class AddWatcherRequest
  {
    public UserViewModel Parent { get; set; }
    public WatcherViewModel Watcher { get; set; }
  }
}