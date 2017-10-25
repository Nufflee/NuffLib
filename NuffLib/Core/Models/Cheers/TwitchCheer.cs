using System.Collections.Generic;
using TwitchLib.Models.Client;

namespace NuffLib.Core.Models.Cheers
{
  public class TwitchCheer
  {
    public int BitAmount { get; }
    public string Prefix { get; }
    public CheerBadge Badge => new CheerBadge(BitAmount);
    public TwitchCheerEmote CheerEmote { get; private set; }

    internal TwitchCheer(string prefix, int bitAmount, TwitchCheerEmote emote)
    {
      BitAmount = bitAmount;
      Prefix = prefix.ToLower();
    }

    public int ToDollars()
    {
      return BitAmount / 100;
    }

    internal static List<TwitchCheer> TryGetCheers(TwitchChatMessage chatMessage)
    {
      List<TwitchCheer> cheers = new List<TwitchCheer>();
      string[] parts = chatMessage.Text.ToLower().Split(" ");

      foreach (string part in parts)
      {
        foreach (KeyValuePair<string, TwitchCheerEmote> prefix in TwitchCheerController.prefixes)
        {
          if (part.Contains(prefix.Key))
          {
            string possibleBitAmount = part.Replace(prefix.Key, "");

            if (int.TryParse(possibleBitAmount, out int bitAmount))
            {
              //cheers.Add(new TwitchCheer(prefix.Key, bitAmount, prefix.Value[GetTier(bitAmount)]));
            }
          }
        }
      }

      return cheers;
    }

    private static TwitchCheerTier GetTier(int bitAmount)
    {
      if (bitAmount < 100)
      {
        //return new TwitchCheerTier();
      }

      return null;
    }
  }
}