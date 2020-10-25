using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class GameRolePlayShowMultipleActorsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6712;
        public override uint MessageID { get { return ProtocolId; } }

        public List<GameRolePlayActorInformations> InformationsList;

        public GameRolePlayShowMultipleActorsMessage()
        {
        }

        public GameRolePlayShowMultipleActorsMessage(
            List<GameRolePlayActorInformations> informationsList
        )
        {
            InformationsList = informationsList;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)InformationsList.Count());
            foreach (var current in InformationsList)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countInformationsList = reader.ReadShort();
            InformationsList = new List<GameRolePlayActorInformations>();
            for (short i = 0; i < countInformationsList; i++)
            {
                var informationsListtypeId = reader.ReadShort();
                GameRolePlayActorInformations type = new GameRolePlayActorInformations();
                type.Deserialize(reader);
                InformationsList.Add(type);
            }
        }
    }
}