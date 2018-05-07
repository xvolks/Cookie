using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.API.Utils.IO;
namespace Cookie.API.Protocol.Network.Types.Game.Achievement
{
    
    public class AchievementAchieved : NetworkType
    {
        public const ushort ProtocolId = 514;
        public override ushort TypeID => ProtocolId;
        public ushort id { get; set; }
        public ulong achievedby { get; set; }
        public AchievementAchieved(ushort Id, ulong Achievedby)
        {
            id = Id;
            achievedby = Achievedby;
        }
        public AchievementAchieved()
        {
           
        }
        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(id);
            writer.WriteVarUhLong(achievedby);
        }

        public override void Deserialize(IDataReader reader)
        {
            id = reader.ReadVarUhShort();
            achievedby = reader.ReadVarUhLong();
        }
    }
}
