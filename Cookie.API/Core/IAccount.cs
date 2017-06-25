using Cookie.API.Core.Frames;

namespace Cookie.API.Core
{
    public interface IAccount
    {
        string Login { get; set; }
        string Password { get; set; }
        IDofusClient Client { get; set; }

        int Id { get; set; }
        string Ticket { get; set; }
        string Nickname { get; set; }
        string SecretQuestion { get; set; }
        double AccountCreation { get; set; }
        byte CommunityId { get; set; }
        double SubscriptionElapsedDuration { get; set; }
        double SubscriptionEndDate { get; set; }

        ICharacter Character { get; set; }

        ILatencyFrame LatencyFrame { get; set; }
    }
}