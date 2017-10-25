using TwitchLib.Models.Client;

namespace NuffLib
{
  public class TwitchCredentials
  {
    public string ClientId { get; }

    private readonly ConnectionCredentials credentials;

    public TwitchCredentials(string username, string oAuthToken, string clientId)
    {
      credentials = new ConnectionCredentials(username, oAuthToken);
      ClientId = clientId;
    }

    public static implicit operator ConnectionCredentials(TwitchCredentials credentials)
    {
      return credentials.credentials;
    }
  }
}