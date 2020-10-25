using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class ClientUIOpenedByObjectMessage : ClientUIOpenedMessage
    {
        public new const uint ProtocolId = 6463;
        public override uint MessageID { get { return ProtocolId; } }

        public int Uid = 0;

        public ClientUIOpenedByObjectMessage(): base()
        {
        }

        public ClientUIOpenedByObjectMessage(
            byte type,
            int uid
        ): base(
            type
        )
        {
            Uid = uid;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteVarInt(Uid);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            Uid = reader.ReadVarInt();
        }
    }
}