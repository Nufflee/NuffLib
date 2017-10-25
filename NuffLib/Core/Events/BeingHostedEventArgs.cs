using System;
using NuffLib.Core.Models;

namespace NuffLib.Core.Events
{
  public class BeingHostedEventArgs : EventArgs
  {
    public TwitchChannel channel;
    public TwitchChannel hostedByChannel;
    public int viewers;
    public bool isAutoHost;

    public BeingHostedEventArgs(TwitchChannel channel, TwitchChannel hostedByChannel, int viewers, bool isAutoHost)
    {
      this.channel = channel;
      this.hostedByChannel = hostedByChannel;
      this.viewers = viewers;
      this.isAutoHost = isAutoHost;
    }
  }
}