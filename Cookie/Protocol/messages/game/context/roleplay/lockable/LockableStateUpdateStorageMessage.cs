using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LockableStateUpdateStorageMessage : LockableStateUpdateAbstractMessage
    {
        public new const uint ProtocolId = 5669;
        public override uint MessageID { get { return ProtocolId; } }

        public double MapId = 0;
        public int ElementId = 0;

        public LockableStateUpdateStorageMessage(): base()
        {
        }

        public LockableStateUpdateStorageMessage(
            bool locked,
            double mapId,
            int elementId
        ): base(
            locked
        )
        {
            MapId = mapId;
            ElementId = elementId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(MapId);
            writer.WriteVarInt(ElementId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            MapId = reader.ReadDouble();
            ElementId = reader.ReadVarInt();
        }
    }
}