using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    public class PrismFightStateUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6040;

        public PrismFightStateUpdateMessage(byte state)
        {
            State = state;
        }

        public PrismFightStateUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte State { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            State = reader.ReadByte();
        }
    }
}