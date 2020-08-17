using System.Collections.Generic;
using Cookie.API.Protocol.Network.Types.Game.Look;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    public class HumanOptionFollowers : HumanOption
    {
        public new const ushort ProtocolId = 410;

        public HumanOptionFollowers(List<IndexedEntityLook> followingCharactersLook)
        {
            FollowingCharactersLook = followingCharactersLook;
        }

        public HumanOptionFollowers()
        {
        }

        public override ushort TypeID => ProtocolId;
        public List<IndexedEntityLook> FollowingCharactersLook { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short) FollowingCharactersLook.Count);
            for (var followingCharactersLookIndex = 0;
                followingCharactersLookIndex < FollowingCharactersLook.Count;
                followingCharactersLookIndex++)
            {
                var objectToSend = FollowingCharactersLook[followingCharactersLookIndex];
                objectToSend.Serialize(writer);
            }
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var followingCharactersLookCount = reader.ReadUShort();
            FollowingCharactersLook = new List<IndexedEntityLook>();
            for (var followingCharactersLookIndex = 0;
                followingCharactersLookIndex < followingCharactersLookCount;
                followingCharactersLookIndex++)
            {
                var objectToAdd = new IndexedEntityLook();
                objectToAdd.Deserialize(reader);
                FollowingCharactersLook.Add(objectToAdd);
            }
        }
    }
}