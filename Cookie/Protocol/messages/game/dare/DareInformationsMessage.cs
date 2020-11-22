using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class DareInformationsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6656;
        public override uint MessageID { get { return ProtocolId; } }

        public DareInformations DareFixedInfos;
        public DareVersatileInformations DareVersatilesInfos;

        public DareInformationsMessage()
        {
        }

        public DareInformationsMessage(
            DareInformations dareFixedInfos,
            DareVersatileInformations dareVersatilesInfos
        )
        {
            DareFixedInfos = dareFixedInfos;
            DareVersatilesInfos = dareVersatilesInfos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            DareFixedInfos.Serialize(writer);
            DareVersatilesInfos.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            DareFixedInfos = new DareInformations();
            DareFixedInfos.Deserialize(reader);
            DareVersatilesInfos = new DareVersatileInformations();
            DareVersatilesInfos.Deserialize(reader);
        }
    }
}