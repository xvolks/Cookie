using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class BasicCharactersListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6475;
        public override uint MessageID { get { return ProtocolId; } }

        public List<CharacterBaseInformations> Characters;

        public BasicCharactersListMessage()
        {
        }

        public BasicCharactersListMessage(
            List<CharacterBaseInformations> characters
        )
        {
            Characters = characters;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Characters.Count());
            foreach (var current in Characters)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countCharacters = reader.ReadShort();
            Characters = new List<CharacterBaseInformations>();
            for (short i = 0; i < countCharacters; i++)
            {
                var characterstypeId = reader.ReadShort();
                CharacterBaseInformations type = new CharacterBaseInformations();
                type.Deserialize(reader);
                Characters.Add(type);
            }
        }
    }
}