using TwitchLib.Models.Client;

namespace NuffLib.Core.Models
{
  public class TwitchReSubscriber : TwitchSubscriberBase
  {
    /// <summary>
    /// Number of months that user has been subscribed for
    /// </summary>
    public int Months => reSubscriber.Months;

    private readonly ReSubscriber reSubscriber;

    internal TwitchReSubscriber(ReSubscriber reSubscriber)
      : base(reSubscriber)
    {
      this.reSubscriber = reSubscriber;
    }
  }
}