using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AchievementObjective : NetworkType
    {
        public const ushort ProtocolId = 404;

        public override ushort TypeID => ProtocolId;

        public uint Id { get; set; }
        public uint MaxValue { get; set; }
        public AchievementObjective() { }

        public AchievementObjective( uint Id, uint MaxValue ){
            this.Id = Id;
            this.MaxValue = MaxValue;
        }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhInt(Id);
            writer.WriteVarUhInt(MaxValue);
        }

        public override void Deserialize(IDataReader reader)
        {
            Id = reader.ReadVarUhInt();
            MaxValue = reader.ReadVarUhInt();
        }
    }
}
