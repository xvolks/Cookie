using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3025;

        public override ushort MessageID => ProtocolId;

        public ObjectItem Object { get; set; }
        public sbyte Origin { get; set; }
        public ObjectAddedMessage() { }

        public ObjectAddedMessage( ObjectItem Object, sbyte Origin ){
            this.Object = Object;
            this.Origin = Origin;
        }

        public override void Serialize(IDataWriter writer)
        {
            Object.Serialize(writer);
            writer.WriteSByte(Origin);
        }

        public override void Deserialize(IDataReader reader)
        {
            Object = new ObjectItem();
            Object.Deserialize(reader);
            Origin = reader.ReadSByte();
        }
    }
}
