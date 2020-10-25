using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class CharactersListWithRemodelingMessage : CharactersListMessage
    {
        public new const uint ProtocolId = 6550;
        public override uint MessageID { get { return ProtocolId; } }

        public List<CharacterToRemodelInformations> CharactersToRemodel;

        public CharactersListWithRemodelingMessage(): base()
        {
        }

        public CharactersListWithRemodelingMessage(
            List<CharacterBaseInformations> characters,
            bool hasStartupActions,
            List<CharacterToRemodelInformations> charactersToRemodel
        ): base(
            characters,
            hasStartupActions
        )
        {
            CharactersToRemodel = charactersToRemodel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)CharactersToRemodel.Count());
            foreach (var current in CharactersToRemodel)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countCharactersToRemodel = reader.ReadShort();
            CharactersToRemodel = new List<CharacterToRemodelInformations>();
            for (short i = 0; i < countCharactersToRemodel; i++)
            {
                CharacterToRemodelInformations type = new CharacterToRemodelInformations();
                type.Deserialize(reader);
                CharactersToRemodel.Add(type);
            }
        }
    }
}