using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ExchangeMountsPaddockAddMessage : NetworkMessage
    {
        public const uint ProtocolId = 6561;
        public override uint MessageID { get { return ProtocolId; } }

        public List<MountClientData> MountDescription;

        public ExchangeMountsPaddockAddMessage()
        {
        }

        public ExchangeMountsPaddockAddMessage(
            List<MountClientData> mountDescription
        )
        {
            MountDescription = mountDescription;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)MountDescription.Count());
            foreach (var current in MountDescription)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countMountDescription = reader.ReadShort();
            MountDescription = new List<MountClientData>();
            for (short i = 0; i < countMountDescription; i++)
            {
                MountClientData type = new MountClientData();
                type.Deserialize(reader);
                MountDescription.Add(type);
            }
        }
    }
}