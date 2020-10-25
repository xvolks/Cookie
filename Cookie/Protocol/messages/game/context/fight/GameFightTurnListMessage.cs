using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightTurnListMessage : NetworkMessage
    {
        public const uint ProtocolId = 713;
        public override uint MessageID { get { return ProtocolId; } }

        public List<double> Ids;
        public List<double> DeadsIds;

        public GameFightTurnListMessage()
        {
        }

        public GameFightTurnListMessage(
            List<double> ids,
            List<double> deadsIds
        )
        {
            Ids = ids;
            DeadsIds = deadsIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Ids.Count());
            foreach (var current in Ids)
            {
                writer.WriteDouble(current);
            }
            writer.WriteShort((short)DeadsIds.Count());
            foreach (var current in DeadsIds)
            {
                writer.WriteDouble(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countIds = reader.ReadShort();
            Ids = new List<double>();
            for (short i = 0; i < countIds; i++)
            {
                Ids.Add(reader.ReadDouble());
            }
            var countDeadsIds = reader.ReadShort();
            DeadsIds = new List<double>();
            for (short i = 0; i < countDeadsIds; i++)
            {
                DeadsIds.Add(reader.ReadDouble());
            }
        }
    }
}