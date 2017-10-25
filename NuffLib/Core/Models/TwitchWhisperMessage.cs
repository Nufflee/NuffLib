using System.Collections.Generic;
using TwitchLib.Models.Client;

namespace NuffLib.Core.Models
{
  public class TwitchWhisperMessage : TwitchMessageBase
  {
    public override TwitchUser Sender => new TwitchUser(whisperMessage.Username);
    public override string Text => whisperMessage.Message;

    public override List<EmoteSet.Emote> Emotes => whisperMessage.EmoteSet.Emotes.Count > 0 ? whisperMessage.EmoteSet.Emotes : null;

    private readonly WhisperMessage whisperMessage;

    internal TwitchWhisperMessage(WhisperMessage whisperMessage)
    {
      this.whisperMessage = whisperMessage;
    }
  }
}