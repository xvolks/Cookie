using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AccountCapabilitiesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6216;

        public override ushort MessageID => ProtocolId;

        public bool TutorialAvailable { get; set; }
        public bool CanCreateNewCharacter { get; set; }
        public int AccountId { get; set; }
        public uint BreedsVisible { get; set; }
        public uint BreedsAvailable { get; set; }
        public sbyte Status { get; set; }
        public double UnlimitedRestatEndDate { get; set; }
        public AccountCapabilitiesMessage() { }

        public AccountCapabilitiesMessage( bool TutorialAvailable, bool CanCreateNewCharacter, int AccountId, uint BreedsVisible, uint BreedsAvailable, sbyte Status, double UnlimitedRestatEndDate ){
            this.TutorialAvailable = TutorialAvailable;
            this.CanCreateNewCharacter = CanCreateNewCharacter;
            this.AccountId = AccountId;
            this.BreedsVisible = BreedsVisible;
            this.BreedsAvailable = BreedsAvailable;
            this.Status = Status;
            this.UnlimitedRestatEndDate = UnlimitedRestatEndDate;
        }

        public override void Serialize(IDataWriter writer)
        {
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, TutorialAvailable);
			flag = BooleanByteWrapper.SetFlag(1, flag, CanCreateNewCharacter);
			writer.WriteByte(flag);
            writer.WriteInt(AccountId);
            writer.WriteVarUhInt(BreedsVisible);
            writer.WriteVarUhInt(BreedsAvailable);
            writer.WriteSByte(Status);
            writer.WriteDouble(UnlimitedRestatEndDate);
        }

        public override void Deserialize(IDataReader reader)
        {
			var flag = reader.ReadByte();
			TutorialAvailable = BooleanByteWrapper.GetFlag(flag, 0);;
			CanCreateNewCharacter = BooleanByteWrapper.GetFlag(flag, 1);;
            AccountId = reader.ReadInt();
            BreedsVisible = reader.ReadVarUhInt();
            BreedsAvailable = reader.ReadVarUhInt();
            Status = reader.ReadSByte();
            UnlimitedRestatEndDate = reader.ReadDouble();
        }
    }
}
