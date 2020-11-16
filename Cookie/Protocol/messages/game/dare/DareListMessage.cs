using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class DareListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6661;
        public override uint MessageID { get { return ProtocolId; } }

        public List<DareInformations> Dares;

        public DareListMessage()
        {
        }

        public DareListMessage(
            List<DareInformations> dares
        )
        {
            Dares = dares;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Dares.Count());
            foreach (var current in Dares)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countDares = reader.ReadShort();
            Dares = new List<DareInformations>();
            for (short i = 0; i < countDares; i++)
            {
                DareInformations type = new DareInformations();
                type.Deserialize(reader);
                Dares.Add(type);
            }
        }
    }
}