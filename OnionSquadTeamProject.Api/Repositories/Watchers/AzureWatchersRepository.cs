using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using OnionSquadTeamProject.Api.Models;

namespace OnionSquadTeamProject.Api.Repositories.Watchers
{
  public class AzureWatchersRepository: IWatchersRepository
  {
    private readonly Container _container;
    private int _idCounter;

    public AzureWatchersRepository(CosmosClient dbClient, string databaseName, string containerName)
    {
      _container = dbClient.GetContainer(databaseName, containerName);
      _idCounter = 1;
    }

    public async Task<List<WatcherModel>> GetAllWatchers(int parentId)
    {
      FeedIterator<WatcherModel> query = _container.GetItemQueryIterator<WatcherModel>(
        new QueryDefinition($"SELECT * FROM Watchers WHERE Watchers.ParentId = {parentId}"));
      List<WatcherModel> results = new();
      while (query.HasMoreResults)
      {
        FeedResponse<WatcherModel> response = await query.ReadNextAsync();

        results.AddRange(response.ToList());
      }

      return results;
    }

    public async Task<WatcherModel> AddNewWatcher(int parentId, string name, string email)
    {
      WatcherModel item = new()
      {
        Email = email,
        Name = name,
        ParentId = parentId,
        Id = _idCounter
      };
      _idCounter++;
      
      await _container.CreateItemAsync(item, new PartitionKey(item.Id));
      return item;
    }

    public Task<bool> RemoveWatcher(int watcherId)
    {
      throw new System.NotImplementedException();
    }
  }
}