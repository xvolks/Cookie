using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class DungeonKeyRingMessage : NetworkMessage
    {
        public const uint ProtocolId = 6299;
        public override uint MessageID { get { return ProtocolId; } }

        public List<short> Availables;
        public List<short> Unavailables;

        public DungeonKeyRingMessage()
        {
        }

        public DungeonKeyRingMessage(
            List<short> availables,
            List<short> unavailables
        )
        {
            Availables = availables;
            Unavailables = unavailables;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Availables.Count());
            foreach (var current in Availables)
            {
                writer.WriteVarShort(current);
            }
            writer.WriteShort((short)Unavailables.Count());
            foreach (var current in Unavailables)
            {
                writer.WriteVarShort(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countAvailables = reader.ReadShort();
            Availables = new List<short>();
            for (short i = 0; i < countAvailables; i++)
            {
                Availables.Add(reader.ReadVarShort());
            }
            var countUnavailables = reader.ReadShort();
            Unavailables = new List<short>();
            for (short i = 0; i < countUnavailables; i++)
            {
                Unavailables.Add(reader.ReadVarShort());
            }
        }
    }
}