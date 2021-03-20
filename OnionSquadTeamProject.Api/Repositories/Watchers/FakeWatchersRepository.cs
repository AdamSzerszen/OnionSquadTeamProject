using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnionSquadTeamProject.Api.Models;

namespace OnionSquadTeamProject.Api.Repositories.Watchers
{
  public class FakeWatchersRepository : IWatchersRepository
  {
    private readonly List<WatcherModel> _watchers;

    public FakeWatchersRepository()
    {
      _watchers = new List<WatcherModel>();
    }

    public async Task<List<WatcherModel>> GetAllWatchers(Guid parentId)
    {
      await Task.Delay(1);
      return _watchers;
    }

    public async Task<WatcherModel> AddNewWatcher(Guid parentId, string name, string email)
    {
      WatcherModel watcherModel = new WatcherModel
      {
        Name = name,
        Email = email,
        ParentId = parentId,
        Id = new Guid()
      };
      
      _watchers.Add(watcherModel);
      await Task.Delay(1);

      return watcherModel;
    }

    public async Task<bool> RemoveWatcher(Guid watcherId)
    {
      WatcherModel watcher = _watchers.FirstOrDefault(w => w.Id == watcherId);
      bool wasWatcherRemoved = false;
      
      if (watcher != null)
      {
        _watchers.Remove(watcher);
        wasWatcherRemoved = true;
      }

      await Task.Delay(1);
      return wasWatcherRemoved;
    }
  }
}