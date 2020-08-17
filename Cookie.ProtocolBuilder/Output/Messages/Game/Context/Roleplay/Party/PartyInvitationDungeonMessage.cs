namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    using Utils.IO;

    public class PartyInvitationDungeonMessage : PartyInvitationMessage
    {
        public new const ushort ProtocolId = 6244;
        public override ushort MessageID => ProtocolId;
        public ushort DungeonId { get; set; }

        public PartyInvitationDungeonMessage(ushort dungeonId)
        {
            DungeonId = dungeonId;
        }

        public PartyInvitationDungeonMessage() { }

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
