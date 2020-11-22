using Cookie.API.Utils.IO;
using Cookie.API.Protocol.Enums;
using System.Collections.Generic;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;

namespace Cookie.API.Protocol.Network.Types
{

    public class AchievementAchievedRewardable : AchievementAchieved
    {
        public new const ushort ProtocolId = 515;

        public override ushort TypeID => ProtocolId;

        public ushort Finishedlevel { get; set; }
        public AchievementAchievedRewardable() { }

        public AchievementAchievedRewardable( ushort Finishedlevel ){
            this.Finishedlevel = Finishedlevel;
        }

        public override void Serialize(IDataWriter writer)
        {
            base.Serialize(writer);
            writer.WriteVarUhShort(Finishedlevel);
        }

        public override void Deserialize(IDataReader reader)
        {
            base.Deserialize(reader);
            Finishedlevel = reader.ReadVarUhShort();
        }
    }
}
