using System;
using NuffLib.Core.Models;

namespace NuffLib.Core.Events
{
  public class LeftChannelEventArgs : EventArgs
  {
    public JoinedTwitchChannel channel;

    public LeftChannelEventArgs(JoinedTwitchChannel channel)
    {
      this.channel = channel;
    }
  }
}