using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class MapRunningFightDetailsMessage : NetworkMessage
    {
        public const uint ProtocolId = 5751;
        public override uint MessageID { get { return ProtocolId; } }

        public short FightId = 0;
        public List<GameFightFighterLightInformations> Attackers;
        public List<GameFightFighterLightInformations> Defenders;

        public MapRunningFightDetailsMessage()
        {
        }

        public MapRunningFightDetailsMessage(
            short fightId,
            List<GameFightFighterLightInformations> attackers,
            List<GameFightFighterLightInformations> defenders
        )
        {
            FightId = fightId;
            Attackers = attackers;
            Defenders = defenders;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(FightId);
            writer.WriteShort((short)Attackers.Count());
            foreach (var current in Attackers)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
            writer.WriteShort((short)Defenders.Count());
            foreach (var current in Defenders)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            FightId = reader.ReadVarShort();
            var countAttackers = reader.ReadShort();
            Attackers = new List<GameFightFighterLightInformations>();
            for (short i = 0; i < countAttackers; i++)
            {
                var attackerstypeId = reader.ReadShort();
                GameFightFighterLightInformations type = new GameFightFighterLightInformations();
                type.Deserialize(reader);
                Attackers.Add(type);
            }
            var countDefenders = reader.ReadShort();
            Defenders = new List<GameFightFighterLightInformations>();
            for (short i = 0; i < countDefenders; i++)
            {
                var defenderstypeId = reader.ReadShort();
                GameFightFighterLightInformations type = new GameFightFighterLightInformations();
                type.Deserialize(reader);
                Defenders.Add(type);
            }
        }
    }
}