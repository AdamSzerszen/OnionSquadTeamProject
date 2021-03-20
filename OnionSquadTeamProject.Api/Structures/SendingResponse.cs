using System;

namespace OnionSquadTeamProject.Api.Structures
{
  public class SendingResponse
  {
    public DateTime SentTime { get; set; }
    public bool AllSentWithSuccess { get; set; }
  }
}