using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DungeonKeyRingUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6296;

        public override ushort MessageID => ProtocolId;

        public ushort DungeonId { get; set; }
        public bool Available { get; set; }
        public DungeonKeyRingUpdateMessage() { }

        public DungeonKeyRingUpdateMessage( ushort DungeonId, bool Available ){
            this.DungeonId = DungeonId;
            this.Available = Available;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
            writer.WriteBoolean(Available);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
            Available = reader.ReadBoolean();
        }
    }
}
