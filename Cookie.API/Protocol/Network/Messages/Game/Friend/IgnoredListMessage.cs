using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Friend;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Friend
{
    public class IgnoredListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5674;

        public IgnoredListMessage(List<IgnoredInformations> ignoredList)
        {
            IgnoredList = ignoredList;
        }

        public IgnoredListMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public List<IgnoredInformations> IgnoredList { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteShort((short) IgnoredList.Count);
            for (var ignoredListIndex = 0; ignoredListIndex < IgnoredList.Count; ignoredListIndex++)
            {
                var objectToSend = IgnoredList[ignoredListIndex];
                writer.WriteUShort(objectToSend.TypeID);
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            var ignoredListCount = reader.ReadUShort();
            IgnoredList = new List<IgnoredInformations>();
            for (var ignoredListIndex = 0; ignoredListIndex < ignoredListCount; ignoredListIndex++)
            {
                var objectToAdd = ProtocolTypeManager.GetInstance<IgnoredInformations>(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                IgnoredList.Add(objectToAdd);
            }
        }
    }
}