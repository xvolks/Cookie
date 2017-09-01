namespace Cookie.API.Protocol.Network.Messages.Game.Alliance
{
    using Utils.IO;

    public class AllianceFactsErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6423;
        public override ushort MessageID => ProtocolId;
        public uint AllianceId { get; set; }

        public AllianceFactsErrorMessage(uint allianceId)
        {
            AllianceId = allianceId;
        }

        public AllianceFactsErrorMessage() { }

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
