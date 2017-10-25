using System;
using NuffLib.Core.Models;

namespace NuffLib.Core.Events
{
  public class MessageRecievedEventArgs : EventArgs
  {
    public TwitchChatMessage message;

    public MessageRecievedEventArgs(TwitchChatMessage message)
    {
      this.message = message;
    }
  }
}