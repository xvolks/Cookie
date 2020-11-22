using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class DareCreatedListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6663;

        public override ushort MessageID => ProtocolId;

        public List<DareInformations> DaresFixedInfos { get; set; }
        public List<DareVersatileInformations> DaresVersatilesInfos { get; set; }
        public DareCreatedListMessage() { }

        public DareCreatedListMessage( List<DareInformations> DaresFixedInfos, List<DareVersatileInformations> DaresVersatilesInfos ){
            this.DaresFixedInfos = DaresFixedInfos;
            this.DaresVersatilesInfos = DaresVersatilesInfos;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)DaresFixedInfos.Count);
			foreach (var x in DaresFixedInfos)
			{
				x.Serialize(writer);
			}
			writer.WriteShort((short)DaresVersatilesInfos.Count);
			foreach (var x in DaresVersatilesInfos)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var DaresFixedInfosCount = reader.ReadShort();
            DaresFixedInfos = new List<DareInformations>();
            for (var i = 0; i < DaresFixedInfosCount; i++)
            {
                var objectToAdd = new DareInformations();
                objectToAdd.Deserialize(reader);
                DaresFixedInfos.Add(objectToAdd);
            }
            var DaresVersatilesInfosCount = reader.ReadShort();
            DaresVersatilesInfos = new List<DareVersatileInformations>();
            for (var i = 0; i < DaresVersatilesInfosCount; i++)
            {
                var objectToAdd = new DareVersatileInformations();
                objectToAdd.Deserialize(reader);
                DaresVersatilesInfos.Add(objectToAdd);
            }
        }
    }
}
