namespace Cookie.API.Protocol.Network.Types.Game.Context.Roleplay
{
    using Types.Game.Look;
    using System.Collections.Generic;
    using Utils.IO;

    public class HumanOptionFollowers : HumanOption
    {
        public new const ushort ProtocolId = 410;
        public override ushort TypeID => ProtocolId;
        public List<IndexedEntityLook> FollowingCharactersLook { get; set; }

        public HumanOptionFollowers(List<IndexedEntityLook> followingCharactersLook)
        {
            FollowingCharactersLook = followingCharactersLook;
        }

        public HumanOptionFollowers() { }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)FollowingCharactersLook.Count);
            for (var followingCharactersLookIndex = 0; followingCharactersLookIndex < FollowingCharactersLook.Count; followingCharactersLookIndex++)
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
            for (var followingCharactersLookIndex = 0; followingCharactersLookIndex < followingCharactersLookCount; followingCharactersLookIndex++)
            {
                var objectToAdd = new IndexedEntityLook();
                objectToAdd.Deserialize(reader);
                FollowingCharactersLook.Add(objectToAdd);
            }
        }

    }
}
