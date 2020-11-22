using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IdentificationSuccessWithLoginTokenMessage : IdentificationSuccessMessage
    {
        public new const uint ProtocolId = 6209;
        public override uint MessageID { get { return ProtocolId; } }

        public string LoginToken;

        public IdentificationSuccessWithLoginTokenMessage(): base()
        {
        }

        public IdentificationSuccessWithLoginTokenMessage(
            bool hasRights,
            bool wasAlreadyConnected,
            string login,
            string nickname,
            int accountId,
            byte communityId,
            string secretQuestion,
            double accountCreation,
            double subscriptionElapsedDuration,
            double subscriptionEndDate,
            byte havenbagAvailableRoom,
            string loginToken
        ): base(
            hasRights,
            wasAlreadyConnected,
            login,
            nickname,
            accountId,
            communityId,
            secretQuestion,
            accountCreation,
            subscriptionElapsedDuration,
            subscriptionEndDate,
            havenbagAvailableRoom
        )
        {
            LoginToken = loginToken;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(LoginToken);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            LoginToken = reader.ReadUTF();
        }
    }
}