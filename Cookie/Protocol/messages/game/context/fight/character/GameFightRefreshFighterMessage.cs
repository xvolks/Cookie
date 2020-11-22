using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightRefreshFighterMessage : NetworkMessage
    {
        public const uint ProtocolId = 6309;
        public override uint MessageID { get { return ProtocolId; } }

        public GameContextActorInformations Informations;

        public GameFightRefreshFighterMessage()
        {
        }

        public GameFightRefreshFighterMessage(
            GameContextActorInformations informations
        )
        {
            Informations = informations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(Informations.TypeId);
            Informations.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var informationsTypeId = reader.ReadShort();
            Informations = new GameContextActorInformations();
            Informations.Deserialize(reader);
        }
    }
}