using System.Collections.Generic;
using TwitchLib;

namespace NuffLib.Core.Models
{
  public class JoinedTwitchChannel : TwitchChannel
  {
    /// <summary>
    /// Static instance of channel that the bot is currently in
    /// </summary>
    public static JoinedTwitchChannel Current { get; private set; }

    internal JoinedTwitchChannel(string name)
      : base(name)
    {
      Current = this;
    }

    internal void Leave()
    {
      Current = null;
    }

    public async void SetTitle(string title)
    {
      await TwitchAPI.Channels.v5.UpdateChannelAsync(Id, title);
    }

    public async void SetGame(string game)
    {
      await TwitchAPI.Channels.v5.UpdateChannelAsync(Id, game: game);
    }

    public async void SetCommunities(string community1, string community2, string community3)
    {
      await TwitchAPI.Channels.v5.SetChannelCommunitiesAsync(Id, new List<string>() {community1, community2, community3});
    }
  }
}