using TwitchLib.Models.API.v5.Channels;

namespace NuffLib.Core.Models
{
  public class TwitchChannel
  {
    /// <summary>
    /// Channel's display name
    /// </summary>
    public string Name => User.DisplayName;

    /// <summary>
    /// Channel owner
    /// </summary>
    public TwitchUser User { get; }

    /// <summary>
    /// Number of channel followers
    /// </summary>
    public int Followers => channel.Followers;

    /// <summary>
    /// Current channel game
    /// </summary>
    public string Game => channel.Game;

    /// <summary>
    /// Channel id
    /// </summary>
    public string Id => channel.Id.ToString();

    /// <summary>
    /// Current stream title
    /// </summary>
    public string Title => channel.Status;

    /// <summary>
    /// Channel's profile banner url
    /// </summary>
    public string ProfileBannerUrl => channel.ProfileBanner;

    /// <summary>
    /// Channel's logo url
    /// </summary>
    public string LogoUrl => channel.Logo;

    /// <summary>
    /// Channel's url
    /// </summary>
    public string Url => channel.Url;

    private readonly Channel channel;

    /// <summary>
    /// Creates new instance of TwitchChannel
    /// </summary>
    /// <param name="name">Channel's name</param>
    public TwitchChannel(string name)
    {
      User = new TwitchUser(name);
      channel = TwitchBot.Instance.Api.Channels.v5.GetChannelByIDAsync(User.Id).Result;
    }
  }
}