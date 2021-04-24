using OnionSquadTeamProject.Api.ViewModel;

namespace OnionSquadTeamProject.Api.Structures
{
  public class SendMailRequest
  {
    public UserViewModel Sender { get; set; }
    public SendingMailViewModel MailViewModel { get; set; }
  }
}