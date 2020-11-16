using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class MapRunningFightDetailsRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5750;

        public override ushort MessageID => ProtocolId;

        public ushort FightId { get; set; }
        public MapRunningFightDetailsRequestMessage() { }

        public MapRunningFightDetailsRequestMessage( ushort FightId ){
            this.FightId = FightId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(FightId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightId = reader.ReadVarUhShort();
        }
    }
}
