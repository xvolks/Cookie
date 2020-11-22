using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class InteractiveUseWithParamRequestMessage : InteractiveUseRequestMessage
    {
        public new const ushort ProtocolId = 6715;

        public override ushort MessageID => ProtocolId;

        public int Id { get; set; }
        public InteractiveUseWithParamRequestMessage() { }

        public InteractiveUseWithParamRequestMessage( int Id ){
            this.Id = Id;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteInt(Id);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Id = reader.ReadInt();
        }
    }
}
