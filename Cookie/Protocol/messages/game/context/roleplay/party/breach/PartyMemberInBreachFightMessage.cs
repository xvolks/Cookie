using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyMemberInBreachFightMessage : AbstractPartyMemberInFightMessage
    {
        public new const uint ProtocolId = 6824;
        public override uint MessageID { get { return ProtocolId; } }

        public int Floor = 0;
        public byte Room = 0;

        public PartyMemberInBreachFightMessage(): base()
        {
        }

        public PartyMemberInBreachFightMessage(
            int partyId,
            byte reason,
            long memberId,
            int memberAccountId,
            string memberName,
            short fightId,
            short timeBeforeFightStart,
            int floor,
            byte room
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
            Floor = floor;
            Room = room;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(Floor);
            writer.WriteByte(Room);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Floor = reader.ReadVarInt();
            Room = reader.ReadByte();
        }
    }
}