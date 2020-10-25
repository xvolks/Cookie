using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightActivateGlyphTrapMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 6545;
        public override uint MessageID { get { return ProtocolId; } }

        public short MarkId = 0;
        public bool Active = false;

        public GameActionFightActivateGlyphTrapMessage(): base()
        {
        }

        public GameActionFightActivateGlyphTrapMessage(
            short actionId,
            double sourceId,
            short markId,
            bool active
        ): base(
            actionId,
            sourceId
        )
        {
            MarkId = markId;
            Active = active;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort(MarkId);
            writer.WriteBoolean(Active);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MarkId = reader.ReadShort();
            Active = reader.ReadBoolean();
        }
    }
}