using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyMemberInStandardFightMessage : AbstractPartyMemberInFightMessage
    {
        public new const ushort ProtocolId = 6826;

        public override ushort MessageID => ProtocolId;

        public MapCoordinatesExtended FightMap { get; set; }
        public PartyMemberInStandardFightMessage() { }

        public PartyMemberInStandardFightMessage( MapCoordinatesExtended FightMap ){
            this.FightMap = FightMap;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            FightMap.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            FightMap = new MapCoordinatesExtended();
            FightMap.Deserialize(reader);
        }
    }
}
