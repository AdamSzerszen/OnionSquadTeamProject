using System;
using System.Threading.Tasks;
using OnionSquadTeamProject.Api.Models;
using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Repositories.Users
{
  public interface IUsersRepository
  {
    Task<UserModel> GetUser(string name, string password);
    Task AddUser(string name, string password);
  }
}