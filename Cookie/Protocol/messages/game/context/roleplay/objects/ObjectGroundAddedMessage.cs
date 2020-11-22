using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ObjectGroundAddedMessage : NetworkMessage
    {
        public const uint ProtocolId = 3017;
        public override uint MessageID { get { return ProtocolId; } }

        public short CellId = 0;
        public short ObjectGID = 0;

        public ObjectGroundAddedMessage()
        {
        }

        public ObjectGroundAddedMessage(
            short cellId,
            short objectGID
        )
        {
            CellId = cellId;
            ObjectGID = objectGID;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(CellId);
            writer.WriteVarShort(ObjectGID);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CellId = reader.ReadVarShort();
            ObjectGID = reader.ReadVarShort();
        }
    }
}