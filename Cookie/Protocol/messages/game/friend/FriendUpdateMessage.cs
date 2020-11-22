using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class FriendUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 5924;
        public override uint MessageID { get { return ProtocolId; } }

        public FriendInformations FriendUpdated;

        public FriendUpdateMessage()
        {
        }

        public FriendUpdateMessage(
            FriendInformations friendUpdated
        )
        {
            FriendUpdated = friendUpdated;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort(FriendUpdated.TypeId);
            FriendUpdated.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var friendUpdatedTypeId = reader.ReadShort();
            FriendUpdated = new FriendInformations();
            FriendUpdated.Deserialize(reader);
        }
    }
}