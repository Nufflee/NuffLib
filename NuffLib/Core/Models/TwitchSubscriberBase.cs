using TwitchLib;
using TwitchLib.Enums;
using TwitchLib.Models.Client;

namespace NuffLib.Core.Models
{
  public abstract class TwitchSubscriberBase : TwitchUser
  {
    /// <summary>
    /// User's subscription plan
    /// </summary>
    public SubscriptionPlan Plan => subscriberBase.SubscriptionPlan;

    private readonly SubscriberBase subscriberBase;

    internal TwitchSubscriberBase(SubscriberBase subscriberBase)
      : base(TwitchAPI.Users.v5.GetUserByIDAsync(subscriberBase.Id).Result)
    {
      this.subscriberBase = subscriberBase;
    }
  }
}