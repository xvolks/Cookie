using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyInvitationDungeonRequestMessage : PartyInvitationRequestMessage
    {
        public new const uint ProtocolId = 6245;
        public override uint MessageID { get { return ProtocolId; } }

        public short DungeonId = 0;

        public PartyInvitationDungeonRequestMessage(): base()
        {
        }

        public PartyInvitationDungeonRequestMessage(
            string name,
            short dungeonId
        ): base(
            name
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