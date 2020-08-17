namespace Cookie.API.Protocol.Network.Messages.Game.Context.Fight
{
    using Types.Game.Context.Fight;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameFightSynchronizeMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5921;
        public override ushort MessageID => ProtocolId;
        public List<GameFightFighterInformations> Fighters { get; set; }

        public GameFightSynchronizeMessage(List<GameFightFighterInformations> fighters)
        {
            Fighters = fighters;
        }

        public GameFightSynchronizeMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Fighters.Count);
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
