using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class FriendsListMessage : NetworkMessage
    {
        public const ushort ProtocolId = 4002;

        public override ushort MessageID => ProtocolId;

        public List<FriendInformations> FriendsList { get; set; }
        public FriendsListMessage() { }

        public FriendsListMessage( List<FriendInformations> FriendsList ){
            this.FriendsList = FriendsList;
        }

        public override void Serialize(IDataWriter writer)
        {
			writer.WriteShort((short)FriendsList.Count);
			foreach (var x in FriendsList)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            var FriendsListCount = reader.ReadShort();
            FriendsList = new List<FriendInformations>();
            for (var i = 0; i < FriendsListCount; i++)
            {
                FriendInformations objectToAdd = ProtocolTypeManager.GetInstance(reader.ReadUShort());
                objectToAdd.Deserialize(reader);
                FriendsList.Add(objectToAdd);
            }
        }
    }
}
