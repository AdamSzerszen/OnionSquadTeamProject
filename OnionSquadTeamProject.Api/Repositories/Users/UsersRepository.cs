using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using OnionSquadTeamProject.Api.Models;

namespace OnionSquadTeamProject.Api.Repositories.Users
{
  public class UsersRepository: IUsersRepository
  {
    private readonly Container _container;
    private int _idCounter;

    public UsersRepository(CosmosClient dbClient, string databaseName, string containerName)
    {
      _container = dbClient.GetContainer(databaseName, containerName);
      _idCounter = 1;
    }

    public async Task<UserModel> GetUser(string name, string password)
    {
      FeedIterator<UserModel> query = _container.GetItemQueryIterator<UserModel>(
        new QueryDefinition($"SELECT * FROM Users WHERE Users.FirstName = {name} AND Users.Password = {password}"));
      if (!query.HasMoreResults)
      {
        return null;
      }

      FeedResponse<UserModel> response = await query.ReadNextAsync();
      return response.ToList().First();

    }

    public async Task AddUser(string name, string password)
    {
      UserModel item = new()
      {
        Id = _idCounter,
        FirstName = name,
        Password = password
      };
      
      await _container.CreateItemAsync(item, new PartitionKey(item.Id));
    }

    public void RemoveUser(int userId)
    {
    }
  }
}