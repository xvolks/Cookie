using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightDispellMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5533;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public bool VerboseCast { get; set; }
        public GameActionFightDispellMessage() { }

        public GameActionFightDispellMessage( double TargetId, bool VerboseCast ){
            this.TargetId = TargetId;
            this.VerboseCast = VerboseCast;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
            writer.WriteBoolean(VerboseCast);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
            VerboseCast = reader.ReadBoolean();
        }
    }
}
