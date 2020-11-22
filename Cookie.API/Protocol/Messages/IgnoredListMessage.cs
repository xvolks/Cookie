using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class IgnoredListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5674;

        public override ushort MessageID => ProtocolId;

        public List<IgnoredInformations> IgnoredList { get; set; }
        public IgnoredListMessage() { }

        public IgnoredListMessage( List<IgnoredInformations> IgnoredList ){
            this.IgnoredList = IgnoredList;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)IgnoredList.Count);
			foreach (var x in IgnoredList)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var IgnoredListCount = reader.ReadShort();
            IgnoredList = new List<IgnoredInformations>();
            for (var i = 0; i < IgnoredListCount; i++)
            {
                IgnoredInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                IgnoredList.Add(objectToAdd);
            }
        }
    }
}
