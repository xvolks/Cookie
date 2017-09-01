using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Character.Choice;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class BasicCharactersListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6475;

        public BasicCharactersListMessage(List<CharacterBaseInformations> characters)
        {
            Characters = characters;
        }

        public BasicCharactersListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<CharacterBaseInformations> Characters { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Characters.Count);
            for (var charactersIndex = 0; charactersIndex < Characters.Count; charactersIndex++)
            {
                var objectToSend = Characters[charactersIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var charactersCount = reader.ReadUShort();
            Characters = new List<CharacterBaseInformations>();
            for (var charactersIndex = 0; charactersIndex < charactersCount; charactersIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<CharacterBaseInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Characters.Add(objectToAdd);
            }
        }
    }
}