using System.Collections.Generic;
using TwitchLib.Models.Client;

namespace NuffLib.Core.Models
{
  public abstract class TwitchMessageBase
  {
    /// <summary>
    /// User sending the message
    /// </summary>
    public abstract TwitchUser Sender { get; }

    /// <summary>
    /// Message text
    /// </summary>
    public abstract string Text { get; }

    /// <summary>
    /// Message emotes
    /// </summary>
    public abstract List<EmoteSet.Emote> Emotes { get; }
  }
}