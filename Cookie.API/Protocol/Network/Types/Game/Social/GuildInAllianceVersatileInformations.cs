using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Social
{
    public class GuildInAllianceVersatileInformations : GuildVersatileInformations
    {
        public new const ushort ProtocolId = 437;

        public GuildInAllianceVersatileInformations(uint allianceId)
        {
            AllianceId = allianceId;
        }

        public GuildInAllianceVersatileInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint AllianceId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(AllianceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceId = reader.ReadVarUhInt();
        }
    }
}