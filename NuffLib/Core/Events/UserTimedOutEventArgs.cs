using System;
using NuffLib.Core.Models;

namespace NuffLib.Core.Events
{
  public class UserTimedOutEventArgs : EventArgs
  {
    public JoinedTwitchChannel channel;
    public TwitchUser user;
    public int timeOutDuration;
    public string timeOutReason;

    public UserTimedOutEventArgs(JoinedTwitchChannel channel, TwitchUser user, int timeOutDuration, string timeOutReason)
    {
      this.channel = channel;
      this.user = user;
      this.timeOutDuration = timeOutDuration;
      this.timeOutReason = timeOutReason;
    }
  }
}