using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IdentificationSuccessMessage : NetworkMessage
    {
        public const ushort ProtocolId = 22;

        public override ushort MessageID => ProtocolId;

        public bool HasRights { get; set; }
        public bool WasAlreadyConnected { get; set; }
        public string Login { get; set; }
        public string Nickname { get; set; }
        public int AccountId { get; set; }
        public sbyte CommunityId { get; set; }
        public string SecretQuestion { get; set; }
        public double AccountCreation { get; set; }
        public double SubscriptionElapsedDuration { get; set; }
        public double SubscriptionEndDate { get; set; }
        public byte HavenbagAvailableRoom { get; set; }
        public IdentificationSuccessMessage() { }

        public IdentificationSuccessMessage( bool HasRights, bool WasAlreadyConnected, string Login, string Nickname, int AccountId, sbyte CommunityId, string SecretQuestion, double AccountCreation, double SubscriptionElapsedDuration, double SubscriptionEndDate, byte HavenbagAvailableRoom ){
            this.HasRights = HasRights;
            this.WasAlreadyConnected = WasAlreadyConnected;
            this.Login = Login;
            this.Nickname = Nickname;
            this.AccountId = AccountId;
            this.CommunityId = CommunityId;
            this.SecretQuestion = SecretQuestion;
            this.AccountCreation = AccountCreation;
            this.SubscriptionElapsedDuration = SubscriptionElapsedDuration;
            this.SubscriptionEndDate = SubscriptionEndDate;
            this.HavenbagAvailableRoom = HavenbagAvailableRoom;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, HasRights);
			flag = BooleanByteWrapper.SetFlag(1, flag, WasAlreadyConnected);
			writer.WriteByte(flag);
            writer.WriteUTF(Login);
            writer.WriteUTF(Nickname);
            writer.WriteInt(AccountId);
            writer.WriteSByte(CommunityId);
            writer.WriteUTF(SecretQuestion);
            writer.WriteDouble(AccountCreation);
            writer.WriteDouble(SubscriptionElapsedDuration);
            writer.WriteDouble(SubscriptionEndDate);
            writer.WriteByte(HavenbagAvailableRoom);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			HasRights = BooleanByteWrapper.GetFlag(flag, 0);;
			WasAlreadyConnected = BooleanByteWrapper.GetFlag(flag, 1);;
            Login = reader.ReadUTF();
            Nickname = reader.ReadUTF();
            AccountId = reader.ReadInt();
            CommunityId = reader.ReadSByte();
            SecretQuestion = reader.ReadUTF();
            AccountCreation = reader.ReadDouble();
            SubscriptionElapsedDuration = reader.ReadDouble();
            SubscriptionEndDate = reader.ReadDouble();
            HavenbagAvailableRoom = reader.ReadByte();
        }
    }
}
