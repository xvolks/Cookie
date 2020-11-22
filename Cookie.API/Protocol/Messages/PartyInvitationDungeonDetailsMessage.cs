using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class PartyInvitationDungeonDetailsMessage : PartyInvitationDetailsMessage
    {
        public new const ushort ProtocolId = 6262;

        public override ushort MessageID => ProtocolId;

        public ushort DungeonId { get; set; }
        public List<bool> PlayersDungeonReady { get; set; }
        public PartyInvitationDungeonDetailsMessage() { }

        public PartyInvitationDungeonDetailsMessage( ushort DungeonId, List<bool> PlayersDungeonReady ){
            this.DungeonId = DungeonId;
            this.PlayersDungeonReady = PlayersDungeonReady;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(DungeonId);
			writer.WriteShort((short)PlayersDungeonReady.Count);
			foreach (var x in PlayersDungeonReady)
			{
				writer.WriteBoolean(x);
			}
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            DungeonId = reader.ReadVarUhShort();
            var PlayersDungeonReadyCount = reader.ReadShort();
            PlayersDungeonReady = new List<bool>();
            for (var i = 0; i < PlayersDungeonReadyCount; i++)
            {
                PlayersDungeonReady.Add(reader.ReadBoolean());
            }
        }
    }
}
