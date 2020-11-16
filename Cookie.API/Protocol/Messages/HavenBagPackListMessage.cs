using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class HavenBagPackListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6620;

        public override ushort MessageID => ProtocolId;

        public List<sbyte> PackIds { get; set; }
        public HavenBagPackListMessage() { }

        public HavenBagPackListMessage( List<sbyte> PackIds ){
            this.PackIds = PackIds;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)PackIds.Count);
			foreach (var x in PackIds)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var PackIdsCount = reader.ReadShort();
            PackIds = new List<sbyte>();
            for (var i = 0; i < PackIdsCount; i++)
            {
                PackIds.Add(reader.ReadSByte());
            }
        }
    }
}
