using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.TreasureHunt
{
    public class TreasureHuntLegendaryRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6499;

        public TreasureHuntLegendaryRequestMessage(ushort legendaryId)
        {
            LegendaryId = legendaryId;
        }

        public TreasureHuntLegendaryRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort LegendaryId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(LegendaryId);
        }

        public override void Deserialize(IDataReader reader)
        {
            LegendaryId = reader.ReadVarUhShort();
        }
    }
}