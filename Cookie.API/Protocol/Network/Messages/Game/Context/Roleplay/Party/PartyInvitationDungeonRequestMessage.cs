using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyInvitationDungeonRequestMessage : PartyInvitationRequestMessage
    {
        public new const ushort ProtocolId = 6245;

        public PartyInvitationDungeonRequestMessage(ushort dungeonId)
        {
            DungeonId = dungeonId;
        }

        public PartyInvitationDungeonRequestMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(DungeonId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DungeonId = reader.ReadVarUhShort();
        }
    }
}