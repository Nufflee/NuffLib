using System;
using NuffLib.Core.Events;
using UnhandledExceptionEventArgs = NuffLib.Core.Events.UnhandledExceptionEventArgs;

namespace NuffLib.Infrastructure
{
  public static class GlobalExceptionHandler
  {
    public static event EventHandler<UnhandledExceptionEventArgs> OnUnhandledException;

    static GlobalExceptionHandler()
    {
      AppDomain.CurrentDomain.UnhandledException += (sender, e) => OnUnhandledException?.Invoke(sender, new UnhandledExceptionEventArgs((Exception) e.ExceptionObject));
    }
  }
}