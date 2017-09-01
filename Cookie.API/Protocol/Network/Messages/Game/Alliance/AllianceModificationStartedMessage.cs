using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceModificationStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6444;

        public AllianceModificationStartedMessage(bool canChangeName, bool canChangeTag, bool canChangeEmblem)
        {
            CanChangeName = canChangeName;
            CanChangeTag = canChangeTag;
            CanChangeEmblem = canChangeEmblem;
        }

        public AllianceModificationStartedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool CanChangeName { get; set; }
        public bool CanChangeTag { get; set; }
        public bool CanChangeEmblem { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, CanChangeName);
            flag = BooleanByteWrapper.SetFlag(1, flag, CanChangeTag);
            flag = BooleanByteWrapper.SetFlag(2, flag, CanChangeEmblem);
            writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            CanChangeName = BooleanByteWrapper.GetFlag(flag, 0);
            CanChangeTag = BooleanByteWrapper.GetFlag(flag, 1);
            CanChangeEmblem = BooleanByteWrapper.GetFlag(flag, 2);
        }
    }
}