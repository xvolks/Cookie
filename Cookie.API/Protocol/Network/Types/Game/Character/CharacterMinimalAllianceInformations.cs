using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Network.Types.Game.Context.Roleplay;

namespace Cookie.API.Protocol.Network.Types.Game.Character
{
    public class CharacterMinimalAllianceInformations : CharacterMinimalPlusLookInformations
    {
        public new const short ProtocolId = 444;

        public CharacterMinimalAllianceInformations()
        {
        }

        public CharacterMinimalAllianceInformations(BasicAllianceInformations alliance)
        {
            Alliance = alliance;
        }

        public override short TypeID => ProtocolId;

        public BasicAllianceInformations Alliance { get; set; }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Alliance.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Alliance = new BasicAllianceInformations();
            Alliance.Deserialize(reader);
        }
    }
}