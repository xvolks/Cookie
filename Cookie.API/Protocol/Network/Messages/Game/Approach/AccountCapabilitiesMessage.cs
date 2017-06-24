using Cookie.API.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Approach
{
    public class AccountCapabilitiesMessage : NetworkMessage
    {
        public const uint ProtocolId = 6216;

        public int AccountId;
        public uint BreedsAvailable;
        public uint BreedsVisible;
        public bool CanCreateNewCharacter;
        public byte Status;
        public bool TutorialAvailable;

        public AccountCapabilitiesMessage()
        {
        }

        public AccountCapabilitiesMessage(int accountId, bool tutorialAvailable, uint breedsVisible,
            uint breedsAvailable, byte status, bool canCreateNewCharacter)
        {
            AccountId = accountId;
            TutorialAvailable = tutorialAvailable;
            BreedsVisible = breedsVisible;
            BreedsAvailable = breedsAvailable;
            Status = status;
            CanCreateNewCharacter = canCreateNewCharacter;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            var flag = new byte();
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
            var flag = reader.ReadByte();
            TutorialAvailable = BooleanByteWrapper.GetFlag(flag, 0);
            CanCreateNewCharacter = BooleanByteWrapper.GetFlag(flag, 1);
            AccountId = reader.ReadInt();
            BreedsVisible = reader.ReadVarUhInt();
            BreedsAvailable = reader.ReadVarUhInt();
            Status = reader.ReadByte();
        }
    }
}