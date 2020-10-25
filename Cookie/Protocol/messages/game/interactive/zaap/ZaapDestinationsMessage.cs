using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ZaapDestinationsMessage : TeleportDestinationsMessage
    {
        public new const uint ProtocolId = 6830;
        public override uint MessageID { get { return ProtocolId; } }

        public double SpawnMapId = 0;

        public ZaapDestinationsMessage(): base()
        {
        }

        public ZaapDestinationsMessage(
            byte type,
            List<TeleportDestination> destinations,
            double spawnMapId
        ): base(
            type,
            destinations
        )
        {
            SpawnMapId = spawnMapId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteDouble(SpawnMapId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            SpawnMapId = reader.ReadDouble();
        }
    }
}