using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class CharacterReplayWithRemodelRequestMessage : CharacterReplayRequestMessage
    {
        public new const uint ProtocolId = 6551;
        public override uint MessageID { get { return ProtocolId; } }

        public RemodelingInformation Remodel;

        public CharacterReplayWithRemodelRequestMessage(): base()
        {
        }

        public CharacterReplayWithRemodelRequestMessage(
            long characterId,
            RemodelingInformation remodel
        ): base(
            characterId
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