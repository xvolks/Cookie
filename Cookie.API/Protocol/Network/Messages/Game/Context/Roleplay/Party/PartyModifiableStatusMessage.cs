using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyModifiableStatusMessage : AbstractPartyMessage
    {
        public new const ushort ProtocolId = 6277;

        public PartyModifiableStatusMessage(bool enabled)
        {
            Enabled = enabled;
        }

        public PartyModifiableStatusMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool Enabled { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(Enabled);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Enabled = reader.ReadBoolean();
        }
    }
}