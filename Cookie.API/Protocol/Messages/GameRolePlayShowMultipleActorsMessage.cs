using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameRolePlayShowMultipleActorsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6712;

        public override ushort MessageID => ProtocolId;

        public List<GameRolePlayActorInformations> InformationsList { get; set; }
        public GameRolePlayShowMultipleActorsMessage() { }

        public GameRolePlayShowMultipleActorsMessage( List<GameRolePlayActorInformations> InformationsList ){
            this.InformationsList = InformationsList;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)InformationsList.Count);
			foreach (var x in InformationsList)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var InformationsListCount = reader.ReadShort();
            InformationsList = new List<GameRolePlayActorInformations>();
            for (var i = 0; i < InformationsListCount; i++)
            {
                GameRolePlayActorInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                InformationsList.Add(objectToAdd);
            }
        }
    }
}
