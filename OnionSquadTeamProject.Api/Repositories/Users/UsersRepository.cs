using System;
using System.Threading.Tasks;
using OnionSquadTeamProject.Api.Models;

namespace OnionSquadTeamProject.Api.Repositories.Users
{
  public class UsersRepository: IUsersRepository
  {
    public async Task<UserModel> GetUser(string name, string password)
    {
      await Task.Delay(1);
      return new UserModel();
    }

    public async Task AddUser(string name, string password)
    {
    }

    public void RemoveUser(int userId)
    {
    }
  }
}