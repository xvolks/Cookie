using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyMemberInStandardFightMessage : AbstractPartyMemberInFightMessage
    {
        public new const uint ProtocolId = 6826;
        public override uint MessageID { get { return ProtocolId; } }

        public MapCoordinatesExtended FightMap;

        public PartyMemberInStandardFightMessage(): base()
        {
        }

        public PartyMemberInStandardFightMessage(
            int partyId,
            byte reason,
            long memberId,
            int memberAccountId,
            string memberName,
            short fightId,
            short timeBeforeFightStart,
            MapCoordinatesExtended fightMap
        ): base(
            partyId,
            reason,
            memberId,
            memberAccountId,
            memberName,
            fightId,
            timeBeforeFightStart
        )
        {
            FightMap = fightMap;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            FightMap.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            FightMap = new MapCoordinatesExtended();
            FightMap.Deserialize(reader);
        }
    }
}