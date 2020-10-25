using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GuildPaddockBoughtMessage : NetworkMessage
    {
        public const uint ProtocolId = 5952;
        public override uint MessageID { get { return ProtocolId; } }

        public PaddockContentInformations PaddockInfo;

        public GuildPaddockBoughtMessage()
        {
        }

        public GuildPaddockBoughtMessage(
            PaddockContentInformations paddockInfo
        )
        {
            PaddockInfo = paddockInfo;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            PaddockInfo.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            PaddockInfo = new PaddockContentInformations();
            PaddockInfo.Deserialize(reader);
        }
    }
}