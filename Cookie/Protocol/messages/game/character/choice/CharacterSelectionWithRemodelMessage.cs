using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterSelectionWithRemodelMessage : CharacterSelectionMessage
    {
        public new const uint ProtocolId = 6549;
        public override uint MessageID { get { return ProtocolId; } }

        public RemodelingInformation Remodel;

        public CharacterSelectionWithRemodelMessage(): base()
        {
        }

        public CharacterSelectionWithRemodelMessage(
            long id_,
            RemodelingInformation remodel
        ): base(
            id_
        )
        {
            Remodel = remodel;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            Remodel.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Remodel = new RemodelingInformation();
            Remodel.Deserialize(reader);
        }
    }
}