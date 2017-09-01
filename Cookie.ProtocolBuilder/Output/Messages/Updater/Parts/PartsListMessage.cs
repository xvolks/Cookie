namespace Cookie.API.Protocol.Network.Messages.Updater.Parts
{
    using Types.Updater;
    using System.Collections.Generic;
    using Utils.IO;

    public class PartsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1502;
        public override ushort MessageID => ProtocolId;
        public List<ContentPart> Parts { get; set; }

        public PartsListMessage(List<ContentPart> parts)
        {
            Parts = parts;
        }

        public PartsListMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short)Parts.Count);
            for (var partsIndex = 0; partsIndex < Parts.Count; partsIndex++)
            {
                var objectToSend = Parts[partsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var partsCount = reader.ReadUShort();
            Parts = new List<ContentPart>();
            for (var partsIndex = 0; partsIndex < partsCount; partsIndex++)
            {
                var objectToAdd = new ContentPart();
                objectToAdd.Deserialize(reader);
                Parts.Add(objectToAdd);
            }
        }

    }
}
