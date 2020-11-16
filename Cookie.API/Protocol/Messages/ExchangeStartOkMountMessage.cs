using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ExchangeStartOkMountMessage : ExchangeStartOkMountWithOutPaddockMessage
    {
        public new const ushort ProtocolId = 5979;

        public override ushort MessageID => ProtocolId;

        public List<MountClientData> PaddockedMountsDescription { get; set; }
        public ExchangeStartOkMountMessage() { }

        public ExchangeStartOkMountMessage( List<MountClientData> PaddockedMountsDescription ){
            this.PaddockedMountsDescription = PaddockedMountsDescription;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)PaddockedMountsDescription.Count);
			foreach (var x in PaddockedMountsDescription)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var PaddockedMountsDescriptionCount = reader.ReadShort();
            PaddockedMountsDescription = new List<MountClientData>();
            for (var i = 0; i < PaddockedMountsDescriptionCount; i++)
            {
                var objectToAdd = new MountClientData();
                objectToAdd.Deserialize(reader);
                PaddockedMountsDescription.Add(objectToAdd);
            }
        }
    }
}
