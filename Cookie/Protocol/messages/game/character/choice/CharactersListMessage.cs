using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class CharactersListMessage : BasicCharactersListMessage
    {
        public new const uint ProtocolId = 151;
        public override uint MessageID { get { return ProtocolId; } }

        public bool HasStartupActions = false;

        public CharactersListMessage(): base()
        {
        }

        public CharactersListMessage(
            List<CharacterBaseInformations> characters,
            bool hasStartupActions
        ): base(
            characters
        )
        {
            HasStartupActions = hasStartupActions;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(HasStartupActions);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            HasStartupActions = reader.ReadBoolean();
        }
    }
}