namespace Cookie.API.Protocol.Network.Messages.Game.Chat
{
    using Types.Game.Data.Items;
    using System.Collections.Generic;
    using Utils.IO;

    public class ChatClientMultiWithObjectMessage : ChatClientMultiMessage
    {
        public new const ushort ProtocolId = 862;
        public override ushort MessageID => ProtocolId;
        public List<ObjectItem> Objects { get; set; }

        public ChatClientMultiWithObjectMessage(List<ObjectItem> objects)
        {
            Objects = objects;
        }

        public ChatClientMultiWithObjectMessage() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)Objects.Count);
            for (var objectsIndex = 0; objectsIndex < Objects.Count; objectsIndex++)
            {
                var objectToSend = Objects[objectsIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var objectsCount = reader.ReadUShort();
            Objects = new List<ObjectItem>();
            for (var objectsIndex = 0; objectsIndex < objectsCount; objectsIndex++)
            {
                var objectToAdd = new ObjectItem();
                objectToAdd.Deserialize(reader);
                Objects.Add(objectToAdd);
            }
        }

    }
}
