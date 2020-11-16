using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeStartOkMountWithOutPaddockMessage : NetworkMessage
    {
        public const uint ProtocolId = 5991;
        public override uint MessageID { get { return ProtocolId; } }

        public List<MountClientData> StabledMountsDescription;

        public ExchangeStartOkMountWithOutPaddockMessage()
        {
        }

        public ExchangeStartOkMountWithOutPaddockMessage(
            List<MountClientData> stabledMountsDescription
        )
        {
            StabledMountsDescription = stabledMountsDescription;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)StabledMountsDescription.Count());
            foreach (var current in StabledMountsDescription)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countStabledMountsDescription = reader.ReadShort();
            StabledMountsDescription = new List<MountClientData>();
            for (short i = 0; i < countStabledMountsDescription; i++)
            {
                MountClientData type = new MountClientData();
                type.Deserialize(reader);
                StabledMountsDescription.Add(type);
            }
        }
    }
}