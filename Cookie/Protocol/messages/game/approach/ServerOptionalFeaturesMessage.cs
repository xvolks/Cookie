using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class ServerOptionalFeaturesMessage : NetworkMessage
    {
        public const uint ProtocolId = 6305;
        public override uint MessageID { get { return ProtocolId; } }

        public List<byte> Features;

        public ServerOptionalFeaturesMessage()
        {
        }

        public ServerOptionalFeaturesMessage(
            List<byte> features
        )
        {
            Features = features;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Features.Count());
            foreach (var current in Features)
            {
                writer.WriteByte(current);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countFeatures = reader.ReadShort();
            Features = new List<byte>();
            for (short i = 0; i < countFeatures; i++)
            {
                Features.Add(reader.ReadByte());
            }
        }
    }
}