using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ObjectGroundAddedMessage : NetworkMessage
    {
        public const ushort ProtocolId = 3017;

        public override ushort MessageID => ProtocolId;

        public ushort CellId { get; set; }
        public ushort ObjectGID { get; set; }
        public ObjectGroundAddedMessage() { }

        public ObjectGroundAddedMessage( ushort CellId, ushort ObjectGID ){
            this.CellId = CellId;
            this.ObjectGID = ObjectGID;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(CellId);
            writer.WriteVarUhShort(ObjectGID);
        }

        public override void Deserialize(IDataReader reader)
        {
            CellId = reader.ReadVarUhShort();
            ObjectGID = reader.ReadVarUhShort();
        }
    }
}
