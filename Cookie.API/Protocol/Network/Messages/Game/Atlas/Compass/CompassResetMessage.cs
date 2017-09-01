using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Atlas.Compass
{
    public class CompassResetMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5584;

        public CompassResetMessage(byte type)
        {
            Type = type;
        }

        public CompassResetMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Type { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Type);
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadByte();
        }
    }
}