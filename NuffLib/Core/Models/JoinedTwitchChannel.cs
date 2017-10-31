using System.Collections.Generic;
using System.Linq;

namespace NuffLib.Core.Models
{
  public class JoinedTwitchChannel : TwitchChannel
  {
    internal JoinedTwitchChannel(string name)
      : base(name)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="title"></param>
    public async void SetTitle(string title)
    {
      await TwitchBot.Instance.Api.Channels.v5.UpdateChannelAsync(Id, title, authToken: TwitchBot.Instance.Credentials.OAuthToken);
    }

    public async void SetGame(string game)
    {
      await TwitchBot.Instance.Api.Channels.v5.UpdateChannelAsync(Id, game: game, authToken: TwitchBot.Instance.Credentials.OAuthToken);
    }

    public async void SetCommunitiesById(string community1, string community2 = null, string community3 = null)
    {
      await TwitchBot.Instance.Api.Channels.v5.SetChannelCommunitiesAsync(Id, new List<string>() {community1, community2, community3}.Where((element, index) => element != null).ToList(), authToken: TwitchBot.Instance.Credentials.OAuthToken);
    }
  }
}