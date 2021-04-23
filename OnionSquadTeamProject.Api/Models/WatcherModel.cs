using System;

namespace OnionSquadTeamProject.Api.Models
{
  public class WatcherModel: BaseModel
  {
    public string Name { get; set; }
    public string Email { get; set; }
    public int ParentId { get; set; }
  }
}