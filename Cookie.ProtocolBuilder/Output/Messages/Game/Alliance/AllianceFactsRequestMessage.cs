namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Utils.IO;

    public class AllianceFactsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6409;
        public override ushort MessageID => ProtocolId;
        public uint AllianceId { get; set; }

        public AllianceFactsRequestMessage(uint allianceId)
        {
            AllianceId = allianceId;
        }

        public AllianceFactsRequestMessage() { }

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
