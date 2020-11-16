using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightJoinRequestMessage : NetworkMessage
    {
        public const ushort ProtocolId = 701;

        public override ushort MessageID => ProtocolId;

        public double FighterId { get; set; }
        public ushort FightId { get; set; }
        public GameFightJoinRequestMessage() { }

        public GameFightJoinRequestMessage( double FighterId, ushort FightId ){
            this.FighterId = FighterId;
            this.FightId = FightId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteDouble(FighterId);
            writer.WriteVarUhShort(FightId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FighterId = reader.ReadDouble();
            FightId = reader.ReadVarUhShort();
        }
    }
}
