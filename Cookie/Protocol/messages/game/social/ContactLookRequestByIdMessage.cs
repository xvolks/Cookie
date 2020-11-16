using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ContactLookRequestByIdMessage : ContactLookRequestMessage
    {
        public new const uint ProtocolId = 5935;
        public override uint MessageID { get { return ProtocolId; } }

        public long PlayerId = 0;

        public ContactLookRequestByIdMessage(): base()
        {
        }

        public ContactLookRequestByIdMessage(
            byte requestId,
            byte contactType,
            long playerId
        ): base(
            requestId,
            contactType
        )
        {
            PlayerId = playerId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarLong(PlayerId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            PlayerId = reader.ReadVarLong();
        }
    }
}