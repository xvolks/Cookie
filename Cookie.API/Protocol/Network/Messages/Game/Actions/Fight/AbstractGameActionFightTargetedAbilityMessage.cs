using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6118;

        public AbstractGameActionFightTargetedAbilityMessage(bool silentCast, bool verboseCast, double targetId,
            short destinationCellId, byte critical)
        {
            SilentCast = silentCast;
            VerboseCast = verboseCast;
            TargetId = targetId;
            DestinationCellId = destinationCellId;
            Critical = critical;
        }

        public AbstractGameActionFightTargetedAbilityMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public bool SilentCast { get; set; }
        public bool VerboseCast { get; set; }
        public double TargetId { get; set; }
        public short DestinationCellId { get; set; }
        public byte Critical { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            var flag = new byte();
            flag = BooleanByteWrapper.SetFlag(0, flag, SilentCast);
            flag = BooleanByteWrapper.SetFlag(1, flag, VerboseCast);
            writer.WriteByte(flag);
            writer.WriteDouble(TargetId);
            writer.WriteShort(DestinationCellId);
            writer.WriteByte(Critical);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var flag = reader.ReadByte();
            SilentCast = BooleanByteWrapper.GetFlag(flag, 0);
            VerboseCast = BooleanByteWrapper.GetFlag(flag, 1);
            TargetId = reader.ReadDouble();
            DestinationCellId = reader.ReadShort();
            Critical = reader.ReadByte();
        }
    }
}