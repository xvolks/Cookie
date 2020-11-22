using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AbstractGameActionMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1000;

        public override ushort MessageID => ProtocolId;

        public ushort ActionId { get; set; }
        public double SourceId { get; set; }
        public AbstractGameActionMessage() { }

        public AbstractGameActionMessage( ushort ActionId, double SourceId ){
            this.ActionId = ActionId;
            this.SourceId = SourceId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ActionId);
            writer.WriteDouble(SourceId);
        }

        public override void Deserialize(IDataReader reader)
        {
            ActionId = reader.ReadVarUhShort();
            SourceId = reader.ReadDouble();
        }
    }
}
