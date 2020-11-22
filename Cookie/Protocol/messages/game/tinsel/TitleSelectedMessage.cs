using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class TitleSelectedMessage : NetworkMessage
    {
        public const uint ProtocolId = 6366;
        public override uint MessageID { get { return ProtocolId; } }

        public short TitleId = 0;

        public TitleSelectedMessage()
        {
        }

        public TitleSelectedMessage(
            short titleId
        )
        {
            TitleId = titleId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(TitleId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            TitleId = reader.ReadVarShort();
        }
    }
}