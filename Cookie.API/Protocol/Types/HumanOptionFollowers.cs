using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class HumanOptionFollowers : HumanOption
    {
        public new const ushort ProtocolId = 410;

        public override ushort TypeID => ProtocolId;

        public List<IndexedEntityLook> FollowingCharactersLook { get; set; }
        public HumanOptionFollowers() { }

        public HumanOptionFollowers( List<IndexedEntityLook> FollowingCharactersLook ){
            this.FollowingCharactersLook = FollowingCharactersLook;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
			writer.WriteShort((short)FollowingCharactersLook.Count);
			foreach (var x in FollowingCharactersLook)
			{
				x.Serialize(writer);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            var FollowingCharactersLookCount = reader.ReadShort();
            FollowingCharactersLook = new List<IndexedEntityLook>();
            for (var i = 0; i < FollowingCharactersLookCount; i++)
            {
                var objectToAdd = new IndexedEntityLook();
                objectToAdd.Deserialize(reader);
                FollowingCharactersLook.Add(objectToAdd);
            }
        }
    }
}
