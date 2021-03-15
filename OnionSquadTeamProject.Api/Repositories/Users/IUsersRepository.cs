using System;
using OnionSquadTeamProject.Api.Models;

namespace OnionSquadTeamProject.Api.Repositories.Users
{
  public interface IUsersRepository
  {
    UserModel GetUser(Guid userId);
    void AddUser(Guid userId, string name);
    void RemoveUser(Guid userId);
  }
}