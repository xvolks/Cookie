using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightOptionToggleMessage : NetworkMessage
    {
        public const ushort ProtocolId = 707;

        public GameFightOptionToggleMessage(byte option)
        {
            Option = option;
        }

        public GameFightOptionToggleMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Option { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Option);
        }

        public override void Deserialize(IDataReader reader)
        {
            Option = reader.ReadByte();
        }
    }
}