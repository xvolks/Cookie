namespace Cookie.API.Protocol.Network.Messages.Game.Context.Roleplay
{
    using Types.Game.Context.Roleplay;
    using System.Collections.Generic;
    using Utils.IO;

    public class GameRolePlayShowMultipleActorsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6712;
        public override ushort MessageID => ProtocolId;
        public List<GameRolePlayActorInformations> InformationsList { get; set; }

        public GameRolePlayShowMultipleActorsMessage(List<GameRolePlayActorInformations> informationsList)
        {
            InformationsList = informationsList;
        }

        public GameRolePlayShowMultipleActorsMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)InformationsList.Count);
            for (var informationsListIndex = 0; informationsListIndex < InformationsList.Count; informationsListIndex++)
            {
                var objectToSend = InformationsList[informationsListIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var informationsListCount = reader.ReadUShort();
            InformationsList = new List<GameRolePlayActorInformations>();
            for (var informationsListIndex = 0; informationsListIndex < informationsListCount; informationsListIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<GameRolePlayActorInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                InformationsList.Add(objectToAdd);
            }
        }

    }
}
