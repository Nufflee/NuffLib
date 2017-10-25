using System;

namespace NuffLib.Core.Events
{
  public delegate void TwitchBotEventHandler<in TEventArgs>(TwitchBot bot, TEventArgs args)
    where TEventArgs : EventArgs;
}