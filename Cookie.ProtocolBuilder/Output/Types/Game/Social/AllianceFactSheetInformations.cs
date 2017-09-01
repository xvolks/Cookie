namespace Cookie.API.Protocol.Network.Types.Game.Social
{
    using Types.Game.Context.Roleplay;
    using Types.Game.Guild;
    using Utils.IO;

    public class AllianceFactSheetInformations : AllianceInformations
    {
        public new const ushort ProtocolId = 421;
        public override ushort TypeID => ProtocolId;
        public int CreationDate { get; set; }

        public AllianceFactSheetInformations(int creationDate)
        {
            CreationDate = creationDate;
        }

        public AllianceFactSheetInformations() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(CreationDate);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            CreationDate = reader.ReadInt();
        }

    }
}
