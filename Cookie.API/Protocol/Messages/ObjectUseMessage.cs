using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectUseMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3019;

        public override ushort MessageID => ProtocolId;

        public uint ObjectUID { get; set; }
        public ObjectUseMessage() { }

        public ObjectUseMessage( uint ObjectUID ){
            this.ObjectUID = ObjectUID;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(ObjectUID);
        }

        public override void Deserialize(IDataReader reader)
        {
            ObjectUID = reader.ReadVarUhInt();
        }
    }
}
