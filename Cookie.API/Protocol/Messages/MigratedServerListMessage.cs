using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MigratedServerListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6731;

        public override ushort MessageID => ProtocolId;

        public List<short> MigratedServerIds { get; set; }
        public MigratedServerListMessage() { }

        public MigratedServerListMessage( List<short> MigratedServerIds ){
            this.MigratedServerIds = MigratedServerIds;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)MigratedServerIds.Count);
			foreach (var x in MigratedServerIds)
			{
				writer.WriteVarShort(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var MigratedServerIdsCount = reader.ReadShort();
            MigratedServerIds = new List<short>();
            for (var i = 0; i < MigratedServerIdsCount; i++)
            {
                MigratedServerIds.Add(reader.ReadVarShort());
            }
        }
    }
}
