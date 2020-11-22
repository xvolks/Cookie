using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AccountCapabilitiesMessage : NetworkMessage
    {
        public const uint ProtocolId = 6216;
        public override uint MessageID { get { return ProtocolId; } }

        public bool TutorialAvailable = false;
        public bool CanCreateNewCharacter = false;
        public int AccountId = 0;
        public int BreedsVisible = 0;
        public int BreedsAvailable = 0;
        public byte Status = unchecked((byte)-1);
        public double UnlimitedRestatEndDate = 0;

        public AccountCapabilitiesMessage()
        {
        }

        public AccountCapabilitiesMessage(
            bool tutorialAvailable,
            bool canCreateNewCharacter,
            int accountId,
            int breedsVisible,
            int breedsAvailable,
            byte status,
            double unlimitedRestatEndDate
        )
        {
            TutorialAvailable = tutorialAvailable;
            CanCreateNewCharacter = canCreateNewCharacter;
            AccountId = accountId;
            BreedsVisible = breedsVisible;
            BreedsAvailable = breedsAvailable;
            Status = status;
            UnlimitedRestatEndDate = unlimitedRestatEndDate;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, TutorialAvailable);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, CanCreateNewCharacter);
            writer.WriteByte(box0);
            writer.WriteInt(AccountId);
            writer.WriteVarInt(BreedsVisible);
            writer.WriteVarInt(BreedsAvailable);
            writer.WriteByte(Status);
            writer.WriteDouble(UnlimitedRestatEndDate);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte box0 = reader.ReadByte();
            TutorialAvailable = BooleanByteWrapper.GetFlag(box0, 1);
            CanCreateNewCharacter = BooleanByteWrapper.GetFlag(box0, 2);
            AccountId = reader.ReadInt();
            BreedsVisible = reader.ReadVarInt();
            BreedsAvailable = reader.ReadVarInt();
            Status = reader.ReadByte();
            UnlimitedRestatEndDate = reader.ReadDouble();
        }
    }
}