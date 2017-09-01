namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party.Companion
{
    using Messages.Game.Context.Roleplay.Party;
    using Utils.IO;

    public class PartyCompanionUpdateLightMessage : PartyUpdateLightMessage
    {
        public new const ushort ProtocolId = 6472;
        public override ushort MessageID => ProtocolId;
        public byte IndexId { get; set; }

        public PartyCompanionUpdateLightMessage(byte indexId)
        {
            IndexId = indexId;
        }

        public PartyCompanionUpdateLightMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteByte(IndexId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            IndexId = reader.ReadByte();
        }

    }
}
