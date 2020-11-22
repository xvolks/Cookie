using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class AreaFightModificatorUpdateMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6493;

        public override ushort MessageID => ProtocolId;

        public int SpellPairId { get; set; }
        public AreaFightModificatorUpdateMessage() { }

        public AreaFightModificatorUpdateMessage( int SpellPairId ){
            this.SpellPairId = SpellPairId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteInt(SpellPairId);
        }

        public override void Deserialize(IDataReader reader)
        {
            SpellPairId = reader.ReadInt();
        }
    }
}
