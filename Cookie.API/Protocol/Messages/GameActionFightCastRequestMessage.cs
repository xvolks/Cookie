using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightCastRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 1005;

        public override ushort MessageID => ProtocolId;

        public ushort SpellId { get; set; }
        public short CellId { get; set; }
        public GameActionFightCastRequestMessage() { }

        public GameActionFightCastRequestMessage( ushort SpellId, short CellId ){
            this.SpellId = SpellId;
            this.CellId = CellId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SpellId);
            writer.WriteShort(CellId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadVarUhShort();
            CellId = reader.ReadShort();
        }
    }
}
