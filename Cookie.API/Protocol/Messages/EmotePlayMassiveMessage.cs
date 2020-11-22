using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class EmotePlayMassiveMessage : EmotePlayAbstractMessage
    {
        public new const ushort ProtocolId = 5691;

        public override ushort MessageID => ProtocolId;

        public List<double> ActorIds { get; set; }
        public EmotePlayMassiveMessage() { }

        public EmotePlayMassiveMessage( List<double> ActorIds ){
            this.ActorIds = ActorIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)ActorIds.Count);
			foreach (var x in ActorIds)
			{
				writer.WriteDouble(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var ActorIdsCount = reader.ReadShort();
            ActorIds = new List<double>();
            for (var i = 0; i < ActorIdsCount; i++)
            {
                ActorIds.Add(reader.ReadDouble());
            }
        }
    }
}
