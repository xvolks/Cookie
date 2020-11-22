using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Messages
{
    public class FriendsListMessage : NetworkMessage
    {
        public const uint ProtocolId = 4002;
        public override uint MessageID { get { return ProtocolId; } }

        public List<FriendInformations> FriendsList;

        public FriendsListMessage()
        {
        }

        public FriendsListMessage(
            List<FriendInformations> friendsList
        )
        {
            FriendsList = friendsList;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteShort((short)FriendsList.Count());
            foreach (var current in FriendsList)
            {
                writer.WriteShort(current.TypeId);
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            var countFriendsList = reader.ReadShort();
            FriendsList = new List<FriendInformations>();
            for (short i = 0; i < countFriendsList; i++)
            {
                var friendsListtypeId = reader.ReadShort();
                FriendInformations type = new FriendInformations();
                type.Deserialize(reader);
                FriendsList.Add(type);
            }
        }
    }
}