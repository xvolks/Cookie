using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Character.Choice;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class BasicCharactersListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6475;

        public List<CharacterBaseInformations> Characters;

        public BasicCharactersListMessage()
        {
        }

        public BasicCharactersListMessage(List<CharacterBaseInformations> characters)
        {
            Characters = characters;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Characters.Count);
            int charactersIndex;
            for (charactersIndex = 0; charactersIndex < Characters.Count; charactersIndex = charactersIndex + 1)
            {
                var objectToSend = Characters[charactersIndex];
                writer.WriteUShort((ushort) objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            int charactersCount = reader.ReadUShort();
            Characters = new List<CharacterBaseInformations>();
            for (var i = 0; i < charactersCount; i++)
            {
                var objectToAdd =
                    ProtocolTypeManager.GetInstance<CharacterBaseInformations>((short) reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Characters.Add(objectToAdd);
            }
        }
    }
}