using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyInvitationDungeonMessage : PartyInvitationMessage
    {
        public new const uint ProtocolId = 6244;
        public override uint MessageID { get { return ProtocolId; } }

        public short DungeonId = 0;

        public PartyInvitationDungeonMessage(): base()
        {
        }

        public PartyInvitationDungeonMessage(
            int partyId,
            byte partyType,
            string partyName,
            byte maxParticipants,
            long fromId,
            string fromName,
            long toId,
            short dungeonId
        ): base(
            partyId,
            partyType,
            partyName,
            maxParticipants,
            fromId,
            fromName,
            toId
        )
        {
            DungeonId = dungeonId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort(DungeonId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            DungeonId = reader.ReadVarShort();
        }
    }
}