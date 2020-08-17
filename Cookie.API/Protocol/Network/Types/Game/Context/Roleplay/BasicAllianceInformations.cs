using Cookie.API.Protocol.Network.Types.Game.Social;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class BasicAllianceInformations : AbstractSocialGroupInfos
    {
        public new const ushort ProtocolId = 419;

        public BasicAllianceInformations(uint allianceId, string allianceTag)
        {
            AllianceId = allianceId;
            AllianceTag = allianceTag;
        }

        public BasicAllianceInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public uint AllianceId { get; set; }
        public string AllianceTag { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(AllianceId);
            writer.WriteUTF(AllianceTag);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            AllianceId = reader.ReadVarUhInt();
            AllianceTag = reader.ReadUTF();
        }
    }
}