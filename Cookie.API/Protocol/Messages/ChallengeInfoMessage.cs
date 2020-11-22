using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Messages
{

    public class ChallengeInfoMessage : NetworkMessage
    {
        public const ushort ProtocolId = 6022;

        public override ushort MessageID => ProtocolId;

        public ushort ChallengeId { get; set; }
        public double TargetId { get; set; }
        public uint XpBonus { get; set; }
        public uint DropBonus { get; set; }
        public ChallengeInfoMessage() { }

        public ChallengeInfoMessage( ushort ChallengeId, double TargetId, uint XpBonus, uint DropBonus ){
            this.ChallengeId = ChallengeId;
            this.TargetId = TargetId;
            this.XpBonus = XpBonus;
            this.DropBonus = DropBonus;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(ChallengeId);
            writer.WriteDouble(TargetId);
            writer.WriteVarUhInt(XpBonus);
            writer.WriteVarUhInt(DropBonus);
        }

        public override void Deserialize(IDataReader reader)
        {
            ChallengeId = reader.ReadVarUhShort();
            TargetId = reader.ReadDouble();
            XpBonus = reader.ReadVarUhInt();
            DropBonus = reader.ReadVarUhInt();
        }
    }
}
