using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class DareVersatileListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6657;
        public override uint MessageID { get { return ProtocolId; } }

        public List<DareVersatileInformations> Dares;

        public DareVersatileListMessage()
        {
        }

        public DareVersatileListMessage(
            List<DareVersatileInformations> dares
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
            Dares = new List<DareVersatileInformations>();
            for (short i = 0; i < countDares; i++)
            {
                DareVersatileInformations type = new DareVersatileInformations();
                type.Deserialize(reader);
                Dares.Add(type);
            }
        }
    }
}