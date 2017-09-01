using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Mount
{
    public class MountDataErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6172;

        public MountDataErrorMessage(byte reason)
        {
            Reason = reason;
        }

        public MountDataErrorMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte Reason { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(Reason);
        }

        public override void Deserialize(IDataReader reader)
        {
            Reason = reader.ReadByte();
        }
    }
}