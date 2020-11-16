using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AbstractGameActionFightTargetedAbilityMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 6118;

        public override ushort MessageID => ProtocolId;

        public bool SilentCast { get; set; }
        public bool VerboseCast { get; set; }
        public double TargetId { get; set; }
        public short DestinationCellId { get; set; }
        public sbyte Critical { get; set; }
        public AbstractGameActionFightTargetedAbilityMessage() { }

        public AbstractGameActionFightTargetedAbilityMessage( bool SilentCast, bool VerboseCast, double TargetId, short DestinationCellId, sbyte Critical ){
            this.SilentCast = SilentCast;
            this.VerboseCast = VerboseCast;
            this.TargetId = TargetId;
            this.DestinationCellId = DestinationCellId;
            this.Critical = Critical;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			var flag = new byte();
			flag = BooleanByteWrapper.SetFlag(0, flag, SilentCast);
			flag = BooleanByteWrapper.SetFlag(1, flag, VerboseCast);
			writer.WriteByte(flag);
            writer.WriteDouble(TargetId);
            writer.WriteShort(DestinationCellId);
            writer.WriteSByte(Critical);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
			var flag = reader.ReadByte();
			SilentCast = BooleanByteWrapper.GetFlag(flag, 0);;
			VerboseCast = BooleanByteWrapper.GetFlag(flag, 1);;
            TargetId = reader.ReadDouble();
            DestinationCellId = reader.ReadShort();
            Critical = reader.ReadSByte();
        }
    }
}
