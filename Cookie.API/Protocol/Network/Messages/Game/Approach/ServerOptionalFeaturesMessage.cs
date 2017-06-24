using System.Collections.Generic;
using Cookie.API.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Approach
{
    public class ServerOptionalFeaturesMessage : NetworkMessage
    {
        public const uint ProtocolId = 6305;

        public List<byte> Features;

        public ServerOptionalFeaturesMessage()
        {
        }

        public ServerOptionalFeaturesMessage(List<byte> features)
        {
            Features = features;
        }

        public override uint MessageID => ProtocolId;

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short) Features.Count);
            for (var i = 0; i < Features.Count; i++)
                writer.WriteByte(Features[i]);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var lenght = reader.ReadUShort();
            Features = new List<byte>();
            for (var i = 0; i < lenght; i++)
                Features.Add(reader.ReadByte());
        }
    }
}