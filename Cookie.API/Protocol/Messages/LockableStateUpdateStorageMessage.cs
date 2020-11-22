using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class LockableStateUpdateStorageMessage : LockableStateUpdateAbstractMessage
    {
        public new const ushort ProtocolId = 5669;

        public override ushort MessageID => ProtocolId;

        public double MapId { get; set; }
        public uint ElementId { get; set; }
        public LockableStateUpdateStorageMessage() { }

        public LockableStateUpdateStorageMessage( double MapId, uint ElementId ){
            this.MapId = MapId;
            this.ElementId = ElementId;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(MapId);
            writer.WriteVarUhInt(ElementId);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            MapId = reader.ReadDouble();
            ElementId = reader.ReadVarUhInt();
        }
    }
}
