using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightSummonMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5825;

        public override ushort MessageID => ProtocolId;

        public List<GameFightFighterInformations> Summons { get; set; }
        public GameActionFightSummonMessage() { }

        public GameActionFightSummonMessage( List<GameFightFighterInformations> Summons ){
            this.Summons = Summons;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)Summons.Count);
			foreach (var x in Summons)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var SummonsCount = reader.ReadShort();
            Summons = new List<GameFightFighterInformations>();
            for (var i = 0; i < SummonsCount; i++)
            {
                GameFightFighterInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Summons.Add(objectToAdd);
            }
        }
    }
}
