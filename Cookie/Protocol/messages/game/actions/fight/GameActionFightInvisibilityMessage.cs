using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightInvisibilityMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5821;
        public override uint MessageID { get { return ProtocolId; } }

        public double TargetId = 0;
        public byte State = 0;

        public GameActionFightInvisibilityMessage(): base()
        {
        }

        public GameActionFightInvisibilityMessage(
            short actionId,
            double sourceId,
            double targetId,
            byte state
        ): base(
            actionId,
            sourceId
        )
        {
            TargetId = targetId;
            State = state;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteByte(State);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            State = reader.ReadByte();
        }
    }
}