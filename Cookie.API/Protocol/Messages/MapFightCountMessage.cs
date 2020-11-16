using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapFightCountMessage : NetworkMessage
    {
        public const ushort ProtocolId = 210;

        public override ushort MessageID => ProtocolId;

        public ushort FightCount { get; set; }
        public MapFightCountMessage() { }

        public MapFightCountMessage( ushort FightCount ){
            this.FightCount = FightCount;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightCount);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightCount = reader.ReadVarUhShort();
        }
    }
}
