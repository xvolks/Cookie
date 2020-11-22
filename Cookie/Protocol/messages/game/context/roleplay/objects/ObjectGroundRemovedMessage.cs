using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectGroundRemovedMessage : NetworkMessage
    {
        public const uint ProtocolId = 3014;
        public override uint MessageID { get { return ProtocolId; } }

        public short Cell = 0;

        public ObjectGroundRemovedMessage()
        {
        }

        public ObjectGroundRemovedMessage(
            short cell
        )
        {
            Cell = cell;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(Cell);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Cell = reader.ReadVarShort();
        }
    }
}