using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CurrentMapInstanceMessage : CurrentMapMessage
    {
        public new const ushort ProtocolId = 6738;

        public override ushort MessageID => ProtocolId;

        public double InstantiatedMapId { get; set; }
        public CurrentMapInstanceMessage() { }

        public CurrentMapInstanceMessage( double InstantiatedMapId ){
            this.InstantiatedMapId = InstantiatedMapId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(InstantiatedMapId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            InstantiatedMapId = reader.ReadDouble();
        }
    }
}
