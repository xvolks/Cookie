using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectAddedMessage : NetworkMessage
    {
        public const uint ProtocolId = 3025;
        public override uint MessageID { get { return ProtocolId; } }

        public ObjectItem Object_;
        public byte Origin = 0;

        public ObjectAddedMessage()
        {
        }

        public ObjectAddedMessage(
            ObjectItem object_,
            byte origin
        )
        {
            Object_ = object_;
            Origin = origin;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            Object_.Serialize(writer);
            writer.WriteByte(Origin);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Object_ = new ObjectItem();
            Object_.Deserialize(reader);
            Origin = reader.ReadByte();
        }
    }
}