namespace NuffLib.Core.Models.Cheers
{
  public class TwitchCheerEmote
  {
    public TwitchCheerTier Tier { get; }

    public string Prefix { get; }
    //public TwitchCheerImages Images => Tier.

    public TwitchCheerEmote(string prefix, TwitchCheerTier tier)
    {
      Tier = tier;
      Prefix = prefix;
    }
  }
}