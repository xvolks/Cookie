using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    public class AllianceFactsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6409;

        public AllianceFactsRequestMessage(uint allianceId)
        {
            AllianceId = allianceId;
        }

        public AllianceFactsRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public uint AllianceId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(AllianceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            AllianceId = reader.ReadVarUhInt();
        }
    }
}