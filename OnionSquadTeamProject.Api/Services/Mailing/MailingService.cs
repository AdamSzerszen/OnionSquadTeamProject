using System;
using System.Threading.Tasks;
using OnionSquadTeamProject.Api.Services.Sending;
using OnionSquadTeamProject.Api.Structures;
using OnionSquadTeamProject.Api.ViewModel;
using RestSharp;
using RestSharp.Authenticators;

namespace OnionSquadTeamProject.Api.Services.Mailing
{
  public class MailingService : IMailingService
  {
    private readonly ISendingService _sendingService;

    public MailingService(ISendingService sendingService)
    {
      _sendingService = sendingService;
    }

    public async Task<SendingResponse> SendMail(UserViewModel userViewModel, SendingMailViewModel mailViewModel)
    {

      RestClient client = new RestClient
      {
        BaseUrl = new Uri("https://api.mailgun.net/v3"),
        Authenticator = new HttpBasicAuthenticator("api", "YOUR_API_KEY")
      };
      RestRequest request = new RestRequest();
      request.AddParameter ("domain", "YOUR_DOMAIN_NAME", ParameterType.UrlSegment);
      request.Resource = "{domain}/messages";
      request.AddParameter ("from", "Excited User <mailgun@YOUR_DOMAIN_NAME>");
      request.AddParameter ("to", "bar@example.com");
      request.AddParameter ("subject", "Hello");
      request.AddParameter ("text", "Testing some Mailgun awesomness!");
      request.Method = Method.POST;
      IRestResponse restResponse = await client.ExecuteAsync (request);

      return new SendingResponse
      {
        Content = restResponse.Content,
        Success = restResponse.IsSuccessful
      };
    }
  }
}