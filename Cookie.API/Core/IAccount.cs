using Cookie.API.Core.Frame;

namespace Cookie.API.Core
{
    public interface IAccount
    {
        int Id { get; set; }
        string Ticket { get; set; }
        string Nickname { get; set; }
        string SecretQuestion { get; set; }
        double AccountCreation { get; set; }
        byte CommunityId { get; set; }
        double SubscriptionElapsedDuration { get; set; }
        double SubscriptionEndDate { get; set; }

        ICharacter Character { get; set; }

        string Login { get; set; }
        string Password { get; set; }

        ILatencyFrame LatencyFrame { get; set; }
    }
}
