using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterFirstSelectionMessage : CharacterSelectionMessage
    {
        public new const uint ProtocolId = 6084;
        public override uint MessageID { get { return ProtocolId; } }

        public bool DoTutorial = false;

        public CharacterFirstSelectionMessage(): base()
        {
        }

        public CharacterFirstSelectionMessage(
            long id_,
            bool doTutorial
        ): base(
            id_
        )
        {
            DoTutorial = doTutorial;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteBoolean(DoTutorial);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            DoTutorial = reader.ReadBoolean();
        }
    }
}