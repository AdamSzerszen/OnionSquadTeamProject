using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnionSquadTeamProject.Api.Models;

namespace OnionSquadTeamProject.Api.Repositories.Watchers
{
  public interface IWatchersRepository
  {
    Task<List<WatcherModel>> GetAllWatchers(int parentId);
    Task<WatcherModel> AddNewWatcher(int parentId, string name, string email);
    Task<bool> RemoveWatcher(int watcherId);
  }
}