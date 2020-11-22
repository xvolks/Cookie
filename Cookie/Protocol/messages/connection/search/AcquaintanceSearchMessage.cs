using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AcquaintanceSearchMessage : NetworkMessage
    {
        public const uint ProtocolId = 6144;
        public override uint MessageID { get { return ProtocolId; } }

        public string Nickname;

        public AcquaintanceSearchMessage()
        {
        }

        public AcquaintanceSearchMessage(
            string nickname
        )
        {
            Nickname = nickname;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Nickname);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Nickname = reader.ReadUTF();
        }
    }
}