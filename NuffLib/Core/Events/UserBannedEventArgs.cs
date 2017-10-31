using System;
using NuffLib.Core.Models;

namespace NuffLib.Core.Events
{
  public class UserBannedEventArgs : EventArgs
  {
    public TwitchUser user;
    public JoinedTwitchChannel channel;
    public string reason;

    public UserBannedEventArgs(string username, JoinedTwitchChannel channel, string reason)
    {
      user = new TwitchUser(username);
      this.channel = channel;
      this.reason = reason;
    }
  }
}