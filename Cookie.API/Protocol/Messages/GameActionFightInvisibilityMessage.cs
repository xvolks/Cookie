using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightInvisibilityMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5821;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public sbyte State { get; set; }
        public GameActionFightInvisibilityMessage() { }

        public GameActionFightInvisibilityMessage( double TargetId, sbyte State ){
            this.TargetId = TargetId;
            this.State = State;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteSByte(State);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            State = reader.ReadSByte();
        }
    }
}
