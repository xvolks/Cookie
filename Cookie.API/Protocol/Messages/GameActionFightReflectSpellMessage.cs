using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightReflectSpellMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5531;

        public override ushort MessageID => ProtocolId;

        public double TargetId { get; set; }
        public GameActionFightReflectSpellMessage() { }

        public GameActionFightReflectSpellMessage( double TargetId ){
            this.TargetId = TargetId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            TargetId = reader.ReadDouble();
        }
    }
}
