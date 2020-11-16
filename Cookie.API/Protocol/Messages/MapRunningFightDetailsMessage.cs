using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapRunningFightDetailsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5751;

        public override ushort MessageID => ProtocolId;

        public ushort FightId { get; set; }
        public List<GameFightFighterLightInformations> Attackers { get; set; }
        public List<GameFightFighterLightInformations> Defenders { get; set; }
        public MapRunningFightDetailsMessage() { }

        public MapRunningFightDetailsMessage( ushort FightId, List<GameFightFighterLightInformations> Attackers, List<GameFightFighterLightInformations> Defenders ){
            this.FightId = FightId;
            this.Attackers = Attackers;
            this.Defenders = Defenders;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
			writer.WriteShort((short)Attackers.Count);
			foreach (var x in Attackers)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)Defenders.Count);
			foreach (var x in Defenders)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
            var AttackersCount = reader.ReadShort();
            Attackers = new List<GameFightFighterLightInformations>();
            for (var i = 0; i < AttackersCount; i++)
            {
                GameFightFighterLightInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Attackers.Add(objectToAdd);
            }
            var DefendersCount = reader.ReadShort();
            Defenders = new List<GameFightFighterLightInformations>();
            for (var i = 0; i < DefendersCount; i++)
            {
                GameFightFighterLightInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Defenders.Add(objectToAdd);
            }
        }
    }
}
