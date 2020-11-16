using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class GameFightStartingMessage : NetworkMessage
    {
        public const ushort ProtocolId = 700;

        public override ushort MessageID => ProtocolId;

        public sbyte FightType { get; set; }
        public ushort FightId { get; set; }
        public double AttackerId { get; set; }
        public double DefenderId { get; set; }
        public GameFightStartingMessage() { }

        public GameFightStartingMessage( sbyte FightType, ushort FightId, double AttackerId, double DefenderId ){
            this.FightType = FightType;
            this.FightId = FightId;
            this.AttackerId = AttackerId;
            this.DefenderId = DefenderId;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteSByte(FightType);
            writer.WriteVarUhShort(FightId);
            writer.WriteDouble(AttackerId);
            writer.WriteDouble(DefenderId);
        }

        public override void Deserialize(IDataReader reader)
        {
            FightType = reader.ReadSByte();
            FightId = reader.ReadVarUhShort();
            AttackerId = reader.ReadDouble();
            DefenderId = reader.ReadDouble();
        }
    }
}
