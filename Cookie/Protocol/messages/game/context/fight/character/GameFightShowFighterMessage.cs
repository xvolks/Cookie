using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightShowFighterMessage : NetworkMessage
    {
        public const uint ProtocolId = 5864;
        public override uint MessageID { get { return ProtocolId; } }

        public GameFightFighterInformations Informations;

        public GameFightShowFighterMessage()
        {
        }

        public GameFightShowFighterMessage(
            GameFightFighterInformations informations
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
            Informations = new GameFightFighterInformations();
            Informations.Deserialize(reader);
        }
    }
}