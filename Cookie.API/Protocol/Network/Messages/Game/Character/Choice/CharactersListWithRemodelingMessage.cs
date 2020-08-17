using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Character.Choice;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Character.Choice
{
    public class CharactersListWithRemodelingMessage : CharactersListMessage
    {
        public new const ushort ProtocolId = 6550;

        public CharactersListWithRemodelingMessage(List<CharacterToRemodelInformations> charactersToRemodel)
        {
            CharactersToRemodel = charactersToRemodel;
        }

        public CharactersListWithRemodelingMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<CharacterToRemodelInformations> CharactersToRemodel { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) CharactersToRemodel.Count);
            for (var charactersToRemodelIndex = 0;
                charactersToRemodelIndex < CharactersToRemodel.Count;
                charactersToRemodelIndex++)
            {
                var objectToSend = CharactersToRemodel[charactersToRemodelIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var charactersToRemodelCount = reader.ReadUShort();
            CharactersToRemodel = new List<CharacterToRemodelInformations>();
            for (var charactersToRemodelIndex = 0;
                charactersToRemodelIndex < charactersToRemodelCount;
                charactersToRemodelIndex++)
            {
                var objectToAdd = new CharacterToRemodelInformations();
                objectToAdd.Deserialize(reader);
                CharactersToRemodel.Add(objectToAdd);
            }
        }
    }
}