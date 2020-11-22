using Cookie.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cookie.Protocol.Network.Types
{
    public class HumanOptionFollowers : HumanOption
    {
        public new const short ProtocolId = 410;
        public override short TypeId { get { return ProtocolId; } }

        public List<IndexedEntityLook> FollowingCharactersLook;

        public HumanOptionFollowers(): base()
        {
        }

        public HumanOptionFollowers(
            List<IndexedEntityLook> followingCharactersLook
        ): base()
        {
            FollowingCharactersLook = followingCharactersLook;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteShort((short)FollowingCharactersLook.Count());
            foreach (var current in FollowingCharactersLook)
            {
                current.Serialize(writer);
            }
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            var countFollowingCharactersLook = reader.ReadShort();
            FollowingCharactersLook = new List<IndexedEntityLook>();
            for (short i = 0; i < countFollowingCharactersLook; i++)
            {
                IndexedEntityLook type = new IndexedEntityLook();
                type.Deserialize(reader);
                FollowingCharactersLook.Add(type);
            }
        }
    }
}