using System.Collections.Generic;
using TwitchLib;
using TwitchLib.Models.API.v5.Bits;

namespace NuffLib.Core.Models.Cheers
{
  public static class TwitchCheerController
  {
    public static readonly Dictionary<string, TwitchCheerEmote> prefixes = new Dictionary<string, TwitchCheerEmote>();

    static TwitchCheerController()
    {
      Cheermotes cheermotes = TwitchAPI.Bits.v5.GetCheermotesAsync(TwitchBot.Instance.JoinedChannel.Id).Result;

      foreach (Action action in cheermotes.Actions)
      {
        Dictionary<TwitchCheerTier, TwitchCheerEmote> emotes = new Dictionary<TwitchCheerTier, TwitchCheerEmote>();

        foreach (Tier tier in action.Tiers)
        {
          //TwitchCheerTier cheerTier = new TwitchCheerTier(tier);

          //emotes.Add(cheerTier, new TwitchCheerEmote(action.Prefix, cheerTier));
        }

        //prefixes.Add(action.Prefix, emotes);
      }
    }
  }
}