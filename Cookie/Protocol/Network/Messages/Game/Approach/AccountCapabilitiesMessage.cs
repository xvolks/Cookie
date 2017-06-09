using Cookie.IO;


namespace Cookie.Protocol.Network.Messages.Game.Approach
{
    class AccountCapabilitiesMessage : NetworkMessage
    {
        public const uint ProtocolId = 6216;
        public override uint MessageID { get { return ProtocolId; } }

        public int AccountId;
        public bool TutorialAvailable;
        public uint BreedsVisible;
        public uint BreedsAvailable;
        public byte Status;
        public bool CanCreateNewCharacter;

        public AccountCapabilitiesMessage() { }

        public AccountCapabilitiesMessage(int accountId, bool tutorialAvailable, uint breedsVisible, uint breedsAvailable, byte status, bool canCreateNewCharacter)
        {
            AccountId = accountId;
            TutorialAvailable = tutorialAvailable;
            BreedsVisible = breedsVisible;
            BreedsAvailable = breedsAvailable;
            Status = status;
            CanCreateNewCharacter = canCreateNewCharacter;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            byte flag = new byte();
            BooleanByteWrapper.SetFlag(0, flag, TutorialAvailable);
            BooleanByteWrapper.SetFlag(1, flag, CanCreateNewCharacter);
            writer.WriteByte(flag);
            writer.WriteInt(AccountId);
            writer.WriteVarUhInt(BreedsVisible);
            writer.WriteVarUhInt(BreedsAvailable);
            writer.WriteByte(Status);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            byte flag = reader.ReadByte();
            TutorialAvailable = BooleanByteWrapper.GetFlag(flag, 0);
            CanCreateNewCharacter = BooleanByteWrapper.GetFlag(flag, 1);
            AccountId = reader.ReadInt();
            BreedsVisible = reader.ReadVarUhInt();
            BreedsAvailable = reader.ReadVarUhInt();
            Status = reader.ReadByte();
        }
    }
}
