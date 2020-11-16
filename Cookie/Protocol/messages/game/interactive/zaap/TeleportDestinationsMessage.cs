using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class TeleportDestinationsMessage : NetworkMessage
    {
        public const uint ProtocolId = 6829;
        public override uint MessageID { get { return ProtocolId; } }

        public byte Type = 0;
        public List<TeleportDestination> Destinations;

        public TeleportDestinationsMessage()
        {
        }

        public TeleportDestinationsMessage(
            byte type,
            List<TeleportDestination> destinations
        )
        {
            Type = type;
            Destinations = destinations;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteByte(Type);
            writer.WriteShort((short)Destinations.Count());
            foreach (var current in Destinations)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            Type = reader.ReadByte();
            var countDestinations = reader.ReadShort();
            Destinations = new List<TeleportDestination>();
            for (short i = 0; i < countDestinations; i++)
            {
                TeleportDestination type = new TeleportDestination();
                type.Deserialize(reader);
                Destinations.Add(type);
            }
        }
    }
}