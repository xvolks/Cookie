using System.Collections.Generic;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Approach
{
    public class ServerOptionalFeaturesMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6305;

        public ServerOptionalFeaturesMessage(List<byte> features)
        {
            Features = features;
        }

        public ServerOptionalFeaturesMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<byte> Features { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) Features.Count);
            for (var featuresIndex = 0; featuresIndex < Features.Count; featuresIndex++)
                writer.WriteByte(Features[featuresIndex]);
        }

        public override void Deserialize(IDataReader reader)
        {
            var featuresCount = reader.ReadUShort();
            Features = new List<byte>();
            for (var featuresIndex = 0; featuresIndex < featuresCount; featuresIndex++)
                Features.Add(reader.ReadByte());
        }
    }
}