using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightTurnListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 713;

        public override ushort MessageID => ProtocolId;

        public List<double> Ids { get; set; }
        public List<double> DeadsIds { get; set; }
        public GameFightTurnListMessage() { }

        public GameFightTurnListMessage( List<double> Ids, List<double> DeadsIds ){
            this.Ids = Ids;
            this.DeadsIds = DeadsIds;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Ids.Count);
			foreach (var x in Ids)
			{
				writer.WriteDouble(x);
			}
			writer.WriteShort((short)DeadsIds.Count);
			foreach (var x in DeadsIds)
			{
				writer.WriteDouble(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var IdsCount = reader.ReadShort();
            Ids = new List<double>();
            for (var i = 0; i < IdsCount; i++)
            {
                Ids.Add(reader.ReadDouble());
            }
            var DeadsIdsCount = reader.ReadShort();
            DeadsIds = new List<double>();
            for (var i = 0; i < DeadsIdsCount; i++)
            {
                DeadsIds.Add(reader.ReadDouble());
            }
        }
    }
}
