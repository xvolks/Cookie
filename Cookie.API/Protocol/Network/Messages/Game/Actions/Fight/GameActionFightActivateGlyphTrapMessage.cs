using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightActivateGlyphTrapMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6545;

        public GameActionFightActivateGlyphTrapMessage(short markId, bool active)
        {
            MarkId = markId;
            Active = active;
        }

        public GameActionFightActivateGlyphTrapMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public short MarkId { get; set; }
        public bool Active { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MarkId);
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MarkId = reader.ReadShort();
            Active = reader.ReadBoolean();
        }
    }
}