using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class IgnoredAddedMessage : NetworkMessage
    {
        public const uint ProtocolId = 5678;
        public override uint MessageID { get { return ProtocolId; } }

        public IgnoredInformations IgnoreAdded;
        public bool Session = false;

        public IgnoredAddedMessage()
        {
        }

        public IgnoredAddedMessage(
            IgnoredInformations ignoreAdded,
            bool session
        )
        {
            IgnoreAdded = ignoreAdded;
            Session = session;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(IgnoreAdded.TypeId);
            IgnoreAdded.Serialize(writer);
            writer.WriteBoolean(Session);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var ignoreAddedTypeId = reader.ReadShort();
            IgnoreAdded = new IgnoredInformations();
            IgnoreAdded.Deserialize(reader);
            Session = reader.ReadBoolean();
        }
    }
}