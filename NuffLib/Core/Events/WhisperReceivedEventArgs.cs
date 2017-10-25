using System;
using NuffLib.Core.Models;
using TwitchLib.Models.Client;

namespace NuffLib.Core.Events
{
  public class WhisperReceivedEventArgs : EventArgs
  {
    public TwitchWhisperMessage whisperMessage;

    public WhisperReceivedEventArgs(WhisperMessage whisperMessage)
    {
      this.whisperMessage = new TwitchWhisperMessage(whisperMessage);
    }
  }
}