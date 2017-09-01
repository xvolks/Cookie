using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyInvitationDungeonMessage : PartyInvitationMessage
    {
        public new const ushort ProtocolId = 6244;

        public PartyInvitationDungeonMessage(ushort dungeonId)
        {
            DungeonId = dungeonId;
        }

        public PartyInvitationDungeonMessage()
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