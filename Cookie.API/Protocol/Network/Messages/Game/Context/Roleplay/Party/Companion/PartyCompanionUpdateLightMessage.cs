using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party.Companion
{
    public class PartyCompanionUpdateLightMessage : PartyUpdateLightMessage
    {
        public new const ushort ProtocolId = 6472;

        public PartyCompanionUpdateLightMessage(byte indexId)
        {
            IndexId = indexId;
        }

        public PartyCompanionUpdateLightMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public byte IndexId { get; set; }

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