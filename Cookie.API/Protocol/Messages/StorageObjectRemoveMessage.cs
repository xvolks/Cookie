using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class StorageObjectRemoveMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5648;

        public override ushort MessageID => ProtocolId;

        public uint ObjectUID { get; set; }
        public StorageObjectRemoveMessage() { }

        public StorageObjectRemoveMessage( uint ObjectUID ){
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
