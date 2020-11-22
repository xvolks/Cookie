using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class LockableChangeCodeMessage : NetworkMessage
    {
        public const uint ProtocolId = 5666;
        public override uint MessageID { get { return ProtocolId; } }

        public string Code;

        public LockableChangeCodeMessage()
        {
        }

        public LockableChangeCodeMessage(
            string code
        )
        {
            Code = code;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteUTF(Code);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Code = reader.ReadUTF();
        }
    }
}