using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartOkMountWithOutPaddockMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5991;

        public override ushort MessageID => ProtocolId;

        public List<MountClientData> StabledMountsDescription { get; set; }
        public ExchangeStartOkMountWithOutPaddockMessage() { }

        public ExchangeStartOkMountWithOutPaddockMessage( List<MountClientData> StabledMountsDescription ){
            this.StabledMountsDescription = StabledMountsDescription;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)StabledMountsDescription.Count);
			foreach (var x in StabledMountsDescription)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var StabledMountsDescriptionCount = reader.ReadShort();
            StabledMountsDescription = new List<MountClientData>();
            for (var i = 0; i < StabledMountsDescriptionCount; i++)
            {
                var objectToAdd = new MountClientData();
                objectToAdd.Deserialize(reader);
                StabledMountsDescription.Add(objectToAdd);
            }
        }
    }
}
