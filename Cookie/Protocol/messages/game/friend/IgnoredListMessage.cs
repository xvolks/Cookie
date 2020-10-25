using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class IgnoredListMessage : NetworkMessage
    {
        public const uint ProtocolId = 5674;
        public override uint MessageID { get { return ProtocolId; } }

        public List<IgnoredInformations> IgnoredList;

        public IgnoredListMessage()
        {
        }

        public IgnoredListMessage(
            List<IgnoredInformations> ignoredList
        )
        {
            IgnoredList = ignoredList;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)IgnoredList.Count());
            foreach (var current in IgnoredList)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countIgnoredList = reader.ReadShort();
            IgnoredList = new List<IgnoredInformations>();
            for (short i = 0; i < countIgnoredList; i++)
            {
                var ignoredListtypeId = reader.ReadShort();
                IgnoredInformations type = new IgnoredInformations();
                type.Deserialize(reader);
                IgnoredList.Add(type);
            }
        }
    }
}