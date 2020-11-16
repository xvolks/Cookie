using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeMountsStableAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6555;

        public override ushort MessageID => ProtocolId;

        public List<MountClientData> MountDescription { get; set; }
        public ExchangeMountsStableAddMessage() { }

        public ExchangeMountsStableAddMessage( List<MountClientData> MountDescription ){
            this.MountDescription = MountDescription;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)MountDescription.Count);
			foreach (var x in MountDescription)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var MountDescriptionCount = reader.ReadShort();
            MountDescription = new List<MountClientData>();
            for (var i = 0; i < MountDescriptionCount; i++)
            {
                var objectToAdd = new MountClientData();
                objectToAdd.Deserialize(reader);
                MountDescription.Add(objectToAdd);
            }
        }
    }
}
