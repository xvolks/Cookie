using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class EmoteListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5689;

        public override ushort MessageID => ProtocolId;

        public List<sbyte> EmoteIds { get; set; }
        public EmoteListMessage() { }

        public EmoteListMessage( List<sbyte> EmoteIds ){
            this.EmoteIds = EmoteIds;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)EmoteIds.Count);
			foreach (var x in EmoteIds)
			{
				writer.WriteSByte(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var EmoteIdsCount = reader.ReadShort();
            EmoteIds = new List<sbyte>();
            for (var i = 0; i < EmoteIdsCount; i++)
            {
                EmoteIds.Add(reader.ReadSByte());
            }
        }
    }
}
