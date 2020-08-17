using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Social
{
    public class AllianceFactSheetInformations : AllianceInformations
    {
        public new const ushort ProtocolId = 421;

        public AllianceFactSheetInformations(int creationDate)
        {
            CreationDate = creationDate;
        }

        public AllianceFactSheetInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public int CreationDate { get; set; }

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