using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Types
{
    public class BasicAllianceInformations : AbstractSocialGroupInfos
    {
        public new const short ProtocolId = 419;
        public override short TypeId { get { return ProtocolId; } }

        public int AllianceId = 0;
        public string AllianceTag;

        public BasicAllianceInformations(): base()
        {
        }

        public BasicAllianceInformations(
            int allianceId,
            string allianceTag
        ): base()
        {
            AllianceId = allianceId;
            AllianceTag = allianceTag;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(AllianceId);
            writer.WriteUTF(AllianceTag);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            AllianceId = reader.ReadVarInt();
            AllianceTag = reader.ReadUTF();
        }
    }
}