using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class DareSubscribedListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6658;
        public override uint MessageID { get { return ProtocolId; } }

        public List<DareInformations> DaresFixedInfos;
        public List<DareVersatileInformations> DaresVersatilesInfos;

        public DareSubscribedListMessage()
        {
        }

        public DareSubscribedListMessage(
            List<DareInformations> daresFixedInfos,
            List<DareVersatileInformations> daresVersatilesInfos
        )
        {
            DaresFixedInfos = daresFixedInfos;
            DaresVersatilesInfos = daresVersatilesInfos;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)DaresFixedInfos.Count());
            foreach (var current in DaresFixedInfos)
            {
                current.Serialize(writer);
            }
            writer.WriteShort((short)DaresVersatilesInfos.Count());
            foreach (var current in DaresVersatilesInfos)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countDaresFixedInfos = reader.ReadShort();
            DaresFixedInfos = new List<DareInformations>();
            for (short i = 0; i < countDaresFixedInfos; i++)
            {
                DareInformations type = new DareInformations();
                type.Deserialize(reader);
                DaresFixedInfos.Add(type);
            }
            var countDaresVersatilesInfos = reader.ReadShort();
            DaresVersatilesInfos = new List<DareVersatileInformations>();
            for (short i = 0; i < countDaresVersatilesInfos; i++)
            {
                DareVersatileInformations type = new DareVersatileInformations();
                type.Deserialize(reader);
                DaresVersatilesInfos.Add(type);
            }
        }
    }
}