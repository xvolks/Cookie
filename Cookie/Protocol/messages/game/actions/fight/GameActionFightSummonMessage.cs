using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightSummonMessage : AbstractGameActionMessage
    {
        public new const uint ProtocolId = 5825;
        public override uint MessageID { get { return ProtocolId; } }

        public List<GameFightFighterInformations> Summons;

        public GameActionFightSummonMessage(): base()
        {
        }

        public GameActionFightSummonMessage(
            short actionId,
            double sourceId,
            List<GameFightFighterInformations> summons
        ): base(
            actionId,
            sourceId
        )
        {
            Summons = summons;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Summons.Count());
            foreach (var current in Summons)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countSummons = reader.ReadShort();
            Summons = new List<GameFightFighterInformations>();
            for (short i = 0; i < countSummons; i++)
            {
                var summonstypeId = reader.ReadShort();
                GameFightFighterInformations type = new GameFightFighterInformations();
                type.Deserialize(reader);
                Summons.Add(type);
            }
        }
    }
}