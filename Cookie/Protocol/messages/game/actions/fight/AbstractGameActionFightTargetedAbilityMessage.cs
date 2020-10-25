using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 6118;
        public override uint MessageID { get { return ProtocolId; } }

        public bool SilentCast = false;
        public bool VerboseCast = false;
        public double TargetId = 0;
        public short DestinationCellId = 0;
        public byte Critical = 1;

        public AbstractGameActionFightTargetedAbilityMessage(): base()
        {
        }

        public AbstractGameActionFightTargetedAbilityMessage(
            short actionId,
            double sourceId,
            bool silentCast,
            bool verboseCast,
            double targetId,
            short destinationCellId,
            byte critical
        ): base(
            actionId,
            sourceId
        )
        {
            SilentCast = silentCast;
            VerboseCast = verboseCast;
            TargetId = targetId;
            DestinationCellId = destinationCellId;
            Critical = critical;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            byte box0 = 0;
            box0 = BooleanByteWrapper.SetFlag(box0, 1, SilentCast);
            box0 = BooleanByteWrapper.SetFlag(box0, 2, VerboseCast);
            writer.WriteByte(box0);
            writer.WriteDouble(TargetId);
            writer.WriteShort(DestinationCellId);
            writer.WriteByte(Critical);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            byte box0 = reader.ReadByte();
            SilentCast = BooleanByteWrapper.GetFlag(box0, 1);
            VerboseCast = BooleanByteWrapper.GetFlag(box0, 2);
            TargetId = reader.ReadDouble();
            DestinationCellId = reader.ReadShort();
            Critical = reader.ReadByte();
        }
    }
}