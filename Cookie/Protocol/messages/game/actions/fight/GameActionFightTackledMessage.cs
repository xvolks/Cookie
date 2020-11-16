using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightTackledMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 1004;
        public override uint MessageID { get { return ProtocolId; } }

        public List<double> TacklersIds;

        public GameActionFightTackledMessage(): base()
        {
        }

        public GameActionFightTackledMessage(
            short actionId,
            double sourceId,
            List<double> tacklersIds
        ): base(
            actionId,
            sourceId
        )
        {
            TacklersIds = tacklersIds;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)TacklersIds.Count());
            foreach (var current in TacklersIds)
            {
                writer.WriteDouble(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countTacklersIds = reader.ReadShort();
            TacklersIds = new List<double>();
            for (short i = 0; i < countTacklersIds; i++)
            {
                TacklersIds.Add(reader.ReadDouble());
            }
        }
    }
}