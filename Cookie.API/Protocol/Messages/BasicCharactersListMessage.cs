using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class BasicCharactersListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6475;

        public override ushort MessageID => ProtocolId;

        public List<CharacterBaseInformations> Characters { get; set; }
        public BasicCharactersListMessage() { }

        public BasicCharactersListMessage( List<CharacterBaseInformations> Characters ){
            this.Characters = Characters;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)Characters.Count);
			foreach (var x in Characters)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var CharactersCount = reader.ReadShort();
            Characters = new List<CharacterBaseInformations>();
            for (var i = 0; i < CharactersCount; i++)
            {
                CharacterBaseInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                Characters.Add(objectToAdd);
            }
        }
    }
}
