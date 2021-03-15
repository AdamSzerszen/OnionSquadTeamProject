using System;
using OnionSquadTeamProject.Api.Models;

namespace OnionSquadTeamProject.Api.Repositories.Users
{
  public class UsersRepository: IUsersRepository
  {
    public UserModel GetUser(Guid userId)
    {
      return new UserModel
      {
        Id = userId,
        FirstName = "TempUser"
      };
    }

    public void AddUser(Guid userId, string name)
    {
    }

    public void RemoveUser(Guid userId)
    {
    }
  }
}