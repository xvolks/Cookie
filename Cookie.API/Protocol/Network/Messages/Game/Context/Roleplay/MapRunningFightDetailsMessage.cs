using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Fight;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    public class MapRunningFightDetailsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5751;

        public MapRunningFightDetailsMessage(int fightId, List<GameFightFighterLightInformations> attackers,
            List<GameFightFighterLightInformations> defenders)
        {
            FightId = fightId;
            Attackers = attackers;
            Defenders = defenders;
        }

        public MapRunningFightDetailsMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public int FightId { get; set; }
        public List<GameFightFighterLightInformations> Attackers { get; set; }
        public List<GameFightFighterLightInformations> Defenders { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(FightId);
            writer.WriteShort((short) Attackers.Count);
            for (var attackersIndex = 0; attackersIndex < Attackers.Count; attackersIndex++)
            {
                var objectToSend = Attackers[attackersIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
            writer.WriteShort((short) Defenders.Count);
            for (var defendersIndex = 0; defendersIndex < Defenders.Count; defendersIndex++)
            {
                var objectToSend = Defenders[defendersIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadInt();
            var attackersCount = reader.ReadUShort();
            Attackers = new List<GameFightFighterLightInformations>();
            for (var attackersIndex = 0; attackersIndex < attackersCount; attackersIndex++)
            {
                var objectToAdd =
                    ProtocolTypeManager.GetInstance<GameFightFighterLightInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Attackers.Add(objectToAdd);
            }
            var defendersCount = reader.ReadUShort();
            Defenders = new List<GameFightFighterLightInformations>();
            for (var defendersIndex = 0; defendersIndex < defendersCount; defendersIndex++)
            {
                var objectToAdd =
                    ProtocolTypeManager.GetInstance<GameFightFighterLightInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Defenders.Add(objectToAdd);
            }
        }
    }
}