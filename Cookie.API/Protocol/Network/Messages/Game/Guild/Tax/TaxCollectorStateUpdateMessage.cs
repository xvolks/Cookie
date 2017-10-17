using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Guild.Tax
{
    public class TaxCollectorStateUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6455;

        public TaxCollectorStateUpdateMessage(double uniqueId, sbyte state)
        {
            UniqueId = uniqueId;
            State = state;
        }

        public TaxCollectorStateUpdateMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public double UniqueId { get; set; }
        public sbyte State { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(UniqueId);
            writer.WriteSByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            UniqueId = reader.ReadDouble();
            State = reader.ReadSByte();
        }
    }
}