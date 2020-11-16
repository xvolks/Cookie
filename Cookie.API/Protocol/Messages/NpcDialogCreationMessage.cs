using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class NpcDialogCreationMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5618;

        public override ushort MessageID => ProtocolId;

        public double MapId { get; set; }
        public int NpcId { get; set; }
        public NpcDialogCreationMessage() { }

        public NpcDialogCreationMessage( double MapId, int NpcId ){
            this.MapId = MapId;
            this.NpcId = NpcId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(MapId);
            writer.WriteInt(NpcId);
        }

        public override void Deserialize(IDataReader reader)
        {
            MapId = reader.ReadDouble();
            NpcId = reader.ReadInt();
        }
    }
}
