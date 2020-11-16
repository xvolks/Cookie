using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DungeonPartyFinderRegisterRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6249;

        public override ushort MessageID => ProtocolId;

        public List<short> DungeonIds { get; set; }
        public DungeonPartyFinderRegisterRequestMessage() { }

        public DungeonPartyFinderRegisterRequestMessage( List<short> DungeonIds ){
            this.DungeonIds = DungeonIds;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)DungeonIds.Count);
			foreach (var x in DungeonIds)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var DungeonIdsCount = reader.ReadShort();
            DungeonIds = new List<short>();
            for (var i = 0; i < DungeonIdsCount; i++)
            {
                DungeonIds.Add(reader.ReadVarShort());
            }
        }
    }
}
