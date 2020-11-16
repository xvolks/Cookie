using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartOkMountMessage : ExchangeStartOkMountWithOutPaddockMessage
    {
        public new const uint ProtocolId = 5979;
        public override uint MessageID { get { return ProtocolId; } }

        public List<MountClientData> PaddockedMountsDescription;

        public ExchangeStartOkMountMessage(): base()
        {
        }

        public ExchangeStartOkMountMessage(
            List<MountClientData> stabledMountsDescription,
            List<MountClientData> paddockedMountsDescription
        ): base(
            stabledMountsDescription
        )
        {
            PaddockedMountsDescription = paddockedMountsDescription;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)PaddockedMountsDescription.Count());
            foreach (var current in PaddockedMountsDescription)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countPaddockedMountsDescription = reader.ReadShort();
            PaddockedMountsDescription = new List<MountClientData>();
            for (short i = 0; i < countPaddockedMountsDescription; i++)
            {
                MountClientData type = new MountClientData();
                type.Deserialize(reader);
                PaddockedMountsDescription.Add(type);
            }
        }
    }
}