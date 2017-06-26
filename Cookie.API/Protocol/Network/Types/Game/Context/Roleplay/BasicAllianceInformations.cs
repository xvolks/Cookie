using Cookie.API.Protocol.Network.Types.Game.Social;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class BasicAllianceInformations : AbstractSocialGroupInfos
    {
        public new const short ProtocolId = 419;

        public uint AllianceId;
        public string AllianceTag;

        public BasicAllianceInformations()
        {
        }

        public BasicAllianceInformations(uint allianceId, string allianceTag)
        {
            AllianceId = allianceId;
            AllianceTag = allianceTag;
        }

        public override short TypeID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhInt(AllianceId);
            writer.WriteUTF(AllianceTag);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            AllianceId = reader.ReadVarUhInt();
            AllianceTag = reader.ReadUTF();
        }
    }
}