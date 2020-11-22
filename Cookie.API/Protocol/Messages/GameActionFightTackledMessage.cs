using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightTackledMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 1004;

        public override ushort MessageID => ProtocolId;

        public List<double> TacklersIds { get; set; }
        public GameActionFightTackledMessage() { }

        public GameActionFightTackledMessage( List<double> TacklersIds ){
            this.TacklersIds = TacklersIds;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)TacklersIds.Count);
			foreach (var x in TacklersIds)
			{
				writer.WriteDouble(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var TacklersIdsCount = reader.ReadShort();
            TacklersIds = new List<double>();
            for (var i = 0; i < TacklersIdsCount; i++)
            {
                TacklersIds.Add(reader.ReadDouble());
            }
        }
    }
}
