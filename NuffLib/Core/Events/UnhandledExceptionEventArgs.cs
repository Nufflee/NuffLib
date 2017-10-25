using System;

namespace NuffLib.Core.Events
{
  public class UnhandledExceptionEventArgs : EventArgs
  {
    public Exception exception;

    public UnhandledExceptionEventArgs(Exception exception)
    {
      this.exception = exception;
    }
  }
}