using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild
{
    public class GuildModificationStartedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6324;

        public GuildModificationStartedMessage(bool canChangeName, bool canChangeEmblem)
        {
            CanChangeName = canChangeName;
            CanChangeEmblem = canChangeEmblem;
        }

        public GuildModificationStartedMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool CanChangeName { get; set; }
        public bool CanChangeEmblem { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, CanChangeName);
            flag = BooleanByteWrapper.SetFlag(1, flag, CanChangeEmblem);
            writer.WriteByte(flag);
        }

        public override void Deserialize(IDataReader reader)
        {
            var flag = reader.ReadByte();
            CanChangeName = BooleanByteWrapper.GetFlag(flag, 0);
            CanChangeEmblem = BooleanByteWrapper.GetFlag(flag, 1);
        }
    }
}