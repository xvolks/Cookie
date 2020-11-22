using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class BasicNamedAllianceInformations : BasicAllianceInformations
    {
        public new const short ProtocolId = 418;
        public override short TypeId { get { return ProtocolId; } }

        public string AllianceName;

        public BasicNamedAllianceInformations(): base()
        {
        }

        public BasicNamedAllianceInformations(
            int allianceId,
            string allianceTag,
            string allianceName
        ): base(
            allianceId,
            allianceTag
        )
        {
            AllianceName = allianceName;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteUTF(AllianceName);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            AllianceName = reader.ReadUTF();
        }
    }
}