using System;

namespace NuffLib.Core.Events
{
  public class LogEventArgs : EventArgs
  {
    public string data;
    public DateTime dateTime;

    public LogEventArgs(string data, DateTime dateTime)
    {
      this.data = data;
      this.dateTime = dateTime;
    }
  }
}