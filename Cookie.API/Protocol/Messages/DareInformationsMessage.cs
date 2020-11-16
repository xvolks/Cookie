using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareInformationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6656;

        public override ushort MessageID => ProtocolId;

        public DareInformations DareFixedInfos { get; set; }
        public DareVersatileInformations DareVersatilesInfos { get; set; }
        public DareInformationsMessage() { }

        public DareInformationsMessage( DareInformations DareFixedInfos, DareVersatileInformations DareVersatilesInfos ){
            this.DareFixedInfos = DareFixedInfos;
            this.DareVersatilesInfos = DareVersatilesInfos;
        }

        public override void Serialize(IDataWriter writer)
        {
            DareFixedInfos.Serialize(writer);
            DareVersatilesInfos.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            DareFixedInfos = new DareInformations();
            DareFixedInfos.Deserialize(reader);
            DareVersatilesInfos = new DareVersatileInformations();
            DareVersatilesInfos.Deserialize(reader);
        }
    }
}
