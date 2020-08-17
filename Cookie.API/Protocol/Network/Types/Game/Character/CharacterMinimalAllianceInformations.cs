using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Character
{
    public class CharacterMinimalAllianceInformations : CharacterMinimalGuildInformations
    {
        public new const ushort ProtocolId = 444;

        public CharacterMinimalAllianceInformations(BasicAllianceInformations alliance)
        {
            Alliance = alliance;
        }

        public CharacterMinimalAllianceInformations()
        {
        }

        public override ushort TypeID => ProtocolId;
        public BasicAllianceInformations Alliance { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Alliance = new BasicAllianceInformations();
            Alliance.Deserialize(reader);
        }
    }
}