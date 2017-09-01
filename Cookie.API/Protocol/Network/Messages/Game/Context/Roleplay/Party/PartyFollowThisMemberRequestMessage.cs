using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay.Party
{
    public class PartyFollowThisMemberRequestMessage : PartyFollowMemberRequestMessage
    {
        public new const ushort ProtocolId = 5588;

        public PartyFollowThisMemberRequestMessage(bool enabled)
        {
            Enabled = enabled;
        }

        public PartyFollowThisMemberRequestMessage()
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