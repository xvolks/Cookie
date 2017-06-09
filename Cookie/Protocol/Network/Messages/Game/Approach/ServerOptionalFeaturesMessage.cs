using Cookie.IO;
using System.Collections.Generic;

namespace Cookie.Protocol.Network.Messages.Game.Approach
{
    class ServerOptionalFeaturesMessage : NetworkMessage
    {
        public const uint ProtocolId = 6305;
        public override uint MessageID { get { return ProtocolId; } }

        public List<byte> Features;

        public ServerOptionalFeaturesMessage() { }

        public ServerOptionalFeaturesMessage(List<byte> features)
        {
            Features = features;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)Features.Count);
            for (int i = 0; i < Features.Count; i++)
            {
                writer.WriteByte(Features[i]);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ushort lenght = reader.ReadUShort();
            Features = new List<byte>();
            for (int i = 0; i < lenght; i++)
            {
                Features.Add(reader.ReadByte());
            }
        }
    }
}
