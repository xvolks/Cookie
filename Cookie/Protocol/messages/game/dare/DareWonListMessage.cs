using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class DareWonListMessage : NetworkMessage
    {
        public const uint ProtocolId = 6682;
        public override uint MessageID { get { return ProtocolId; } }

        public List<double> DareId;

        public DareWonListMessage()
        {
        }

        public DareWonListMessage(
            List<double> dareId
        )
        {
            DareId = dareId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)DareId.Count());
            foreach (var current in DareId)
            {
                writer.WriteDouble(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countDareId = reader.ReadShort();
            DareId = new List<double>();
            for (short i = 0; i < countDareId; i++)
            {
                DareId.Add(reader.ReadDouble());
            }
        }
    }
}