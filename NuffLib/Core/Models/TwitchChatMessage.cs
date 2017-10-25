using System.Collections.Generic;
using NuffLib.Core.Models.Cheers;
using TwitchLib.Models.Client;

namespace NuffLib.Core.Models
{
  public class TwitchChatMessage : TwitchMessageBase
  {
    public override TwitchUser Sender => new TwitchUser(chatMessage.Username);

    /// <summary>
    /// Channel that the message is sent in
    /// </summary>
    public TwitchChannel Channel => new TwitchChannel(chatMessage.Channel);

    public override string Text => chatMessage.Message;

    public override List<EmoteSet.Emote> Emotes => chatMessage.EmoteSet.Emotes.Count > 0 ? chatMessage.EmoteSet.Emotes : null;

    /// <summary>
    /// Cheers in the message
    /// </summary>
    public List<TwitchCheer> Cheers => TwitchCheer.TryGetCheers(this);
    //public TwitchCheer TotalCheers => new TwitchCheer(,);

    private readonly ChatMessage chatMessage;

    internal TwitchChatMessage(ChatMessage chatMessage)
    {
      this.chatMessage = chatMessage;
    }

    public override string ToString()
    {
      return chatMessage.Message;
    }
  }
}