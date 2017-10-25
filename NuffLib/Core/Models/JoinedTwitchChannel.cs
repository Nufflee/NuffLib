using System.Collections.Generic;
using System.Linq;
using TwitchLib;

namespace NuffLib.Core.Models
{
  public class JoinedTwitchChannel : TwitchChannel
  {
    internal JoinedTwitchChannel(string name)
      : base(name)
    {
    }

    public async void SetTitle(string title)
    {
      await TwitchAPI.Channels.v5.UpdateChannelAsync(Id, title, authToken: TwitchBot.Instance.Credentials.OAuthToken);
    }

    public async void SetGame(string game)
    {
      await TwitchAPI.Channels.v5.UpdateChannelAsync(Id, game: game, authToken: TwitchBot.Instance.Credentials.OAuthToken);
    }

    /// <summary>
    /// Sets channel's communities by name.
    /// </summary>
    /// <param name="community1">First community's name.</param>
    /// <param name="community2">Second community's name (if null then preserve current).</param>
    /// <param name="community3">Third community's name (if null then preserve current).</param>
    public async void SetCommunities(string community1, string community2 = null, string community3 = null)
    {
      string com1Id = TwitchAPI.Communities.v5.GetCommunityByNameAsync(community1).Result.Id;
      string com2Id = TwitchAPI.Communities.v5.GetCommunityByNameAsync(community2).Result.Id;
      string com3Id = TwitchAPI.Communities.v5.GetCommunityByNameAsync(community3).Result.Id;
      await TwitchAPI.Channels.v5.SetChannelCommunitiesAsync(Id, new List<string>() { com2Id, com3Id }, authToken: TwitchBot.Instance.Credentials.OAuthToken);
    }

    public async void SetCommunitiesById(string community1, string community2 = null, string community3 = null)
    {
      await TwitchAPI.Channels.v5.SetChannelCommunitiesAsync(Id, new List<string>() { community1, community2, community3 }.Where((element, index) => element != null).ToList(), authToken: TwitchBot.Instance.Credentials.OAuthToken);
    }
  }
}