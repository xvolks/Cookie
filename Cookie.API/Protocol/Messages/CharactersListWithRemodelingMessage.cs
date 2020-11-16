using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class CharactersListWithRemodelingMessage : CharactersListMessage
    {
        public new const ushort ProtocolId = 6550;

        public override ushort MessageID => ProtocolId;

        public List<CharacterToRemodelInformations> CharactersToRemodel { get; set; }
        public CharactersListWithRemodelingMessage() { }

        public CharactersListWithRemodelingMessage( List<CharacterToRemodelInformations> CharactersToRemodel ){
            this.CharactersToRemodel = CharactersToRemodel;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)CharactersToRemodel.Count);
			foreach (var x in CharactersToRemodel)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var CharactersToRemodelCount = reader.ReadShort();
            CharactersToRemodel = new List<CharacterToRemodelInformations>();
            for (var i = 0; i < CharactersToRemodelCount; i++)
            {
                var objectToAdd = new CharacterToRemodelInformations();
                objectToAdd.Deserialize(reader);
                CharactersToRemodel.Add(objectToAdd);
            }
        }
    }
}
