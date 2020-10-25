using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class AllianceFactSheetInformations : AllianceInformations
    {
        public new const short ProtocolId = 421;
        public override short TypeId { get { return ProtocolId; } }

        public int CreationDate = 0;

        public AllianceFactSheetInformations(): base()
        {
        }

        public AllianceFactSheetInformations(
            int allianceId,
            string allianceTag,
            string allianceName,
            GuildEmblem allianceEmblem,
            int creationDate
        ): base(
            allianceId,
            allianceTag,
            allianceName,
            allianceEmblem
        )
        {
            CreationDate = creationDate;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteInt(CreationDate);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            CreationDate = reader.ReadInt();
        }
    }
}