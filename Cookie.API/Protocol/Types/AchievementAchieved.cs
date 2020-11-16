using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AchievementAchieved : NetworkType
    {
        public const ushort ProtocolId = 514;

        public override ushort TypeID => ProtocolId;

        public ushort Id { get; set; }
        public ulong AchievedBy { get; set; }
        public AchievementAchieved() { }

        public AchievementAchieved( ushort Id, ulong AchievedBy ){
            this.Id = Id;
            this.AchievedBy = AchievedBy;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(Id);
            writer.WriteVarUhLong(AchievedBy);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhShort();
            AchievedBy = reader.ReadVarUhLong();
        }
    }
}
