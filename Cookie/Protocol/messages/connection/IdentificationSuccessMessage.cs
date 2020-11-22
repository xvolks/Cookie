using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IdentificationSuccessMessage : NetworkMessage
    {
        public const uint ProtocolId = 22;
        public override uint MessageID { get { return ProtocolId; } }

        public bool HasRights = false;
        public bool WasAlreadyConnected = false;
        public string Login;
        public string Nickname;
        public int AccountId = 0;
        public byte CommunityId = 0;
        public string SecretQuestion;
        public double AccountCreation = 0;
        public double SubscriptionElapsedDuration = 0;
        public double SubscriptionEndDate = 0;
        public byte HavenbagAvailableRoom = 0;

        public IdentificationSuccessMessage()
        {
        }

        public IdentificationSuccessMessage(
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
            byte havenbagAvailableRoom
        )
        {
            HasRights = hasRights;
            WasAlreadyConnected = wasAlreadyConnected;
            Login = login;
            Nickname = nickname;
            AccountId = accountId;
            CommunityId = communityId;
            SecretQuestion = secretQuestion;
            AccountCreation = accountCreation;
            SubscriptionElapsedDuration = subscriptionElapsedDuration;
            SubscriptionEndDate = subscriptionEndDate;
            HavenbagAvailableRoom = havenbagAvailableRoom;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, HasRights);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, WasAlreadyConnected);
            writer.WriteByte(box0);
            writer.WriteUTF(Login);
            writer.WriteUTF(Nickname);
            writer.WriteInt(AccountId);
            writer.WriteByte(CommunityId);
            writer.WriteUTF(SecretQuestion);
            writer.WriteDouble(AccountCreation);
            writer.WriteDouble(SubscriptionElapsedDuration);
            writer.WriteDouble(SubscriptionEndDate);
            writer.WriteByte(HavenbagAvailableRoom);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            HasRights = BooleanByteWrapper.GetFlag(box0, 1);
            WasAlreadyConnected = BooleanByteWrapper.GetFlag(box0, 2);
            Login = reader.ReadUTF();
            Nickname = reader.ReadUTF();
            AccountId = reader.ReadInt();
            CommunityId = reader.ReadByte();
            SecretQuestion = reader.ReadUTF();
            AccountCreation = reader.ReadDouble();
            SubscriptionElapsedDuration = reader.ReadDouble();
            SubscriptionEndDate = reader.ReadDouble();
            HavenbagAvailableRoom = reader.ReadByte();
        }
    }
}