using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Fight;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Actions.Fight
{
    public class GameActionFightSummonMessage : AbstractGameActionMessage
    {
        public new const ushort ProtocolId = 5825;

        public GameActionFightSummonMessage(List<GameFightFighterInformations> summons)
        {
            Summons = summons;
        }

        public GameActionFightSummonMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<GameFightFighterInformations> Summons { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) Summons.Count);
            for (var summonsIndex = 0; summonsIndex < Summons.Count; summonsIndex++)
            {
                var objectToSend = Summons[summonsIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var summonsCount = reader.ReadUShort();
            Summons = new List<GameFightFighterInformations>();
            for (var summonsIndex = 0; summonsIndex < summonsCount; summonsIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Summons.Add(objectToAdd);
            }
        }
    }
}