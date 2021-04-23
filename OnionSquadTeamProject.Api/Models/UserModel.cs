using System.Text.Json.Serialization;

namespace OnionSquadTeamProject.Api.Models
{
  public class UserModel: BaseModel
  {
    public string FirstName { get; set; }
    [JsonIgnore]
    public string Password { get; set; }
  }
}