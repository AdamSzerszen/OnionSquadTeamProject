using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnionSquadTeamProject.Api.Authentication;
using OnionSquadTeamProject.Api.Models;
using OnionSquadTeamProject.Api.Repositories.Users;
using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Services.Authentication
{
  public class UserService : IUserService
  {
    private readonly AppSettings _appSettings;
    private readonly IUsersRepository _usersRepository;

    public UserService(IOptions<AppSettings> appSettings, IUsersRepository usersRepository)
    {
      _usersRepository = usersRepository;
      _appSettings = appSettings.Value;
    }

    public async Task<bool> IsUserValid(UserViewModel userViewModel)
    {
      await Task.Delay(1);
      return true;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
    {
      UserModel user = await _usersRepository.GetUser(model.Username, model.Password);
      // _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

      // return null if user not found
      if (user == null) return null;

      UserViewModel userViewModel = new UserViewModel
      {
        Id = user.Id,
        Name = user.FirstName
      };
      
      // authentication successful so generate jwt token
      var token = GenerateJwtToken(userViewModel);

      return new AuthenticateResponse(userViewModel, token);
    }

    public async Task Create(RegisterUserModel user, string password)
    {
      await _usersRepository.AddUser(user.Name, user.Password);
    }

    public async Task<UserViewModel> GetUserById(int userId)
    {
      await Task.Delay(1);
      return new UserViewModel
      {
        Id = userId,
        Name = "Miś"
      };
    }

    private string GenerateJwtToken(UserViewModel user)
    {
      // generate token that is valid for 7 days
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new[] {new Claim("id", user.Id.ToString())}),
        Expires = DateTime.UtcNow.AddDays(7),
        SigningCredentials =
          new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };
      var token = tokenHandler.CreateToken(tokenDescriptor);
      return tokenHandler.WriteToken(token);
    }
  }
}