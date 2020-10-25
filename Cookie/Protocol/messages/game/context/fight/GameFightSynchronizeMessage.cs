using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightSynchronizeMessage : NetworkMessage
    {
        public const uint ProtocolId = 5921;
        public override uint MessageID { get { return ProtocolId; } }

        public List<GameFightFighterInformations> Fighters;

        public GameFightSynchronizeMessage()
        {
        }

        public GameFightSynchronizeMessage(
            List<GameFightFighterInformations> fighters
        )
        {
            Fighters = fighters;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Fighters.Count());
            foreach (var current in Fighters)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countFighters = reader.ReadShort();
            Fighters = new List<GameFightFighterInformations>();
            for (short i = 0; i < countFighters; i++)
            {
                var fighterstypeId = reader.ReadShort();
                GameFightFighterInformations type = new GameFightFighterInformations();
                type.Deserialize(reader);
                Fighters.Add(type);
            }
        }
    }
}