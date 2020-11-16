using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class TeleportDestinationsMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6829;

        public override ushort MessageID => ProtocolId;

        public sbyte Type { get; set; }
        public new List<TeleportDestination> Destinations { get; set; }
        public TeleportDestinationsMessage() { }

        public TeleportDestinationsMessage( sbyte Type, List<TeleportDestination> Destinations ){
            this.Type = Type;
            this.Destinations = Destinations;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(Type);
			writer.WriteShort((short)Destinations.Count);
			foreach (var x in Destinations)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            Type = reader.ReadSByte();
            var DestinationsCount = reader.ReadShort();
            Destinations = new List<TeleportDestination>();
            for (var i = 0; i < DestinationsCount; i++)
            {
                var objectToAdd = new TeleportDestination();
                objectToAdd.Deserialize(reader);
                Destinations.Add(objectToAdd);
            }
        }
    }
}
