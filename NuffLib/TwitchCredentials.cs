using NuffLib.Core.Models;
using TwitchLib.Models.Client;

namespace NuffLib
{
  public class TwitchCredentials
  {
    /// <summary>
    /// User these credentials belong to
    /// </summary>
    public TwitchUser User => new TwitchUser(credentials.TwitchUsername);

    /// <summary>
    /// OAuth token
    /// </summary>
    public string OAuthToken => credentials.TwitchOAuth;

    /// <summary>
    /// Application client id
    /// </summary>
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