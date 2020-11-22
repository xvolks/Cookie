using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameActionFightCastOnTargetRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6330;

        public override ushort MessageID => ProtocolId;

        public ushort SpellId { get; set; }
        public double TargetId { get; set; }
        public GameActionFightCastOnTargetRequestMessage() { }

        public GameActionFightCastOnTargetRequestMessage( ushort SpellId, double TargetId ){
            this.SpellId = SpellId;
            this.TargetId = TargetId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SpellId);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellId = reader.ReadVarUhShort();
            TargetId = reader.ReadDouble();
        }
    }
}
