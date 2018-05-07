using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Types.Game.Achievement
{
    public class AchievementAchievedRewardable : AchievementAchieved
    {

        public new const ushort ProtocolId = 515;
        public override ushort TypeID => ProtocolId;
        public ushort finishedlevel { get; set; }

        public AchievementAchievedRewardable() {
            
            }

        public AchievementAchievedRewardable(ushort id , ulong achievedby, ushort Finishedlevel) : base(id,achievedby)
        {
            
            finishedlevel = Finishedlevel;

        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            finishedlevel = reader.ReadVarUhShort();
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarShort((short)finishedlevel);   
        }
    }
}
