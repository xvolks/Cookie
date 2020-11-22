using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DungeonPartyFinderListenErrorMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6248;

        public override ushort MessageID => ProtocolId;

        public ushort DungeonId { get; set; }
        public DungeonPartyFinderListenErrorMessage() { }

        public DungeonPartyFinderListenErrorMessage( ushort DungeonId ){
            this.DungeonId = DungeonId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(DungeonId);
        }

        public override void Deserialize(IDataReader reader)
        {
            DungeonId = reader.ReadVarUhShort();
        }
    }
}
