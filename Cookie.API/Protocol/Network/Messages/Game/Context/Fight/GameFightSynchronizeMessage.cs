using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Context.Fight;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    public class GameFightSynchronizeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5921;

        public GameFightSynchronizeMessage(List<GameFightFighterInformations> fighters)
        {
            Fighters = fighters;
        }

        public GameFightSynchronizeMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<GameFightFighterInformations> Fighters { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Fighters.Count);
            for (var fightersIndex = 0; fightersIndex < Fighters.Count; fightersIndex++)
            {
                var objectToSend = Fighters[fightersIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var fightersCount = reader.ReadUShort();
            Fighters = new List<GameFightFighterInformations>();
            for (var fightersIndex = 0; fightersIndex < fightersCount; fightersIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<GameFightFighterInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Fighters.Add(objectToAdd);
            }
        }
    }
}